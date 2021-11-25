using System.ComponentModel;
using System.IO.Abstractions;
using System.Text;
using BenchmarkMockNet.Benchmarks;

namespace BenchmarkMockNet;

public class Report
{
	private readonly StringBuilder _output;
	private readonly IFileSystem _fs;

	public Report(IFileSystem fs)
	{
		_fs = fs;
		_output = new StringBuilder();
	}

	public async Task Save()
	{
		_output.AppendLine("# BenchmarkMockNet Results");
		_output.AppendLine();

		_output.AppendLine($"## Official Run: {DateTime.Today:d}");
		_output.AppendLine();

		ListFrameworks();
		_output.AppendLine();

		await OutputResults();
		await _fs.File.WriteAllTextAsync("Results.md", _output.ToString());
	}

	private async Task OutputResults()
	{
		foreach (var benchmark in All.Benchmarks)
		{
			_output.AppendLine($"### {benchmark.Name}");
			_output.AppendLine();

			var description = benchmark.CustomAttributes.First(a => a.AttributeType == typeof(DescriptionAttribute));
			_output.AppendLine(description.ConstructorArguments.First().Value?.ToString());

			var file = Path.Combine("BenchmarkDotNet.Artifacts", "results", $"{benchmark.FullName}-report-github.md");
			var content = await _fs.File.ReadAllTextAsync(file);
			var table = content.Split("```").Last().Replace(content, "")
				.Replace(" ns", "\u202Fns")
				.Replace(" B", "\u202FB");

			_output.AppendLine(table);
		}
	}

	private void ListFrameworks()
	{
		_output.AppendLine("| Framework | Version |");
		_output.AppendLine("|-----------|---------|");
		foreach (var framework in All.Frameworks)
		{
			_output.AppendLine($"| {framework.Name} | {framework.Version} |");
		}
	}
}