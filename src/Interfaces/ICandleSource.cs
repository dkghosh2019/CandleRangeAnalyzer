namespace CandleRangeAnalyzer.Interfaces
{
    using CandleRangeAnalyzer.Models;

    public interface ICandleSource
    {
        event Action<Candle> OnNewCandle;
        void Start();
    }
}