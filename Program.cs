using System.Linq;
using BenchmarkDotNet.Running;
using BenchmarkMockNet.Benchmarks;

namespace BenchmarkMockNet
{
	public static class Program
	{
		private static readonly BenchmarkSwitcher Runner = new(new[]
		{
			typeof(Construction),
			typeof(Callback),
			typeof(EmptyMethod),
			typeof(EmptyReturn),
			typeof(Return),
			typeof(Verify),
			typeof(OneParameter)
		});

		public static void Main(string[] args)
		{
			BenchmarkTests.RunAll();
			if (args.Any(a => a.Contains("filter")))
				Runner.Run(args);
			else
				Runner.RunAll();
		}
	}
}