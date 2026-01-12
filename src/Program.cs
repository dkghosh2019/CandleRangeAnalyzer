// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;

public class Candle
{
    public double Open { get; set; }
    public double High { get; set; }
    public double Low { get; set; }
    public double Close { get; set; }

    public double Range => High - Low;

    public Candle(double open, double high, double low, double close)
    {
        Open = open;
        High = high;
        Low = low;
        Close = close;
    }
}

class Program
{
    static void Main()
    {
        List<Candle> candles = new List<Candle>
        {
            new Candle(100, 105, 98, 103),
            new Candle(103, 108, 101, 107),
            new Candle(107, 110, 104, 105),
            new Candle(105, 106, 100, 101),
            new Candle(101, 103, 99, 102)
        };

        double averageRange = candles.Average(c => c.Range);
        double maxRange = candles.Max(c => c.Range);
        double minRange = candles.Min(c => c.Range);

        var largestBullish = candles
            .Where(c => c.Close > c.Open)
            .OrderByDescending(c => c.Close - c.Open)
            .FirstOrDefault();

        var largestBearish = candles
            .Where(c => c.Close < c.Open)
            .OrderByDescending(c => c.Open - c.Close)
            .FirstOrDefault();

        Console.WriteLine($"Average Range: {averageRange:F2}");
        Console.WriteLine($"Max Range: {maxRange:F2}");
        Console.WriteLine($"Min Range: {minRange:F2}");

        if (largestBullish != null)
            Console.WriteLine($"Largest Bullish Candle: {largestBullish.Open} → {largestBullish.Close}");

        if (largestBearish != null)
            Console.WriteLine($"Largest Bearish Candle: {largestBearish.Open} → {largestBearish.Close}");
    }
}