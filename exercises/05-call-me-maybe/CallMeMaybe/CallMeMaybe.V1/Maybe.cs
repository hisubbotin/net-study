using System;

namespace CallMeMaybe.V1
{
    public struct Maybe<T>
    {
        /*
            Как ты думаешь, почему Maybe - структура?
            - Предположу, что не хотим засорять кучу и сам объект не должен быть большим. 
                Также это по сути обертка над ссылкой на объект.
        */

        /// <summary>
        /// Зачем может быть нужно такое выделенное значение?
        /// - Вместо null
        /// Сколько по факту будет экземпляров данного объекта?
        /// - Один на тип
        /// </summary>
        public static readonly Maybe<T> Nothing = new Maybe<T>();

        public bool HasValue { get; }

        private readonly T _value;
        public T Value => HasValue ? _value : throw new InvalidOperationException($"{typeof(Maybe<T>)} doesn't have value.");

        /// <summary>
        /// Как думаешь, почему я скрыл конструктор?
        /// - Видимо он будет вызываться из операторов и явный его вызов нам не к чему, может в операторах будут дополнительные проверки
        /// </summary>
        private Maybe(T value)
        {
            _value = value;
            HasValue = true;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return HasValue ? _value.ToString() : "null";
        }

        public static implicit operator Maybe<T>(T value)
        {
            /*
                По смыслу это фабрика объектов данного типа (ну или по модному монадный конструктор).
                Т.к. это оператор неявного приведения, позволяет не засорять код кастами.
            */
            return value == null ? Nothing : new Maybe<T>(value);
        }

        #region Optional useful methods

        public static explicit operator T(Maybe<T> maybe)
        {
            return maybe.Value;
        }

        public T GetValueOrDefault() => HasValue ? _value : default(T);
        public T GetValueOrDefault(T defaultValue) => HasValue ? _value : defaultValue;

        // Если нет значения, вернем Nothing
        public Maybe<TResult> Select<TResult>(Func<T, TResult> map)
        {
            return HasValue ? map(Value) : Maybe<TResult>.Nothing;
        }
        public Maybe<TResult> Select<TResult>(Func<T, Maybe<TResult>> maybeMap)
        {
            return HasValue ? maybeMap(Value) : Maybe<TResult>.Nothing;
        }
        public TResult SelectOrElse<TResult>(Func<T, TResult> map, Func<TResult> elseMap)
        {
            return HasValue ? map(Value) : elseMap();
        }

        // Если нет значения, то не будем ничего делать, а не кидать исключение
        public void Do(Action<T> doAction)
        {
            if (HasValue )
            {
                doAction(Value);
            }                
        }
        public void DoOrElse(Action<T> doAction, Action elseAction)
        {             
            if (HasValue)
            {
                doAction(Value);
            }
            else 
            {
                elseAction();
            }
        }

        public T OrElse(Func<T> elseMap)
        {
            return elseMap();
        }
        public void OrElseDo(Action elseAction)
        {
            elseAction();
        }

        #endregion
    }
}
