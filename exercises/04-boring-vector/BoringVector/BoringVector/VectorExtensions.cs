using System;

namespace BoringVector
{
    internal enum VectorRelation
    {
        General = 0,
        Parallel = 1,
        Orthogonal = 2
    }

    internal static class VectorExtenstions
    {
        private const double EPS = 1e-6;

        public static bool IsZero(this Vector v) => Math.Abs(v.X) < EPS && Math.Abs(v.Y) < EPS;

        public static double Length(this Vector v) => Math.Sqrt(v.SquareLength());

        public static void Normalize(this Vector v)
        {
            v = v / Math.Sqrt(v.SquareLength());
        }

        public static double GetAngleBetween(this Vector v, Vector u)
        {
            if (v.IsZero() || u.IsZero())
            {
                return 0;
            }

            return Math.Acos(v.DotProduct(u) / (v.Length() * u.Length()));
        }

        public static VectorRelation GetRelation(this Vector v, Vector u)
        {
            if (v.DotProduct(u) < EPS)
            {
                return VectorRelation.Orthogonal;
            }
            else if (v.CrossProduct(u) < EPS)
            {
                return VectorRelation.Parallel;
            }

            return VectorRelation.General;
        }
    }
}
