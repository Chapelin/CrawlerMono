using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Xunit;

namespace Crawler.Utils.Tests
{
    public class SimplePathCalculatorTests
    {

        #region Fields

        private SimplePathCalculator pathCalculator;

        #endregion Fields

        #region Ctor

        public SimplePathCalculatorTests()
        {
            this.pathCalculator = new SimplePathCalculator();
        }

        #endregion Ctor

        #region FindPath

        #region TestData

        public static IEnumerable<Object[]> OneHigher
        {
            get
            {
                var expectedPath = new List<Vector2>();
                expectedPath.Add(new Vector2(0,1));
                yield return new object[] { Vector2.Zero, Vector2.UnitY, expectedPath };
            }
        }

        public static IEnumerable<Object[]> FullLeft
        {
            get
            {
                var expectedPath = new List<Vector2>();
                expectedPath.Add(new Vector2(-1, 0));
                expectedPath.Add(new Vector2(-1, 0));
                expectedPath.Add(new Vector2(-1, 0));
                expectedPath.Add(new Vector2(-1, 0));
                expectedPath.Add(new Vector2(-1, 0));
                expectedPath.Add(new Vector2(-1, 0));
                yield return new object[] { new Vector2(5,0), new Vector2(-1,0), expectedPath };
            }
        }

        public static IEnumerable<Object[]> Diagonal
        {
            get
            {
                var expectedPath = new List<Vector2>();
                expectedPath.Add(new Vector2(-1, -1));
                expectedPath.Add(new Vector2(-1, -1));
                expectedPath.Add(new Vector2(-1, -1));
                yield return new object[] { new Vector2(3, 3), Vector2.Zero, expectedPath };
            }
        }

        public static IEnumerable<Object[]> Fuzzy
        {
            get
            {
                var expectedPath = new List<Vector2>();
                expectedPath.Add(new Vector2(-1, 1));
                expectedPath.Add(new Vector2(-1, 1));
                expectedPath.Add(new Vector2(0, 1));
                expectedPath.Add(new Vector2(0, 1));
                yield return new object[] { new Vector2(7, -1), new Vector2(5,3), expectedPath };
            }
        }
            #endregion TestData

        [Fact]
        public void SimplePathCalculator_WhenCallingFindPath_WithSameOriginAnTarget_ReturnEmptyList()
        {
            // Actors
            var origin = new Vector2(5, 5);

            // Actions
            var result = this.pathCalculator.FindPath(origin, origin);

            // Asserts
            Assert.NotNull(result);
            Assert.Empty(result);
        }


        [Theory]
        [MemberData("OneHigher")]
        [MemberData("FullLeft")]
        [MemberData("Diagonal")]
        [MemberData("Fuzzy")]
        public void SimplePathCalculator_WhenCallingFindPath_ReturnsGoodValue(Vector2 start, Vector2 end,
            List<Vector2> expectedPAth)
        {
            var result = this.pathCalculator.FindPath(start, end);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(expectedPAth,result);
        }

        #endregion FindPath
    }
}
