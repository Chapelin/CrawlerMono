using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
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

        [Fact]
        public void SimplePathCalculator_WhenCallingFinPath_WithSameOriginAnTarget_ReturnEmptyList()
        {
            // Actors
            var origin = new Vector2(5, 5);

            // Actions
            var result = this.pathCalculator.FindPath(origin, origin);

            // Asserts
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        #endregion FindPath
    }
}
