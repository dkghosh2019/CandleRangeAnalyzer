using NUnit.Framework;
using CandleRangeAnalyzer.Models;

namespace CandleRangeAnalyzer.Tests.NUnit
{
    public class CandleTests
    {
        [Test]
        public void Candle_Should_Calculate_Range_Correctly()
        {
            var candle = new Candle
            {
                Open = 10m,
                High = 15m,
                Low = 8m,
                Close = 12m
            };

            var range = candle.Range;

            Assert.That(range, Is.EqualTo(7m));
        }
    }
}