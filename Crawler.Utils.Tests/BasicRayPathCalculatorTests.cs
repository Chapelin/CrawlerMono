using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Xunit;

namespace Crawler.Utils.Tests
{
    public class BasicRayPathCalculatorTests
    {
        private BasicRayPathCalculator pathCalculator;

        public BasicRayPathCalculatorTests()
        {
            this.pathCalculator = new BasicRayPathCalculator();
        }

        #region test values

        public static IEnumerable<object[]> S
        {
            get
            {
                var expected = new List<Vector2>();
                expected.Add(new Vector2(0, 1));
                expected.Add(new Vector2(0, 1));
                expected.Add(new Vector2(0, 1));
                yield return new object[] { new Vector2(-5, 0), new Vector2(-5, 3), expected };
            }
        }

        public static IEnumerable<object[]> N
        {
            get
            {
                var expected = new List<Vector2>();
                expected.Add(new Vector2(0, -1));
                expected.Add(new Vector2(0, -1));
                expected.Add(new Vector2(0, -1));
                yield return new object[] { new Vector2(4, 2), new Vector2(4, -1), expected };
            }
        }


        public static IEnumerable<object[]> W
        {
            get
            {
                var expected = new List<Vector2>();
                expected.Add(new Vector2(1, 0));
                expected.Add(new Vector2(1, 0));
                expected.Add(new Vector2(1, 0));
                expected.Add(new Vector2(1, 0));
                yield return new object[] { new Vector2(-5, 1), new Vector2(-1, 1), expected };
            }
        }


        public static IEnumerable<object[]> E
        {
            get
            {
                var expected = new List<Vector2>();
                expected.Add(new Vector2(-1, 0));
                expected.Add(new Vector2(-1, 0));
                yield return new object[] { new Vector2(-5, 1), new Vector2(-7, 1), expected };
            }
        }


        public static IEnumerable<object[]> SW
        {
            get
            {
                var expected = new List<Vector2>();
                expected.Add(new Vector2(1, 1));
                expected.Add(new Vector2(1, 1));
                expected.Add(new Vector2(1, 1));
                expected.Add(new Vector2(1, 1));
                yield return new object[] { new Vector2(1, 1), new Vector2(5, 5), expected };
            }
        }

        public static IEnumerable<object[]> NW
        {
            get
            {
                var expected = new List<Vector2>();
                expected.Add(new Vector2(1, -1));
                yield return new object[] { new Vector2(1, 1), new Vector2(2, 0), expected };
            }
        }


        public static IEnumerable<object[]> SE
        {
            get
            {
                var expected = new List<Vector2>();
                expected.Add(new Vector2(-1, 1));
                yield return new object[] { new Vector2(1, 1), new Vector2(0, 2), expected };
            }
        }

        public static IEnumerable<object[]> NE
        {
            get
            {
                var expected = new List<Vector2>();
                expected.Add(new Vector2(-1, -1));
                expected.Add(new Vector2(-1, -1));
                yield return new object[] { new Vector2(3, 2), new Vector2(1, 0), expected };
            }
        }

        public static IEnumerable<object[]> SSW1
        {
            get
            {
                var expected = new List<Vector2>();
                expected.Add(new Vector2(0, 1));
                expected.Add(new Vector2(0, 1));
                expected.Add(new Vector2(1, 1));
                yield return new object[] { Vector2.Zero, new Vector2(1, 3), expected };
            }
        }

        public static IEnumerable<object[]> SWW1
        {
            get
            {
                var expected = new List<Vector2>();
                expected.Add(new Vector2(1, 0));
                expected.Add(new Vector2(1, 1));
                expected.Add(new Vector2(1, 0));
                yield return new object[] { Vector2.Zero, new Vector2(3, 1), expected };
            }
        }

        public static IEnumerable<object[]> NWW1
        {
            get
            {
                var expected = new List<Vector2>();
                expected.Add(new Vector2(1, 0));
                expected.Add(new Vector2(1, -1));
                expected.Add(new Vector2(1, 0));
                yield return new object[] { Vector2.Zero, new Vector2(3, -1), expected };
            }
        }

        public static IEnumerable<object[]> NNW1
        {
            get
            {
                var expected = new List<Vector2>();
                expected.Add(new Vector2(0, -1));
                expected.Add(new Vector2(0, -1));
                expected.Add(new Vector2(1, -1));
                yield return new object[] { Vector2.Zero, new Vector2(1, -3), expected };
            }
        }

        public static IEnumerable<object[]> NNE1
        {
            get
            {
                var expected = new List<Vector2>();
                expected.Add(new Vector2(0, -1));
                expected.Add(new Vector2(0, -1));
                expected.Add(new Vector2(-1, -1));
                yield return new object[] { Vector2.Zero, new Vector2(-1, -3), expected };
            }
        }

        public static IEnumerable<object[]> NEE1
        {
            get
            {
                var expected = new List<Vector2>();
                expected.Add(new Vector2(-1, 0));
                expected.Add(new Vector2(-1, -1));
                expected.Add(new Vector2(-1, 0));
                yield return new object[] { Vector2.Zero, new Vector2(-3, -1), expected };
            }
        }


        public static IEnumerable<object[]> SSE1
        {
            get
            {
                var expected = new List<Vector2>();
                expected.Add(new Vector2(0, 1));
                expected.Add(new Vector2(0, 1));
                expected.Add(new Vector2(-1, 1));
                yield return new object[] { Vector2.Zero, new Vector2(-1, 3), expected };
            }
        }

        public static IEnumerable<object[]> SEE1
        {
            get
            {
                var expected = new List<Vector2>();
                expected.Add(new Vector2(-1, 0));
                expected.Add(new Vector2(-1, 1));
                expected.Add(new Vector2(-1, 0));
                yield return new object[] { Vector2.Zero, new Vector2(-3, 1), expected };
            }
        }
        #endregion test values

        [Theory]
        [MemberData("SSW1")]
        [MemberData("SWW1")]
        [MemberData("NWW1")]
        [MemberData("NNW1")]
        [MemberData("NNE1")]
        [MemberData("NEE1")]
        [MemberData("SSE1")]
        [MemberData("SEE1")]
        [MemberData("SW")]
        [MemberData("SE")]
        [MemberData("NE")]
        [MemberData("NW")]
        [MemberData("N")]
        [MemberData("S")]
        [MemberData("E")]
        [MemberData("W")]
        public void BasicRayPathCalculator_WhenCallingGetPath_WithNormalData_checkReturnsGoodValue(Vector2 origin,
            Vector2 target, List<Vector2> expected)
        {
            var result = this.pathCalculator.FindPath(origin, target);


            Assert.Equal(expected, result);
        }
    }
}