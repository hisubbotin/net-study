using System;

namespace CallMeMaybe.V1
{
    /// <summary>
    /// Представляет универсальную обертку над ссылочным (в отличие от <see cref="System.Nullable"/>) или значимым типом, 
    /// которая может содержать или не содержать значение. 
    /// </summary>
    /// <typeparam name="T">Тип содержимого</typeparam>
    public struct Maybe<T> 
    {
        /*
            Maybe - структура по той же причине, по какой и System.Nullable - структура.
        */

        /// <summary>
        /// Нужен, так как у структур нет null.
        /// Объект будет создан один на весь класс. При этом разные подстановки дженерика - разные классы.
        /// </summary>
        public static readonly Maybe<T> Nothing = new Maybe<T>();

        public bool HasValue { get; }

        private readonly T _value;

        public T Value =>
            HasValue ? _value : throw new InvalidOperationException($"{typeof(Maybe<T>)} doesn't have value.");

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
            return value == null ? Nothing : new Maybe<T>(value);
        }

        #region Optional useful methods

        public static explicit operator T(Maybe<T> maybe)
        {
            return maybe.Value;
        }

        public T GetValueOrDefault() => GetValueOrDefault(default(T));
        public T GetValueOrDefault(T defaultValue) => HasValue ? _value : defaultValue;

        public Maybe<TResult> Select<TResult>(Func<T, TResult> map)
        {
            return HasValue ? map(_value) : Maybe<TResult>.Nothing;
        }

        public Maybe<TResult> Select<TResult>(Func<T, Maybe<TResult>> maybeMap)
        {
            return HasValue ? maybeMap(_value) : Maybe<TResult>.Nothing;
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