using NUnit.Framework;
using CandleRangeAnalyzer.Models;

namespace CandleRangeAnalyzer.Tests.NUnit
{
    [TestFixture]
    public class CandleTest_BullishBearish
    {
        [Test]
        public void Candle_Should_Be_Bullish_When_Close_Is_Greater_Than_Open()
        {
            var candle = new Candle { Open = 10m, Close = 12m };
            Assert.That(candle.IsBullish, Is.True);
            Assert.That(candle.IsBearish, Is.False);
        }

        [Test]
        public void Candle_Should_Be_Bearish_When_Close_Is_Lower_Than_Open()
        {
            var candle = new Candle { Open = 15m, Close = 10m };
            Assert.That(candle.IsBearish, Is.True);
            Assert.That(candle.IsBullish, Is.False);
        }
    }
}