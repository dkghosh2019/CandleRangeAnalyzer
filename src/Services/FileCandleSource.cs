using CandleRangeAnalyzer.Interfaces;
using CandleRangeAnalyzer.Models;

namespace CandleRangeAnalyzer.Services
{
    public class FileCandleSource : ICandleSource
    {
        public event Action<Candle> OnNewCandle;

        private readonly string _filePath;

        public FileCandleSource(string filePath)
        {
            _filePath = filePath;
        }

        public void Start()
        {
            foreach (var line in File.ReadLines(_filePath).Skip(1))
            {
                var parts = line.Split(',');

                var candle = new Candle
                {
                    Time = DateTime.Parse(parts[0]),
                    Open = double.Parse(parts[1]),
                    High = double.Parse(parts[2]),
                    Low = double.Parse(parts[3]),
                    Close = double.Parse(parts[4])
                };

                OnNewCandle?.Invoke(candle);
            }
        }
    }
}