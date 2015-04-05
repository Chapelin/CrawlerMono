using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Xunit;

namespace Crawler.Utils.Tests
{
    public class UtilitairesTests
    {


        #region test data

        public static IEnumerable<Object[]> Rect1()
        {
            var rect = new Rectangle(0, 0, 1, 1);
            var expected = new List<Vector2>()
            {
                new Vector2(0, 0),
                new Vector2(0, 1),
                new Vector2(1, 1),
                new Vector2(1, 0)
            };
            yield return new object[] { rect, expected };
        }

        public static IEnumerable<Object[]> Rect2()
        {
            var rect = new Rectangle(-1, 1, 2, 5);
            var expected = new List<Vector2>()
            {
                new Vector2(-1, 1),
                new Vector2(0, 1),
                new Vector2(1, 1),
                new Vector2(1, 2),
                new Vector2(1, 3),
                new Vector2(1, 4),
                new Vector2(1, 5),
                new Vector2(1, 6),
                new Vector2(0, 6),
                new Vector2(-1, 6),
                 new Vector2(-1, 2),
                new Vector2(-1, 3),
                new Vector2(-1, 4),
                new Vector2(-1, 5)
            };
            yield return new object[] { rect, expected };
        }

        #endregion test data
        [Theory]
        [MemberData("Rect1")]
        [MemberData("Rect2")]
        public void Utilitaires_WhenCallingRectangleDelimitationCells_CheckReturnsGoodValue(Rectangle input,
            List<Vector2> expected)
        {
            var result = Utilitaires.RectangleDelimitationCells(input);
            Assert.Equal(expected.Count, result.Count);
            foreach (var vectorExpected in expected)
            {
                Assert.Contains(vectorExpected, result);
            }
        }


    }
}
