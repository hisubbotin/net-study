using System;

namespace CallMeMaybe {
    public struct Maybe<T> {
        public static readonly Maybe<T> Nothing = new Maybe<T>();

        public bool HasValue { get; }

        private readonly T _value;

        public T Value =>
            HasValue ? _value : throw new InvalidOperationException($"{typeof(Maybe<T>)} doesn't have value.");

        private Maybe(T value) {
            _value = value;
            HasValue = true;
        }

        /// <inheritdoc />
        public override string ToString() {
            return HasValue ? _value.ToString() : "null";
        }

        public static implicit operator Maybe<T>(T value) {
            return value != null ? new Maybe<T>(value) : Nothing;
        }

        #region LINQ syntax providers

        public Maybe<TResult> Select<TResult>(Func<T, TResult> map) {
            // обеспечит поддержку одинарного from
            return HasValue ? map(_value) : Maybe<TResult>.Nothing;
        }

        public Maybe<TResult> Select<TResult>(Func<T, Maybe<TResult>> maybeMap) {
            // обеспечит поддержку одинарного from
            return maybeMap(_value);
        }

        public Maybe<TResult> SelectMany<T2, TResult>(Func<T, Maybe<T2>> otherSelector,
            Func<T, T2, TResult> resultSelector) {
            // обеспечит поддержку цепочки from
            var other = HasValue ? otherSelector(_value) : Maybe<T2>.Nothing;
            return other.HasValue ? resultSelector(_value, other._value) : Maybe<TResult>.Nothing;
        }

        public Maybe<TResult> SelectMany<T2, TResult>(Func<T, Maybe<T2>> otherSelector,
            Func<T, T2, Maybe<TResult>> maybeResultSelector) {
            // обеспечит поддержку цепочки from
            var other = HasValue ? otherSelector(_value) : Maybe<T2>.Nothing;
            return other.HasValue ? maybeResultSelector(_value, other._value) : Maybe<TResult>.Nothing;
        }

        public Maybe<T> Where(Predicate<T> predicate) {
            // обеспечит поддержку кляузы where
            return HasValue && predicate(_value) ? _value : Nothing;
        }

        #endregion

        #region Optional useful methods

        public static explicit operator T(Maybe<T> maybe) {
            if (!maybe.HasValue) {
                throw new NullReferenceException();
            }
            return maybe._value;        }

        public T GetValueOrDefault() => HasValue ? _value : default(T);
        public T GetValueOrDefault(T defaultValue) => HasValue ? _value : defaultValue;

        public TResult SelectOrElse<TResult>(Func<T, TResult> map, Func<TResult> elseMap) {
            return HasValue ? map(_value) : elseMap();
        }

        public void Do(Action<T> doAction) {
            if (HasValue) {
                doAction(_value);
            }
        }

        public void DoOrElse(Action<T> doAction, Action elseAction) {
            if (HasValue) {
                doAction(_value);
            } else {
                elseAction();
            }
        }

        public T OrElse(Func<T> elseMap) {
            return HasValue ? _value : elseMap();
        }

        public void OrElseDo(Action elseAction) {
            if (!HasValue) {
                elseAction();
            }
        }

        #endregion
    }
}
