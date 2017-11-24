﻿using System;

namespace CallMeMaybe
{
    public struct Maybe<T>
    {
        public static readonly Maybe<T> Nothing = new Maybe<T>();

        public bool HasValue { get; }

        private readonly T _value;

        public T Value =>
            HasValue ? _value : throw new InvalidOperationException($"{typeof(Maybe<T>)} doesn't have value.");

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
            return value != null ? new Maybe<T>(value) : Nothing;
        }

        #region LINQ syntax providers

        public Maybe<TResult> Select<TResult>(Func<T, TResult> map)
        {
            // обеспечит поддержку одинарного from
            return HasValue ? new Maybe<TResult>(map(_value)) : Maybe<TResult>.Nothing;
        }

        public Maybe<TResult> Select<TResult>(Func<T, Maybe<TResult>> maybeMap)
        {
            // обеспечит поддержку одинарного from
            return HasValue ? maybeMap(_value) : Maybe<TResult>.Nothing;
        }

        public Maybe<TResult> SelectMany<T2, TResult>(Func<T, Maybe<T2>> otherSelector,
            Func<T, T2, TResult> resultSelector)
        {
            // обеспечит поддержку цепочки from
            if (!HasValue)
            {
                return Maybe<TResult>.Nothing;
            }
            var a = otherSelector(_value);
            return a.HasValue ? resultSelector(_value, a._value) : Maybe<TResult>.Nothing;
        }

        public Maybe<TResult> SelectMany<T2, TResult>(Func<T, Maybe<T2>> otherSelector,
            Func<T, T2, Maybe<TResult>> maybeResultSelector)
        {
            // обеспечит поддержку цепочки from
            if (!HasValue)
            {
                return Maybe<TResult>.Nothing;
            }
            var a = otherSelector(_value);
            return a.HasValue ? maybeResultSelector(_value, a._value) : Maybe<TResult>.Nothing;
        }

        public Maybe<T> Where(Predicate<T> predicate)
        {
            if (!HasValue || !predicate(_value))
            {
                return Nothing;
            }
            return _value;
        }

        #endregion

        #region Optional useful methods

        public static explicit operator T(Maybe<T> maybe)
        {
            return maybe.Value;
        }

        public T GetValueOrDefault() => HasValue ? _value : default(T);
        public T GetValueOrDefault(T defaultValue) => HasValue ? _value : defaultValue;

        public TResult SelectOrElse<TResult>(Func<T, TResult> map, Func<TResult> elseMap)
        {
            return HasValue ? map(_value) : elseMap();
        }

        public Maybe<TResult> SelectOrElse<TResult>(Func<T, Maybe<TResult>> map, Func<Maybe<TResult>> elseMap)
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

        public Maybe<TResult> OrElse<TResult>(Func<TResult> elseMap)
        {
            return HasValue ? Maybe<TResult>.Nothing : elseMap();
        }

        public void OrElse(Action elseAction)
        {
            if (!HasValue)
            {
                elseAction();
            }
        }

        #endregion
    }
}