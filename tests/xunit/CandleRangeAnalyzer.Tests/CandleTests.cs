using CandleRangeAnalyzer.Models;
using Xunit;

namespace CandleRangeAnalyzer.Tests
{
    public class CandleTests
    {
        [Fact]
        public void Range_ShouldBeHighMinusLow()
        {
            var candle = new Candle
            {
                High = 120m,
                Low = 100m
            };

            Assert.Equal(20m, candle.Range);
        }
    }
}