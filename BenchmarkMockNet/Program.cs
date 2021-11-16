using System.IO.Abstractions;
using BenchmarkDotNet.Running;

namespace BenchmarkMockNet;

public static class Program
{
	public static async Task Main(string[] args)
	{
		var runner = new BenchmarkSwitcher(All.Benchmarks);
		if (args.Any(a => a.Contains("filter")))
		{
			runner.Run(args);
			return;
		}

		runner.RunAll();

		Console.WriteLine("Creating report...");
		var fs = new FileSystem();
		await new Report(fs).Save();
		Console.WriteLine("Done!");
	}
}