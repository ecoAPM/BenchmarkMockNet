using BenchmarkMockNet.Benchmarks;
using Xunit;

namespace BenchmarkMockNet.Tests;

public class BenchmarkTests
{
	private static readonly Dictionary<Type, Func<object?, bool>> Benchmarks = new()
	{
		{ typeof(Construction), result => result is IThing },
		{ typeof(Callback), result => result is true },
		{ typeof(EmptyMethod), result => result is null },
		{ typeof(EmptyReturn), result => result is 0 },
		{ typeof(OneParameter), result => result is null },
		{ typeof(Return), result => result is 1 },
		{ typeof(Verify), result => result is null }
	};

	public static TheoryData<Type, string> BenchmarkData
	{
		get
		{
			var methods = typeof(IMockingBenchmark).GetMethods();
			var matrix = new TheoryData<Type, string>();
			foreach (var benchmark in Benchmarks)
			{
				foreach (var method in methods)
				{
					matrix.Add(benchmark.Key, method.Name);
				}
			}

			return matrix;
		}
	}

	[Theory]
	[MemberData(nameof(BenchmarkData))]
	public void RunAll(Type type, string library)
	{
		//arrange
		var benchmark = Activator.CreateInstance(type);
		var method = type.GetMethod(library);

		//act
		var result = method?.Invoke(benchmark, []);

		//assert
		var assertion = Benchmarks[type];
		Assert.True(assertion(result));
	}
}