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

        public static implicit operator Maybe<T>(T value) => (value == null) ? Nothing : new Maybe<T>(value);
        
        #region LINQ syntax providers

        public Maybe<TResult> Select<TResult>(Func<T, TResult> map)=> HasValue ? map(_value) : Maybe<TResult>.Nothing;
 
        public Maybe<TResult> Select<TResult>(Func<T, Maybe<TResult>> maybeMap) => HasValue ? maybeMap(_value) : Maybe<TResult>.Nothing;

        public Maybe<TResult> SelectMany<T2, TResult>(Func<T, Maybe<T2>> otherSelector, Func<T, T2, TResult> resultSelector)
        {
            if (!HasValue)
                return Maybe<TResult>.Nothing;

            Maybe<T2> else_maybe = otherSelector(_value);
            return else_maybe.HasValue ? resultSelector(_value, else_maybe._value) : Maybe<TResult>.Nothing;
        }
        public Maybe<TResult> SelectMany<T2, TResult>(Func<T, Maybe<T2>> otherSelector, Func<T, T2, Maybe<TResult>> maybeResultSelector)
        {
            if (!HasValue)
                return Maybe<TResult>.Nothing;

            Maybe < T2 > else_maybe = otherSelector(_value);
            return else_maybe.HasValue ? maybeResultSelector(_value, else_maybe._value) : Maybe<TResult>.Nothing;
        }
        public Maybe<T> Where(Predicate<T> predicate) => HasValue && predicate(_value) ? _value : Nothing;

        #endregion

        #region Optional useful methods

        public static explicit operator T(Maybe<T> maybe) => maybe.Value;

        public T GetValueOrDefault() => HasValue ? _value : default(T);
        public T GetValueOrDefault(T defaultValue) => HasValue ? _value : defaultValue;

        public TResult SelectOrElse<TResult>(Func<T, TResult> map, Func<TResult> elseMap) => HasValue ? map(_value) : elseMap();

        public void Do(Action<T> doAction)
        {
            if (HasValue)
                doAction(_value);
        }
        public void DoOrElse(Action<T> doAction, Action elseAction)
        {
            if (HasValue)
                doAction(_value);
            else
                elseAction();
        }

        public T OrElse(Func<T> elseMap) => HasValue ? _value : elseMap();
        
        public void OrElse(Action elseAction)
        {
            if (!HasValue)
                elseAction();
        }

        #endregion
    }
}
