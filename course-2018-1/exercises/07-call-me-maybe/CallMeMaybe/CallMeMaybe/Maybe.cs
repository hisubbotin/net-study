using System;

namespace CallMeMaybe
{
    public struct Maybe<T>
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

        public static implicit operator Maybe<T>(T value)
        {
            return value != null ? new Maybe<T>(value) : Nothing;
        }

        #region LINQ syntax providers

        public Maybe<TResult> Select<TResult>(Func<T, TResult> map)
        {
            return HasValue ? map(_value).ToMaybe() : Maybe<TResult>.Nothing;
        }
        public Maybe<TResult> Select<TResult>(Func<T, Maybe<TResult>> maybeMap)
        {
            return HasValue ? maybeMap(_value) : Maybe<TResult>.Nothing;
        }
        public Maybe<TResult> SelectMany<T2, TResult>(Func<T, Maybe<T2>> otherSelector, Func<T, T2, TResult> resultSelector)
        {
            if (HasValue)
            {
                var result1 = otherSelector(_value);
                return result1.HasValue ? resultSelector(_value, result1.Value) : Maybe<TResult>.Nothing;
            }
            else return Maybe<TResult>.Nothing;
        }
        public Maybe<TResult> SelectMany<T2, TResult>(Func<T, Maybe<T2>> otherSelector, Func<T, T2, Maybe<TResult>> maybeResultSelector)
        {
            if (HasValue)
            {
                var result1 = otherSelector(_value);
                return result1.HasValue ? maybeResultSelector(_value, result1.Value) : Maybe<TResult>.Nothing;
            }
            else return Maybe<TResult>.Nothing;
        }
        public Maybe<T> Where(Predicate<T> predicate)
        {
            return HasValue ? (predicate(_value) ? _value : Nothing) : Nothing;
        }

        #endregion

        #region Optional useful methods

        public static explicit operator T(Maybe<T> maybe)
        {
            return maybe.Value;
        }

        public T GetValueOrDefault() => throw new NotImplementedException();
        public T GetValueOrDefault(T defaultValue) => HasValue ? _value : defaultValue;


        public Maybe<TResult> Select<TResult>(Func<T, Maybe<TResult?>> maybeMap) where TResult : struct
        {
            var result = HasValue ? maybeMap(_value) : Maybe<TResult?>.Nothing;
            var mapped = result.HasValue ? result.Value : null;
            return mapped.HasValue ? mapped.Value : Maybe<TResult>.Nothing;
        }
        public TResult SelectOrElse<TResult>(Func<T, TResult> map, Func<TResult> elseMap)
        {
            var res = HasValue ? map(_value).ToMaybe() : Maybe<TResult>.Nothing;
            return res.HasValue ? res.Value : elseMap();
        }

        public void Do(Action<T> doAction)
        {
            if (HasValue)
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
            return HasValue ? _value : elseMap();
        }
        public void OrElseDo(Action elseAction)
        {
            if (!HasValue)
            {
                elseAction();
            }
        }

        #endregion
    }
}
