using System;
using System.Collections;
using System.Collections.Generic;

namespace CallMeMaybe.V2
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

        public static implicit operator Maybe<T>(T value)
        {
            return value == null ? Nothing : new Maybe<T>(value);
        }

        #region IEnumerable<T> inerface implementation

        /*
            Здесь реализуй интерфейс IEnumerable<T>.
            Про какой подводный камень нужно помнить, когда объекты Maybe<T> используются как объекты типа IEnumerable?
            *Ответ:* Maybe<T> может быть пустой (и методы будут кидать исключения),
            а для IEnumerable типичное поведение - вернуть пустую коллекцию (и все методы корректно работают).
        */

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

        #region Optional useful methods

        public T GetValueOrDefault() => HasValue ? _value : default(T);
        public T GetValueOrDefault(T defaultValue) => HasValue ? _value : defaultValue;

        #endregion
    }
}
