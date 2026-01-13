using CandleRangeAnalyzer.Services;

var source = new FileCandleSource("../data.csv");
var analyzer = new CandleAnalyzer();

source.OnNewCandle += analyzer.Process;

source.Start();