using CandleRangeAnalyzer.Models;
using Microsoft.Extensions.Logging;

namespace CandleRangeAnalyzer.Services
{
    public class CandleAnalyzer
    {
        private readonly ILogger<CandleAnalyzer> _logger;

        public CandleAnalyzer(ILogger<CandleAnalyzer> logger)
        {
            _logger = logger;
        }

        public void Process(Candle candle)
        {
            _logger.LogInformation(
                "Processing candle: {Time} O:{Open} H:{High} L:{Low} C:{Close} | Range: {Range}",
                candle.Time, candle.Open, candle.High, candle.Low, candle.Close, candle.Range
            );
        }
    }
}