using System.IO.Abstractions;
using NSubstitute;
using Xunit;

namespace BenchmarkMockNet.Tests;

public class ReportTests
{
	[Fact]
	public async Task CanWriteReport()
	{
		//arrange
		var fs = Substitute.For<IFileSystem>();
		fs.File.ReadAllTextAsync(Arg.Any<string>()).Returns("test");
		var report = new Report(fs);

		//act
		await report.Save();

		//assert
		await fs.File.Received().WriteAllTextAsync("Results.md", Arg.Any<string>());
	}
}