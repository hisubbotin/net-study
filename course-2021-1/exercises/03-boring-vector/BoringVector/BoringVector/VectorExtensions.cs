﻿using System;

namespace BoringVector
{
    /*
        Здесь тебе нужно написать класс с методами-расширениями структуры Vector:
            - IsZero: проверяет, является ли вектор нулевым, т.е. его координаты близки к нулю (в эпсилон окрестности). За эпсилон здесь и далее берем 1e-6.
            - Normalize: нормализует вектор
            - GetAngleBetween: возвращает угол между двумя векторами в радианах. Примечание: нулевой вектор сонаправлен любому другому.
            - GetRelation: возвращает значение перечесления VectorRelation(General, Parallel, Orthogonal) - отношение между двумя векторами("общий случай", параллельны, перпендикулярны). Перечисление задавать тоже тебе)
    */
    class VectorExtencions {
        public enum VectorRelation
        {
            General,
            Parallel,
            Orthogonal,
        }
        public bool IsZero(Vector v) {
            double eps = 1e-6;
            return v.SquareLength() < eps;
        }

        public Vector Normalize(Vector v) {
            double length = v.Length();
            return v / length;
        }

        public double GetAngleBetween(Vector v, Vector u) {
            if (IsZero(v) || IsZero(u)) {
                return 0;
            }
            return Math.Acos(v.DotProduct(u) / (v.Length() * u.Length()));
        }

        public VectorRelation GetRelation(Vector v, Vector u) {
            // тут как бы случай 0 - должны быть оба (типо бинарной маски), 
            // но тогда зачам заводить VectorRelation.General
            if (v.CrossProduct(u) == 0) {
                return VectorRelation.Parallel;
            }
            if (v.DotProduct(u) == 0) {
                return VectorRelation.Orthogonal;
            }
            
            return VectorRelation.General;
        }

        protected bool IsZeroEps(double d) {
            double eps = 1e-6;
            return Math.Abs(d) <= eps;
        }
        
    }
    
}
