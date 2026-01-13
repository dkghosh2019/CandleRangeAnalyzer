namespace CandleRangeAnalyzer.Models
{
    public class Candle
    {
        public DateTime Time { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }

        public decimal Range => High - Low;

        public bool IsBullish => Close > Open;
        public bool IsBearish => Close < Open;
    }
}