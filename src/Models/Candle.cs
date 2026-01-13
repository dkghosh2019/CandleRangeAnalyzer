namespace CandleRangeAnalyzer.Models
{
    public class Candle
    {
        public DateTime Time { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }

        public double Range => High - Low;

        public bool IsBullish => Close > Open;
        public bool IsBearish => Close < Open;
    }
}