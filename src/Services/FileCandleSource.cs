using CandleRangeAnalyzer.Interfaces;
using CandleRangeAnalyzer.Models;
using Microsoft.Extensions.Logging;
using System.Globalization;

namespace CandleRangeAnalyzer.Services
{
    public class FileCandleSource : ICandleSource
    {
      //  public event Action<Candle> OnNewCandle;
        public event Action<Candle> OnNewCandle = delegate { };


        private readonly string _filePath;
        private readonly ILogger<FileCandleSource> _logger;

        public FileCandleSource(string filePath, ILogger<FileCandleSource> logger)
        {
            _filePath = filePath;
            _logger = logger;
        }

        public void Start()
        {
            _logger.LogInformation("Starting candle feed from file: {FilePath}", _filePath);

            foreach (var line in File.ReadLines(_filePath).Skip(1))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    _logger.LogWarning("Skipping empty line in CSV");
                    continue;
                }

                var parts = line.Split(',');

                if (parts.Length < 5)
                {
                    _logger.LogError("Malformed CSV line: {Line}", line);
                    continue;
                }

                var candle = new Candle
                {
                    Time = DateTime.Parse(parts[0]),
                    Open = decimal.Parse(parts[1], CultureInfo.InvariantCulture),
                    High = decimal.Parse(parts[2], CultureInfo.InvariantCulture),
                    Low = decimal.Parse(parts[3], CultureInfo.InvariantCulture),
                    Close = decimal.Parse(parts[4], CultureInfo.InvariantCulture)
                };

                _logger.LogDebug(
                    "Parsed candle: {Time} O:{Open} H:{High} L:{Low} C:{Close}",
                    candle.Time, candle.Open, candle.High, candle.Low, candle.Close
                );

                OnNewCandle?.Invoke(candle);
            }

            _logger.LogInformation("Completed reading candle file: {FilePath}", _filePath);
        }
    }
}