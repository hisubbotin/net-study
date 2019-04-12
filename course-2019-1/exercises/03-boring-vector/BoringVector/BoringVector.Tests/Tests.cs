using System;
using Xunit;
using BoringVector;

namespace BoringVector.Tests
{
    public class Tests
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 1, 1)]
        [InlineData(3, 4, 25)]
        [InlineData(0, 3, 9)]
        public void Test_SquareLength(double x, double y, double square_length)
        {
            Vector v = new Vector(x, y);
            Assert.Equal(v.SquareLength(), square_length);
        }

        [Theory]
        [InlineData(0, 0, 0, 0, 0, 0)]
        [InlineData(1, 1, 0, 0, 1, 1)]
        [InlineData(1.5, 2.5, 3.5, 4.5, 5, 7)]
        public void Test_Add(
            double x, double y, 
            double add_x, double add_y, 
            double res_x, double res_y) {
                Vector init_v = new Vector(x, y);
                Vector add_v = new Vector(add_x, add_y);
                Vector res_v = new Vector(res_x, res_y);
                Vector sum_v = init_v.Add(add_v);
                Assert.Equal(sum_v, res_v);
        }

        // А можно ли пихнуть в сигнатуру теста Vector? У меня не получилось:(
        [Theory]
        [InlineData(0, 0, 3.1415926, 0, 0)]
        [InlineData(1, 1, 1, 1, 1)]
        [InlineData(4, 2, 0.5, 2, 1)]
        public void Test_Scale(
            double x, double y, 
            double k, 
            double res_x, double res_y) {
                Vector init_v = new Vector(x, y);
                Vector res_v = new Vector(res_x, res_y);
                Vector scl_v = init_v.Scale(k);
                Assert.Equal(scl_v, res_v);
        }

        [Theory]
        [InlineData(0, 0, 0, 0, 0)]
        [InlineData(1, 2, 1, 2, 0)]
        [InlineData(1, 3.17, 2, 6.34, 0)]
        [InlineData(1, 2, 2, 1, -3)]
        public void Test_CrossProduct(
            double x, double y, 
            double oth_x, double oth_y, 
            double cross_product) {
                Vector v = new Vector(x, y);
                Vector oth_v = new Vector(oth_x, oth_y);
                double res = v.CrossProduct(oth_v);
                Assert.Equal(res, cross_product);
        }

        [Theory]
        [InlineData(0, 0, 0, 0, 0)]
        [InlineData(1, 1, 1, 1, 2)]
        [InlineData(1, 2, 2, 1, 4)]       
        public void Test_DotProduct(
            double x, double y, 
            double oth_x, double oth_y, 
            double dot_product) {
                Vector v = new Vector(x, y);
                Vector oth_v = new Vector(oth_x, oth_y);
                double res = v.DotProduct(oth_v);
                Assert.Equal(res, dot_product);
        }

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(1, 1, false)]
        [InlineData(1e-7, 1e-8, true)]
        [InlineData(1e-7, 1, false)]
        [InlineData(0, 1, false)]
        public void Test_IsZero(double x, double y, bool is_zero) {
            Vector v = new Vector(x, y);
            Assert.Equal(v.IsZero(), is_zero);
        }

        [Theory]
        [InlineData(0, 0.5, 0, 1)]
        [InlineData(3, 4, 0.6, 0.8)]
        public void Test_Normalize(double x, double y, double x_norm, double y_norm) {
            Vector v = new Vector(x, y);
            Vector v_norm = new Vector(x_norm, y_norm);
            Assert.Equal(v.Normalize(), v_norm);
        }

        [Theory]
        [InlineData(0, 0, 1, 1, 0)]
        [InlineData(1, 1, -1, 1, 1.5707963)]
        [InlineData(1, 0, 1, 1, 0.785398163)]
        public void Test_GetAngleBetween(
            double x, double y, 
            double x_othr, double y_othr, 
            double angle) {
                Vector v = new Vector(x, y);
                Vector v_othr = new Vector(x_othr, y_othr);
                var res = v.GetAngleBetween(v_othr);
                Assert.Equal(res , angle, 6);
            }
        
        [Theory]
        [InlineData(1, 1, -1, 1, VectorRelation.Orthogonal)]
        [InlineData(1, 1, -2, -2, VectorRelation.Parallel)]
        [InlineData(1, 1, 3, 4, VectorRelation.General)]
        public void Test_GetRelation(double x, double y, double x_othr, double y_othr, VectorRelation rel) {
            Vector v = new Vector(x, y);
            Vector v_othr = new Vector(x_othr, y_othr);
            VectorRelation res = v.GetRelation(v_othr);
            Assert.Equal(res, rel);

        }
    }
}
