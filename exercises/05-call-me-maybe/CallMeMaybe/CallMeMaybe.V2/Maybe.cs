using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;

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
            return value != null ? new Maybe<T>(value) : Nothing;
        }

        #region IEnumerable<T> inerface implementation

        /*
            Здесь реализуй интерфейс IEnumerable<T>.
            Про какой подводный камень нужно помнить, когда объекты Maybe<T> используются как объекты типа IEnumerable?
        */
        private class Enumerator : IEnumerator<T>
        {
            private Maybe<T> _maybe;
            private bool _start;

            public Enumerator(Maybe<T> maybe)
            {
                this._maybe = maybe;
            }
            public bool MoveNext()
            {
                _start = true;
                return !_maybe.HasValue && !_start;
            }

            public void Reset()
            {
                _start = false;
            }

            public T Current => _maybe.Value;

            object IEnumerator.Current => _maybe.Value;

            public void Dispose()
            {}
        }

        /// <inheritdoc />
        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion


        #region Optional useful methods

        public T GetValueOrDefault() => Value;
        public T GetValueOrDefault(T defaultValue) => HasValue ? Value : defaultValue;

        #endregion
    }
}
