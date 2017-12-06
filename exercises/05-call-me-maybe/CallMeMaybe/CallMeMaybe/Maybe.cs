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
        public override string ToString() => HasValue ? _value.ToString() : "null";

        public static implicit operator Maybe<T>(T value) => value != null ? new Maybe<T>(value) : Nothing;

        #region LINQ syntax providers

        public Maybe<TResult> Select<TResult>(Func<T, TResult> map)
        {
            // обеспечит поддержку одинарного from
            return HasValue ? map(_value) : Maybe<TResult>.Nothing;
        }
        public Maybe<TResult> Select<TResult>(Func<T, Maybe<TResult>> maybeMap)
        {
            // обеспечит поддержку одинарного from
            return HasValue ? maybeMap(_value) : Maybe<TResult>.Nothing;
        }
        public Maybe<TResult> SelectMany<T2, TResult>(Func<T, Maybe<T2>> otherSelector, Func<T, T2, TResult> resultSelector)
        {
            // обеспечит поддержку цепочки from
            if (HasValue && otherSelector(_value).HasValue) {
                return resultSelector(_value, otherSelector(_value)._value);
            }
            else {
                return Maybe<TResult>.Nothing;
            }
        }
        public Maybe<TResult> SelectMany<T2, TResult>(Func<T, Maybe<T2>> otherSelector, Func<T, T2, Maybe<TResult>> maybeResultSelector)
        {
            // обеспечит поддержку цепочки from
            if (HasValue && otherSelector(_value).HasValue) {
                return maybeResultSelector(_value, otherSelector(_value)._value);
            }
            else {
                return Maybe<TResult>.Nothing;
            }
        }
        public Maybe<T> Where(Predicate<T> predicate)
        {
            // обеспечит поддержку кляузы where
            return HasValue && predicate(_value) ? _value : Nothing;
        }

        #endregion

        #region Optional useful methods

        public static explicit operator T(Maybe<T> maybe) => maybe.Value;

        public T GetValueOrDefault() => HasValue ? _value : default(T);
        public T GetValueOrDefault(T defaultValue) => HasValue ? _value : defaultValue;

        public TResult SelectOrElse<TResult>(Func<T, TResult> map, Func<TResult> elseMap) => HasValue ? map(_value) : elseMap();

        public void Do(Action<T> doAction)
        {
            if (HasValue) {
                doAction(_value);
            }
            else {
                throw new InvalidOperationException($"{typeof(Maybe<T>)} doesn't have value.");
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
            if (!HasValue) {
                return elseMap();
            }
            else {
                throw new InvalidOperationException($"{typeof(Maybe<T>)} does have a value.");
            }
        }
        public void OrElseDo(Action elseAction)
        {
            if (!HasValue) {
                elseAction();
            }
            else {
                throw new InvalidOperationException($"{typeof(Maybe<T>)} does have a value.");
            }
        }

        #endregion
    }
}
