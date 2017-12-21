using System;

namespace CallMeMaybe.V1
{
    public struct Maybe<T>
    {
        /*
            Как ты думаешь, почему Maybe - структура?
            Структура является значимым типом, следовательно, не может в null. То, что надо!
        */

        /// <summary>
        /// Зачем может быть нужно такое выделенное значение?
        /// Соблюдаем копирайт на null.
        /// Суть Maybe в том, чтобы принимать какое-либо значение или не иметь его вовсе.
        /// Сколько по факту будет экземпляров данного объекта?
        /// Обобщенные структуры/классы не делят своих статических членов, поэтому по одному на каждый используемый T.
        /// </summary>
        public static readonly Maybe<T> Nothing = new Maybe<T>();

        public bool HasValue { get; }

        private readonly T _value;
        public T Value => HasValue ? _value : throw new InvalidOperationException($"{typeof(Maybe<T>)} doesn't have value.");

        /// <summary>
        /// Как думаешь, почему я скрыл конструктор?
        /// Не хочется кидать исключение, если придет null?
        /// </summary>
        private Maybe(T value)
        {
            _value = value;
            HasValue = true;
        }

        /// <inheritdoc />
        public override string ToString() => HasValue ? _value.ToString() : "null";
        // может правильнее кидать исключение, если null?

        public static implicit operator Maybe<T>(T value)
        {
            /*
                По смыслу это фабрика объектов данного типа (ну или по-модному монадный конструктор).
                Т.к. это оператор неявного приведения, позволяет не засорять код кастами.
            */
            return value != null ? new Maybe<T>(value) : Nothing;
        }

        #region Optional useful methods

        public static explicit operator T(Maybe<T> maybe) => maybe.Value;

        public T GetValueOrDefault() => HasValue ? _value : default(T);
        public T GetValueOrDefault(T defaultValue) => HasValue ? _value : defaultValue;

        public Maybe<TResult> Select<TResult>(Func<T, TResult> map) => HasValue ? map(_value) : Maybe<TResult>.Nothing;
        public Maybe<TResult> Select<TResult>(Func<T, Maybe<TResult>> maybeMap) => HasValue ? maybeMap(_value) : Maybe<TResult>.Nothing;
        public TResult SelectOrElse<TResult>(Func<T, TResult> map, Func<TResult> elseMap) => HasValue ? map(_value) : elseMap();
        // почему SelectOrElse возвращает TResult, а не Maybe<TResult>? тот же вопрос к нижеперечисленным методам
        // почему elseMap не принимает аргумент типа T?

        public void Do(Action<T> doAction)
        {
            if (HasValue) {
                doAction(_value);
            }
        }
        
        public void DoOrElse(Action<T> doAction, Action elseAction)
        {
            if (HasValue) {
                doAction(_value);
            }
            else {
                elseAction();
            }
        }

        public T OrElse(Func<T> elseMap)
        {
            return HasValue ? _value : elseMap();
        }

        public void OrElseDo(Action elseAction)
        {
            if (!HasValue) {
                elseAction();
            }
        }

        #endregion
    }
}
