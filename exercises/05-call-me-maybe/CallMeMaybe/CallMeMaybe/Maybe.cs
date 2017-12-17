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
            return HasValue ? map(_value) : Maybe<TResult>.Nothing;
        }
        public Maybe<TResult> Select<TResult>(Func<T, Maybe<TResult>> maybeMap)
        {
            return HasValue ? maybeMap(_value) : Maybe<TResult>.Nothing;
        }

        public Maybe<TResult> SelectMany<T2, TResult>(Func<T, Maybe<T2>> otherSelector, Func<T, T2, TResult> resultSelector)
        {
            // обеспечит поддержку цепочки from
            Maybe<T2> interm = HasValue? otherSelector(_value) : Maybe<T2>.Nothing;
            return interm.HasValue ? resultSelector(_value, interm._value) : Maybe<TResult>.Nothing;
        }
        public Maybe<TResult> SelectMany<T2, TResult>(Func<T, Maybe<T2>> otherSelector, Func<T, T2, Maybe<TResult>> maybeResultSelector)
        {
            // обеспечит поддержку цепочки from
           return SelectMany(otherSelector, maybeResultSelector);
        }
        public Maybe<T> Where(Predicate<T> predicate)
        {
            if (!HasValue || !predicate(_value))
            {
                return Nothing;
            }
            return this;
        }

        #endregion

        #region Optional useful methods

        public T GetValueOrDefault() => Value;
        public T GetValueOrDefault(T defaultValue) => HasValue ? _value : defaultValue;

        public static explicit operator T(Maybe<T> maybe)
        {
            return maybe.Value;
        }

        public TResult SelectOrElse<TResult>(Func<T, TResult> map, Func<TResult> elseMap)
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
