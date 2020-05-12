﻿using System;

namespace BoringVector

{
    internal static class VectorExtensions
    {
        private const double EPS = 1e-6;

        public enum VectorRelation : byte
        {
            General,
            Parallel,
            Orthogonal
        }

        public static bool IsZero(Vector v)
        {
            return v.SquareLength() < EPS * EPS;
        }

        public static Vector Normalize(Vector v)
        {
            double length = Math.Sqrt(v.SquareLength());
            return v / length;
        }

        public static double GetAngleBetween(Vector v, Vector u)
        {
            if (IsZero(v) || IsZero(u))
            {
                return 0.0;
            }

            double vLength = Math.Sqrt(v.SquareLength()); 
            double uLength = Math.Sqrt(u.SquareLength());

            return Math.Acos(v.DotProduct(u) / vLength / uLength);
        }

        public static VectorRelation GetRelation(Vector v, Vector u)
        {
            if (v.DotProduct(u) < EPS)
            {
                return VectorRelation.Orthogonal;
            }

            if (v.CrossProduct(u) < EPS)
            {
                return VectorRelation.Parallel;
            }

            return VectorRelation.General;
        }
    }
}
