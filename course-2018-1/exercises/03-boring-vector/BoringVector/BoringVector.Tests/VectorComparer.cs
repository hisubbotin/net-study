using System;
using System.Collections.Generic;

namespace BoringVector.Tests {
    
    /// <summary>
    /// Класс для сравнения экземпляров класса вектор во фреймворке Xunit.
    /// </summary>
    internal class VectorComparer : IEqualityComparer<Vector> {
        
        /// <summary>
        /// Реализует метод Compare из интерфейса IEqualityComparer.
        /// </summary>
        /// <param name="u">Первый вектор.</param>
        /// <param name="v">Второй вектор.</param>
        /// <returns>Являеюстся ли векторы равными.</returns>
        public bool Equals(Vector u, Vector v) {
            return Math.Abs(u.X - v.X) < Vector.Epsilon && Math.Abs(u.Y - v.Y) < Vector.Epsilon;
        }
        
        /// <summary>
        /// Заглушка для хеш-кода вектора. Не нужна.
        /// </summary>
        /// <param name="u">Вектор.</param>
        /// <returns>0.</returns>
        public int GetHashCode(Vector u) {
            return 0;
        }
    }
}
