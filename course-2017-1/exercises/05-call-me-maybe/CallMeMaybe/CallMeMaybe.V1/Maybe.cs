using System;

namespace CallMeMaybe.V1
{
    public struct Maybe<T>
    {
        /*
            Как ты думаешь, почему Maybe - структура?
        */

        /// <summary>
        /// Зачем может быть нужно такое выделенное значение?
        /// Сколько по факту будет экземпляров данного объекта?
        /// </summary>
        public static readonly Maybe<T> Nothing = new Maybe<T>();

        public bool HasValue { get; }

        private readonly T _value;
        public T Value => HasValue ? _value : throw new InvalidOperationException($"{typeof(Maybe<T>)} doesn't have value.");

        /// <summary>
        /// Как думаешь, почему я скрыл конструктор?
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
            throw new NotImplementedException();
        }

        #region Optional useful methods

        public static explicit operator T(Maybe<T> maybe)
        {
            throw new NotImplementedException();
        }

        public T GetValueOrDefault() => throw new NotImplementedException();
        public T GetValueOrDefault(T defaultValue) => throw new NotImplementedException();

        public Maybe<TResult> Select<TResult>(Func<T, TResult> map)
        {
            throw new NotImplementedException();
        }
        public Maybe<TResult> Select<TResult>(Func<T, Maybe<TResult>> maybeMap)
        {
            throw new NotImplementedException();
        }
        public TResult SelectOrElse<TResult>(Func<T, TResult> map, Func<TResult> elseMap)
        {
            throw new NotImplementedException();
        }

        public void Do(Action<T> doAction)
        {
            throw new NotImplementedException();
        }
        public void DoOrElse(Action<T> doAction, Action elseAction)
        {
            throw new NotImplementedException();
        }

        public T OrElse(Func<T> elseMap)
        {
            throw new NotImplementedException();
        }
        public void OrElseDo(Action elseAction)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
