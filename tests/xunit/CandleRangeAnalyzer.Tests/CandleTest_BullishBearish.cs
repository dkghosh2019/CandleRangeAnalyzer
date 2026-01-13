using CandleRangeAnalyzer.Models;
using Xunit;

namespace CandleRangeAnalyzer.Tests.XUnit
{
    public class CandleTest_BullishBearish
    {
        [Fact]
        public void Candle_Should_Be_Bullish_When_Close_Is_Greater_Than_Open()
        {
            // Arrange
            var candle = new Candle { Open = 10m, Close = 12m };

            // Act & Assert
            Assert.True(candle.IsBullish);
            Assert.False(candle.IsBearish);
        }

        [Fact]
        public void Candle_Should_Be_Bearish_When_Close_Is_Lower_Than_Open()
        {
            // Arrange
            var candle = new Candle { Open = 15m, Close = 10m };

            // Act & Assert
            Assert.True(candle.IsBearish);
            Assert.False(candle.IsBullish);
        }
    }
}