using System;

namespace BoringVector
{
    /*
        Здесь тебе нужно написать класс с методами-расширениями структуры Vector:
            - IsZero: проверяет, является ли вектор нулевым, т.е. его координаты близки к нулю (в эпсилон окрестности). За эпсилон здесь и далее берем 1e-6.
            - Normalize: нормализует вектор
            - GetAngleBetween: возвращает угол между двумя векторами в радианах. Примечание: нулевой вектор сонаправлен любому другому.
            - GetRelation: возвращает значение перечесления VectorRelation(General, Parallel, Orthogonal) - отношение между двумя векторами("общий случай", параллельны, перпендикулярны). Перечисление задавать тоже тебе)
    */

    /// <summary>
    /// Класс с методами-расширениями структуры Vector
    /// </summary>
    internal static class VectorExtensions
    {
        /// <summary>
        /// Перечисление, задающее тип отношения между векторами в зависимости от угла между ними
        /// векторы
        /// - параллельны, если угол между ними 0 или 180 градусов
        /// - ортогональны, если угол между ними 90 градусов
        /// - не находятся в каком-то принятом отношении в ином случае
        /// </summary>
        internal enum VectorRelation
        {
            General,
            Parallel,
            Orthogonal
        }

        private static double EPS = 1e-6;
        
        /// <summary>
        /// Возвращает, считается ли поданный на вход вектор нулевым с учетом вычислительной погрешности
        /// </summary>
        /// <param name="v">вектор, проверяемый на равенство нулевому вектору</param>
        /// <returns>считается ли поданный на вход вектор нулевым</returns>
        public static bool IsZero(Vector v)
        {
            return Math.Abs(v.X) < EPS && Math.Abs(v.Y) < EPS;
        }
        
        /// <summary>
        /// Возвращает вектор, сонаправленный с данным, единичной нормы
        /// </summary>
        /// <param name="v">нормируемый вектор</param>
        /// <returns>нормированный вектор</returns>
        public static Vector Normalize(Vector v)
        { 
            return v / Math.Sqrt(v.SquareLength());
        }
        
        /// <summary>
        /// Возвращает угол между двумя векторами.
        /// Если один из векторов нулевой, угол также будет нулевым
        /// </summary>
        /// <param name="v">первый вектор из векторов, угол между которыми считается</param>
        /// <param name="u">второй вектор из векторов, угол между которыми считается</param>
        /// <returns>угол, от 0 до 180 градусов</returns>
        public static double GetAngleBetween(Vector v, Vector u)
        {
            if (IsZero(v) || IsZero(u))
                return 0;
            var vNorm = Normalize(v);
            var uNorm = Normalize(u);

            return Math.Acos(vNorm.DotProduct(uNorm));
        }
        
        /// <summary>
        /// Возвращает тип отношения между векторами в зависимости от угла между ними
        /// <see cref="VectorRelation"/>
        /// </summary>
        /// <param name="v">первый вектор из векторов, для которых выясняется отношение</param>
        /// <param name="u">второй вектор из векторов, для которых выясняется отношение</param>
        /// <returns>тип отношения между векторами в зависимости от угла между ними</returns>
        public static VectorRelation GetRelation(Vector v, Vector u)
        {
            if (IsZero(v) || IsZero(u))
                return 0;
            var vNorm = Normalize(v);
            var uNorm = Normalize(u);
            var dotProduct = vNorm.DotProduct(uNorm);

            if (Math.Abs(dotProduct) < EPS)
                return VectorRelation.Orthogonal;

            if (Math.Abs(dotProduct) - 1 < EPS)
                return VectorRelation.Parallel;
            
            return VectorRelation.General;
        }
    }
}
