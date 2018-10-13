using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BoringVector.Tests")]
namespace BoringVector {

    /// <summary>
    /// Класс, реализующий extension-методы для класса Vector.
    /// </summary>
    internal static class VectorHelper {
        
        /// <summary>
        /// Определяет, является ли вектор нулевым.
        /// </summary>
        /// <param name="u">Проверяемый вектор.</param>
        /// <returns>Является ли вектор нулевым.</returns>
        public static bool IsZero(this Vector u) {
            return Math.Abs(u.X) < Vector.Epsilon && Math.Abs(u.Y) < Vector.Epsilon;
        }
        
        /// <summary>
        /// Нормализует вектор.
        /// </summary>
        /// <param name="u">Вектор, подлежащий норимализации.</param>
        /// <returns>Нормализованный вектор.</returns>
        /// <exception cref="ArgumentException">Происходит, если нормализуемый вектор нулевой.</exception>
        public static Vector Normalize(this Vector u) {
            var length = Math.Sqrt(u.SquareLength());
            if (length < Vector.Epsilon) {
                throw new ArgumentException("Cannot normalize zero vector");
            }

            return u / length;
        }

        /// <summary>
        /// Находит угол между двумя векторами (в радианах).
        /// </summary>
        /// <param name="u">Данный вектор.</param>
        /// <param name="v">Вектор, угол между которым и данным надо найти.</param>
        /// <returns>Угол между векторамию.</returns>
        public static double GetAngleBetween(this Vector u, Vector v) {
            var uLength = Math.Sqrt(u.SquareLength());
            var vLength = Math.Sqrt(v.SquareLength());
            if (uLength < Vector.Epsilon || vLength < Vector.Epsilon) {
                return 0;
            }

            return Math.Acos(u.DotProduct(v) / (uLength * vLength));
        }

        /// <summary>
        /// Определяет отношение между векторами, см. тажкже Vector.VectorRelation.
        /// </summary>
        /// <param name="u">Данный вектор.</param>
        /// <param name="v">Вектор, отношение между которым и данным надо определить.</param>
        /// <returns>Отношение между векторами.</returns>
        public static Vector.VectorRelation GetRelation(this Vector u, Vector v) {
            if (u.IsZero() || v.IsZero()) {
                return Vector.VectorRelation.Orthogonal;
            }
            var absCos = Math.Abs(Math.Cos(u.GetAngleBetween(v)));
            return absCos < Vector.Epsilon ? Vector.VectorRelation.Orthogonal
                : absCos > 1 - Vector.Epsilon ? Vector.VectorRelation.Parallel : Vector.VectorRelation.General;
        }
    }
}
