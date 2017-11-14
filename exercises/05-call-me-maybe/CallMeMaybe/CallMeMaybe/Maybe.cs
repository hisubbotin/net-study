using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CallMeMaybe
{
    public struct Maybe<T> : IEnumerable<T>
    {
        public static readonly Maybe<T> Nothing = new Maybe<T>();

        public bool HasValue { get; }

        private readonly T _value;
        public T Value => HasValue ? _value : throw new InvalidOperationException($"{typeof(Maybe<T>)} doesn't have value.");

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

        public T GetValueOrDefault() => _value;
        public T GetValueOrDefault(T defaultValue) => HasValue ? _value : defaultValue;

        public static implicit operator Maybe<T>(T value)
        {
            return value != null ? new Maybe<T>(value) : Nothing;
        }
        public static explicit operator T(Maybe<T> maybe) => maybe.Value;

        public Maybe<TResult> Select<TResult>(Func<T, TResult> map)
        {
            return HasValue ? map(_value) : Maybe<TResult>.Nothing;
        }
        public Maybe<TResult> SelectOrElse<TResult>(Func<T, TResult> map, Func<TResult> elseMap)
        {
            return HasValue ? map(_value) : elseMap();
        }

        public void Do(Action<T> doAction)
        {
            if (HasValue)
            {
                doAction(_value);
            }
        }
        public void DoOrElse(Action<T> doAction, Action elseAction)
        {
            if (HasValue)
            {
                doAction(_value);
            }
            else
            {
                elseAction();
            }
        }

        public Maybe<T> OrElse(Func<T> elseMap)
        {
            return HasValue ? this : elseMap();
        }
        public void OrElse(Action elseAction)
        {
            if (!HasValue)
            {
                elseAction();
            }
        }

        #region IEnumerable<T> inerface implementation

        /// <inheritdoc />
        public IEnumerator<T> GetEnumerator()
        {
            if (HasValue)
            {
                yield return _value;
            }
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }

    public static class MaybeExtensions
    {
        public static Maybe<T> ToMaybe<T>(this T value)
        {
            return value;
        }
        public static Maybe<T> ToMaybe<T>(this T? value)
            where T: struct
        {
            return value ?? Maybe<T>.Nothing;
        }
        public static Maybe<T> ToMaybe<T>(this IEnumerable<T> value)
            where T : struct
        {
            return value.SingleOrDefault();
        }
    }
}
