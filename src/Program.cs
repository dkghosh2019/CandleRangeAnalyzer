using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CandleRangeAnalyzer.Services;

// Build DI container
var services = new ServiceCollection()
    .AddLogging(builder =>
    {
        builder.ClearProviders();
        builder.AddConsole();
        builder.SetMinimumLevel(LogLevel.Information);
    })
   .AddSingleton<FileCandleSource>(sp =>
    new FileCandleSource("C:/projects/NinjaTrader/C#Programs/CandleRangeAnalyzer/data.csv",
        sp.GetRequiredService<ILogger<FileCandleSource>>()))
    .AddSingleton<CandleAnalyzer>()
    .BuildServiceProvider();

// Resolve services
var source = services.GetRequiredService<FileCandleSource>();
var analyzer = services.GetRequiredService<CandleAnalyzer>();

// Wire events
source.OnNewCandle += analyzer.Process;

// Start feed
source.Start();
