using System.Reflection;
using BenchmarkMockNet.Benchmarks;
using Xunit;

namespace BenchmarkMockNet.Tests;

public static class BenchmarkTests
{
	private static readonly MethodInfo[] Methods = typeof(IMockingBenchmark).GetMethods();

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

	public static IEnumerable<object[]> Matrix
	{
		get
		{
			var matrix = new List<object[]>();
			foreach (var benchmark in Benchmarks)
			{
				matrix.AddRange(Methods.Select(method => new object[] { benchmark.Key, method }));
			}

			return matrix;
		}
	}

	[Theory]
	[MemberData(nameof(Matrix))]
	public static void RunAll(Type type, MethodInfo library)
	{
		//arrange
		var benchmark = Activator.CreateInstance(type);
		var method = benchmark?.GetType().GetMethod(library.Name);

		//act
		var result = method?.Invoke(benchmark, Array.Empty<object>());

		//assert
		var assertion = Benchmarks[type];
		Assert.True(assertion(result));
	}
}