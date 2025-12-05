using System.ComponentModel;
using System.IO.Abstractions;
using System.Text;
using System.Xml.Linq;

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

		await ListFrameworks();
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
			_output.AppendLine(description.ConstructorArguments[0].Value?.ToString());

			var file = Path.Combine("BenchmarkDotNet.Artifacts", "results", $"{benchmark.FullName}-report-github.md");
			var content = await _fs.File.ReadAllTextAsync(file);
			var sections = content.Split("```");
			var table = sections[^1].Replace(content, "")
				.Replace(" ns", "\u202Fns")
				.Replace(" B", "\u202FB");

			_output.AppendLine(table);
		}
	}

	private async Task ListFrameworks()
	{
		var deps = await GetDependencies();
		var matches = deps
			.Where(f => All.Frameworks.Any(a => a.Name!.Contains(f.Key) || f.Key.Contains(a.Name)))
			.OrderBy(f => f.Key);

		_output.AppendLine("| Framework | Version |");
		_output.AppendLine("|-----------|---------|");
		foreach (var (name, version) in matches)
		{
			_output.AppendLine($"| {name} | {version} |");
		}
	}

	private async Task<IDictionary<string, string>> GetDependencies()
	{
		var text = await _fs.File.ReadAllTextAsync("../../../../BenchmarkMockNet.csproj");
		var xml = XDocument.Parse(text);
		return xml.Root!.Descendants("PackageReference")
			.ToDictionary(p => p.Attribute("Include")!.Value, p => p.Attribute("Version")!.Value);
	}
}