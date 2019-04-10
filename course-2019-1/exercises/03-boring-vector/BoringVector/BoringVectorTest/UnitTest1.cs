using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Xunit;

using BoringVector;

namespace BoringVectorTest
{
    public class UnitTest1
    {
        
        private const double eps = 1e-6;
        [Theory]
        [InlineData(1, 2, 5)]
        [InlineData(3, 4, 25)]
        public void TestLength(double x, double y, double answer)
        {
            var vect = new BoringVector.Vector(x, y);
            Assert.InRange(vect.SquareLength() - answer, -eps, eps);
        }
        
        [Theory]
        [InlineData(1, 2, 3, 4, 4, 6)]
        [InlineData(3, 4, 25, 20, 28, 24)]
        public void TestAdd(double x1, double y1, 
                                double x2, double y2,
                                double ansx, double ansy)
        {
            var vect1 = new BoringVector.Vector(x1, y1);
            var vect2 = new BoringVector.Vector(x2, y2);
            var vectA = new BoringVector.Vector(ansx, ansy);
            Assert.InRange(vect1.Add(vect2).X - vectA.X, -eps, eps);
            Assert.InRange(vect1.Add(vect2).Y - vectA.Y, -eps, eps);
        }
        
        
        [Theory]
        [InlineData(1, 2, 4, 4, 8)]
        [InlineData(3, 4, 20, 60, 80)]
        public void TestScale(double x1, double y1, 
            double k,
            double ansx, double ansy)
        {
            var vect1 = new BoringVector.Vector(x1, y1);
            var vectA = new BoringVector.Vector(ansx, ansy);
            Assert.InRange(vect1.Scale(k).X - vectA.X, -eps, eps);
            Assert.InRange(vect1.Scale(k).Y - vectA.Y, -eps, eps);
        }
        
        
        [Theory]
        [InlineData(1, 2, 3, 4, 11)]
        [InlineData(3, 4, 25, 20, 155)]
        public void TestDotProduct(double x1, double y1, 
            double x2, double y2,
            double ans)
        {
            var vect1 = new BoringVector.Vector(x1, y1);
            var vect2 = new BoringVector.Vector(x2, y2);
            Assert.InRange(vect1.DotProduct(vect2) - ans, -eps, eps);
        }
        
        [Theory]
        [InlineData(1, 2, 3, 4, 2)]
        [InlineData(3, 4, 25, 20, 40)]
        public void TestCrossProduct(double x1, double y1, 
            double x2, double y2,
            double ans)
        {
            var vect1 = new BoringVector.Vector(x1, y1);
            var vect2 = new BoringVector.Vector(x2, y2);
            Assert.InRange(vect1.CrossProduct(vect2) - ans, -eps, eps);
        }
        
        [Theory]
        [InlineData(1, 2, "(1; 2)")]
        [InlineData(3, 4, "(3; 4)")]
        public void TestToString(double x1, double y1, string ans)
        {
            var vect1 = new BoringVector.Vector(x1, y1);
            Assert.Equal(vect1.ToString(), ans);
        }
        
        [Theory]
        [InlineData(eps, eps, true)]
        [InlineData(3, 4, false)]
        public void TestIsZero(double x1, double y1, bool ans)
        {
            var vect1 = new BoringVector.Vector(x1, y1);
            Assert.Equal(vect1.isZero(), ans);
        }
        
        
        [Theory]
        [InlineData(1, 0, 1, 0)]
        [InlineData(3, 4, 0.6, 0.8)]
        public void TestNormalize(double x1, double y1, 
            double ansx, double ansy)
        {
            var vect1 = new BoringVector.Vector(x1, y1);
            var vectA = new BoringVector.Vector(ansx, ansy);
            Assert.InRange(vect1.Normalize().X - vectA.X, -eps, eps);
            Assert.InRange(vect1.Normalize().Y - vectA.Y, -eps, eps);
        }
        
        [Theory]
        [InlineData(1, 0, 1, 0, 0)]
        [InlineData(1, 0, -1, 0, Math.PI)]
        public void TestAngle(double x1, double y1, 
            double x2, double y2,
            double ans)
        {
            var vect1 = new BoringVector.Vector(x1, y1);
            var vect2 = new BoringVector.Vector(x2, y2);
            Assert.InRange(vect1.GetAngleBetween(vect2) - ans, -eps, eps);
        }
        
        
        [Theory]
        [InlineData(1, 0, 1, 0, BoringVector.BoringVectorExtension.VectorRealtion.Parallel)]
        [InlineData(1, 0, 0, 1, BoringVector.BoringVectorExtension.VectorRealtion.Orthogonal)]
        public void TestRelation(double x1, double y1, 
            double x2, double y2,
            BoringVector.BoringVectorExtension.VectorRealtion rel)
        {
            var vect1 = new BoringVector.Vector(x1, y1);
            var vect2 = new BoringVector.Vector(x2, y2);
            Assert.Equal(vect1.GetRelation(vect2), rel);
        }
        
    }
}