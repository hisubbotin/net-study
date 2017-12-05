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
            return value == null ? Nothing : new Maybe<T>(value);
        }

        #region LINQ syntax providers

        public Maybe<TResult> Select<TResult>(Func<T, TResult> map)
        {
            // обеспечит поддержку одинарного from
            return HasValue ? map(Value) : Maybe<TResult>.Nothing;
        }
        public Maybe<TResult> Select<TResult>(Func<T, Maybe<TResult>> maybeMap)
        {
            // обеспечит поддержку одинарного from
            return HasValue ? maybeMap(Value) : Maybe<TResult>.Nothing;
        }
        public Maybe<TResult> SelectMany<T2, TResult>(Func<T, Maybe<T2>> otherSelector, Func<T, T2, TResult> resultSelector)
        {
            // обеспечит поддержку цепочки from
            if (HasValue)
            {
                var otherMaybe = otherSelector.Invoke(_value);
                if (otherMaybe.HasValue)
                {
                    return resultSelector.Invoke(_value, otherMaybe._value);
                }
            }
            return Maybe<TResult>.Nothing;
        }
        public Maybe<TResult> SelectMany<T2, TResult>(Func<T, Maybe<T2>> otherSelector, Func<T, T2, Maybe<TResult>> maybeResultSelector)
        {
            // обеспечит поддержку цепочки from
            if (HasValue)
            {
                var otherMaybe = otherSelector.Invoke(_value);
                if (otherMaybe.HasValue)
                {
                    return maybeResultSelector.Invoke(_value, otherMaybe._value);
                }
            }
            return Maybe<TResult>.Nothing;
        }
        public Maybe<T> Where(Predicate<T> predicate)
        {
            // обеспечит поддержку кляузы where
            if (HasValue)
            {
                return predicate.Invoke(_value) ? _value : Nothing;
            }
            return Nothing;
        }

        #endregion

        #region Optional useful methods

        public static explicit operator T(Maybe<T> maybe)
        {
            return maybe.Value;
        }

        public T GetValueOrDefault() => HasValue ? _value : default(T);
        public T GetValueOrDefault(T defaultValue) => HasValue ? _value : default(T);

        public TResult SelectOrElse<TResult>(Func<T, TResult> map, Func<TResult> elseMap)
        {
            return HasValue ? map.Invoke(_value) : elseMap.Invoke();
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
                doAction.Invoke(_value);
            }
            else
            {
                elseAction.Invoke();
            }
        }

        public T OrElse(Func<T> elseMap)
        {
            return HasValue ? _value : elseMap.Invoke();
        }
        public void OrElse(Action elseAction)
        {
            if (!HasValue)
            {
                elseAction.Invoke();
            }
        }

        #endregion
    }
}
