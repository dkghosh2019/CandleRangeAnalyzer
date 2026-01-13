using CandleRangeAnalyzer.Interfaces;
using CandleRangeAnalyzer.Models;
using System.Globalization;

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
                    Open = decimal.Parse(parts[1], CultureInfo.InvariantCulture),
                    High = decimal.Parse(parts[2], CultureInfo.InvariantCulture),
                    Low = decimal.Parse(parts[3], CultureInfo.InvariantCulture),
                    Close = decimal.Parse(parts[4], CultureInfo.InvariantCulture)
                };

                OnNewCandle?.Invoke(candle);
            }
        }
    }
}