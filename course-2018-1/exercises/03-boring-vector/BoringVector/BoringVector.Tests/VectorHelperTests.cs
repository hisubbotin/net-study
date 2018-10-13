using System;
using System.Collections.Generic;
using Xunit;

namespace BoringVector.Tests {
    /// <summary>
    /// Класс, содержащий тесты для методов класса BoringVector.VectorHelper.
    /// </summary>
    public class VectorHelperTests {
        /// <summary>
        /// Тесты на метод IsZero.
        /// </summary>
        [Fact]
        public void TestIsZero() {
            Assert.True(new Vector().IsZero());
            Assert.True(new Vector(Vector.Epsilon / 2).IsZero());
            Assert.False(new Vector(1, 2).IsZero());
        }

        /// <summary>
        /// Тесты на метод Normalize.
        /// </summary>
        [Fact]
        public void TestNormalize() {
            Assert.Equal(new Vector(1), new Vector(2).Normalize(), new VectorComparer());
            Assert.Equal(new Vector(0.6, 0.8), new Vector(3, 4).Normalize(), new VectorComparer());
            Assert.Equal(new Vector(0.6, 0.8), new Vector(0.6, 0.8).Normalize(), new VectorComparer());
        }

        /// <summary>
        /// Тесты на метод GetAngleBetween.
        /// </summary>
        [Fact]
        public void TestGetAngleBetween() {
            Assert.Equal(Math.PI / 6, new Vector(1).GetAngleBetween(new Vector(Math.Cos(Math.PI / 6), Math.Sin(Math.PI / 6))), Precision.Value);
            Assert.Equal(0, new Vector(1, 2).GetAngleBetween(new Vector(1, 2)), Precision.Value);
            Assert.Equal(Math.PI, new Vector(-2, -1).GetAngleBetween(new Vector(2, 1)), Precision.Value);
            Assert.Equal(0, new Vector().GetAngleBetween(new Vector(2, 1)), Precision.Value);
            Assert.Equal(0, new Vector().GetAngleBetween(new Vector()), Precision.Value);
            Assert.Equal(0, new Vector(1, 2).GetAngleBetween(new Vector()), Precision.Value);
            Assert.Equal(Math.PI / 2, new Vector(1, 2).GetAngleBetween(new Vector(-2, 1)), Precision.Value);
        }

        /// <summary>
        /// Тесты на метод GetRelation.
        /// </summary>
        [Fact]
        public void GetRelation() {
            Assert.Equal(Vector.VectorRelation.General, new Vector(1, 2).GetRelation(new Vector(2, 1)));
            Assert.Equal(Vector.VectorRelation.Parallel, new Vector(1, 2).GetRelation(new Vector(1, 2)));
            Assert.Equal(Vector.VectorRelation.Parallel, new Vector(-2, -1).GetRelation(new Vector(2, 1)));
            Assert.Equal(Vector.VectorRelation.Orthogonal, new Vector().GetRelation(new Vector(2, 1)));
            Assert.Equal(Vector.VectorRelation.Orthogonal, new Vector().GetRelation(new Vector()));
            Assert.Equal(Vector.VectorRelation.Orthogonal, new Vector(1, 2).GetRelation(new Vector()));
            Assert.Equal(Vector.VectorRelation.Orthogonal, new Vector(1, 2).GetRelation(new Vector(-2, 1)));
        }
    }
}
