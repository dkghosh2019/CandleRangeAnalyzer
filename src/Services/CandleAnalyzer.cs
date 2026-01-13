using CandleRangeAnalyzer.Models;

namespace CandleRangeAnalyzer.Services
{
    public class CandleAnalyzer
    {
        public void Process(Candle candle)
        {
            Console.WriteLine(
                $"[{candle.Time}] O:{candle.Open} H:{candle.High} L:{candle.Low} C:{candle.Close} | Range: {candle.Range}"
            );
        }
    }
}