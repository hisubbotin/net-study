using System;
using System.Collections.Generic;
using Xunit;

namespace BoringVector.Tests
{
    public class TestBoringVector
    {
	    public static IEnumerable<object[]> SquareLengthData()
	    {
		    yield return new object[] { new Vector(0,0), 0};
		    yield return new object[] { new Vector(1,1), 2 };
		    yield return new object[] { new Vector(2, 2), 8 };
		}

	    [Theory]
	    [MemberData(nameof(SquareLengthData))]
		public static void Test_SquareLength(Object o, double ans)
	    {
		    Vector v = (Vector)o;
			Assert.Equal(ans, v.SquareLength(), VectorExtensions.epsilonDecimalPlaces);
	    }

	    public static IEnumerable<object[]> AddData()
	    {
		    yield return new object[] { new Vector(0, 0), new Vector(1, 2), new Vector(1, 2) };
		    yield return new object[] { new Vector(1, 1), new Vector(3.5, 8), new Vector(4.5, 9) };
		    yield return new object[] { new Vector(2, 2), new Vector(-1, 0), new Vector(1, 2) };
	    }

	    [Theory]
	    [MemberData(nameof(AddData))]
	    public static void Test_Add(Object o1, Object o2, Object o3)
	    {
		    Vector v1 = (Vector) o1;
		    Vector v2 = (Vector)o2;
		    Vector v3 = (Vector)o3;
			Assert.Equal(v1.Add(v2), v3);
		}

	    public static IEnumerable<object[]> ScaleData()
	    {
		    yield return new object[] { new Vector(0, 0), 100500, new Vector(0, 0) };
		    yield return new object[] { new Vector(1, 2), 2, new Vector(2, 4) };
		    yield return new object[] { new Vector(2, 2), 0, new Vector(0, 0) };
	    }

		[Theory]
	    [MemberData(nameof(ScaleData))]
	    public static void Test_Scale(Object o1, double scale, Object o2)
	    {
		    Vector v1 = (Vector)o1;
		    Vector v2 = (Vector)o2;
		    Assert.Equal(v1.Scale(scale), v2);
	    }

	    public static IEnumerable<object[]> DotProductData()
	    {
			yield return new object[] { new Vector(0, 0), new Vector(1, 2), 0 };
		    yield return new object[] { new Vector(1, 1), new Vector(3.5, 8), 11.5 };
		    yield return new object[] { new Vector(2, 2), new Vector(-1, 0), -2 };
		}

	    [Theory]
	    [MemberData(nameof(DotProductData))]
		public static void Test_DotProductObject(Object o1, Object o2, double res)
	    {
		    Vector v1 = (Vector)o1;
		    Vector v2 = (Vector)o2;
		    Assert.Equal(res, v1.DotProduct(v2), VectorExtensions.epsilonDecimalPlaces);
	    }

	    public static IEnumerable<object[]> CrossProductData()
	    {
		    yield return new object[] { new Vector(0, 0), new Vector(1, 2), 0 };
		    yield return new object[] { new Vector(1, 1), new Vector(3.5, 8), 4.5 };
		    yield return new object[] { new Vector(2, 2), new Vector(0, -1), 2 };
	    }

	    [Theory]
	    [MemberData(nameof(CrossProductData))]
	    public static void Test_CrossProduct(Object o1, Object o2, double res)
	    {
		    Vector v1 = (Vector)o1;
		    Vector v2 = (Vector) o2;
		    Assert.Equal(res, v1.CrossProduct(v2), VectorExtensions.epsilonDecimalPlaces);
		}
    }
}
