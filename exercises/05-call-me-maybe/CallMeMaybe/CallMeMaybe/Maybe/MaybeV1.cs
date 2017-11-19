using System;

namespace CallMeMaybe.Maybe
{
    public struct MaybeV1<T>
    {
        /*
            Как ты думаешь, почему Maybe - структура?
        */

        /// <summary>
        /// Зачем может быть нужно такое выделенное значение?
        /// Сколько по факту будет экземпляров данного объекта?
        /// </summary>
        public static readonly MaybeV1<T> Nothing = new MaybeV1<T>();

        public bool HasValue { get; }

        private readonly T _value;
        public T Value => HasValue ? _value : throw new InvalidOperationException($"{typeof(MaybeV1<T>)} doesn't have value.");

        /// <summary>
        /// Как думаешь, почему я скрыл конструктор?
        /// </summary>
        private MaybeV1(T value)
        {
            _value = value;
            HasValue = true;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return HasValue ? _value.ToString() : "null";
        }

        public static implicit operator MaybeV1<T>(T value)
        {
            /*
                По смыслу это фабрика объектов данного типа.
                Т.к. это оператор неявного приведения, позволяет не засорять код кастами.
            */
            throw new NotImplementedException();
        }

        #region Optional useful methods

        public static explicit operator T(MaybeV1<T> maybe)
        {
            throw new NotImplementedException();
        }

        public T GetValueOrDefault() => throw new NotImplementedException();
        public T GetValueOrDefault(T defaultValue) => throw new NotImplementedException();

        public MaybeV1<TResult> Select<TResult>(Func<T, TResult> map)
        {
            throw new NotImplementedException();
        }
        public MaybeV1<TResult> Select<TResult>(Func<T, MaybeV1<TResult>> map)
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

        public TResult OrElse<TResult>(Func<TResult> elseMap)
        {
            throw new NotImplementedException();
        }
        public void OrElse(Action elseAction)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
