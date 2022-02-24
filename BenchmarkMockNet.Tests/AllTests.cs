using Xunit;

namespace BenchmarkMockNet.Tests;

public class AllTests
{
	[Fact]
	public void BenchmarksAreUnique()
	{
		//arrange
		var benchmarks = All.Benchmarks;

		//act
		var unique = benchmarks.DistinctBy(b => b.Name);

		//assert
		Assert.Equal(benchmarks.Length, unique.Count());
	}

	[Fact]
	public void FrameworksAreUnique()
	{
		//arrange
		var frameworks = All.Frameworks;

		//act
		var unique = frameworks.DistinctBy(f => f.Name);

		//assert
		Assert.Equal(frameworks.Length, unique.Count());
	}
}