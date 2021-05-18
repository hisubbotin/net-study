namespace BoringVector
{
    /// <summary>
    /// Some useful methods for <see cref="Vector"/>.
    /// </summary>
    internal class VectorExtensions
    {

        /// <summary>
        /// A two-vector reltion.
        /// </summary>
        public enum VectorRelation
        {
            ///<summary> Just two vectors </summary>
            General,
            ///<summary> Parallel (i. e. scaled or duplicate) vectors </summary>
            Parallel,
            ///<summary> Perpendicular vactors </summary>
            Orthogonal
        }

        /// <summary>
        /// Whether a vector is exactly zero.
        /// </summary>
        /// <returns> Is a vector equal to (0; 0)? </returns>
        public bool IsZero(Vector v)
        {
            return v.X == 0 && v.Y == 0;
        }

        /// <summary>
        /// Normalizes the length of a vector to 1.0.
        /// </summary>
        /// <returns> Scaled vector </returns>
        public Vector Normalize(Vector v)
        {
            return v / System.Math.Sqrt(v.SquareLength());
        }

        /// <summary>
        /// Get the angle between two vectors in radians.
        /// </summary>
        /// <returns> The angle in radians from [0; 2π)</returns>
        public double GetAngleBetween(Vector v, Vector u)
        {
            var angle = System.Math.Atan2(u.Y, u.X) - System.Math.Atan2(v.Y, v.X);
            if (angle < 0)
            {
                angle += 2 * System.Math.PI;
            }
            return angle;
        }

        /// <summary>
        /// Get the relation between two vectors - either orthogonal, parallel (or scaled/same) or something else.
        /// </summary>
        /// <returns> A <see cref="VectorRelation"/> relation </returns>
        public VectorRelation GetRelation(Vector v, Vector u)
        {
            if (v.CrossProduct(u) == 0)
            {
                return VectorRelation.Parallel;
            }
            else if (v.DotProduct(u) == 0)
            {
                return VectorRelation.Orthogonal;
            }
            else
            {
                return VectorRelation.General;
            }
        }
    }
}
