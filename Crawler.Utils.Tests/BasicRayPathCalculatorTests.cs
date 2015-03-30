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

        [Theory]
        [MemberData("SSW1")]
        public void BasicRayPathCalculator_WhenCallingGetPath_WithNormalData_checkReturnsGoodValue(Vector2 origin,
            Vector2 target, List<Vector2> expected)
        {
            var result = this.pathCalculator.FindPath(origin, target);


            Assert.Equal(expected, result);
        }
    }
}