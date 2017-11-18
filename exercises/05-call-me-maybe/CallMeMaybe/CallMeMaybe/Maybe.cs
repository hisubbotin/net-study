using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CallMeMaybe
{
    public struct Maybe<T> : IEnumerable<T>
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
                По смыслу это фабрика объектов данного типа.
                Т.к. это оператор неявного приведения, позволяет не засорять код кастами.
            */
            throw new NotImplementedException();
        }

        #region IEnumerable<T> inerface implementation

        /*
            Здесь реализуй интерфейс IEnumerable<T>.
            Про какой подводный камень нужно помнить, когда объекты Maybe<T> используются как объекты типа IEnumerable?
        */

        /// <inheritdoc />
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion


        #region Optional useful methods

        public static explicit operator T(Maybe<T> maybe)
        {
            throw new NotImplementedException();
        }

        public T GetValueOrDefault() => throw new NotImplementedException();
        public T GetValueOrDefault(T defaultValue) => throw new NotImplementedException();

        //public Maybe<TResult> Select<TResult>(Func<T, TResult> map)
        //{
        //    throw new NotImplementedException();
        //}
        //public Maybe<TResult> Select<TResult>(Func<T, Maybe<TResult>> map)
        //{
        //    throw new NotImplementedException();
        //}
        public Maybe<TResult> SelectOrElse<TResult>(Func<T, TResult> map, Func<TResult> elseMap)
        {
            throw new NotImplementedException();
        }
        public Maybe<TResult> SelectOrElse<TResult>(Func<T, Maybe<TResult>> map, Func<Maybe<TResult>> elseMap)
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

        public Maybe<TResult> OrElse<TResult>(Func<TResult> elseMap)
        {
            throw new NotImplementedException();
        }
        public void OrElse(Action elseAction)
        {
            throw new NotImplementedException();
        }

        //public Maybe<TResult> SelectMany<T2, TResult>(Func<T, Maybe<T2>> otherSelector, Func<T, T2, TResult> resultSelector)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion
    }

    public static class MaybeExtensions
    {
        public static Maybe<T> ToMaybe<T>(this T value)
        {
            return value;
        }
        public static Maybe<T> ToMaybe<T>(this T? value)
            where T : struct
        {
            return value ?? Maybe<T>.Nothing;
        }
        public static Maybe<T> ToMaybe<T>(this IEnumerable<T> seq)
        {
            using (var iter = seq.GetEnumerator())
            {
                return iter.MoveNext() ? iter.Current : Maybe<T>.Nothing;
            }
        }
        public static Maybe<T> Unwrap<T>(this Maybe<Maybe<T>> m)
        {
            throw new NotImplementedException();
        }
    }
}
