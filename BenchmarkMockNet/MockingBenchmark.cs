using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace BenchmarkMockNet;

[MemoryDiagnoser]
[SimpleJob(RunStrategy.ColdStart, 1, 0, 3, 50_000)]
public abstract class MockingBenchmark<T> : IMockingBenchmark<T>
{
	public abstract T FakeItEasy();
	public abstract T Moq();
	public abstract T NSubstitute();
	public abstract T Rocks();
	public abstract T Stub();
	public abstract T PCLMock();
	public abstract T JustMockLite();
}

[MemoryDiagnoser]
[SimpleJob(RunStrategy.ColdStart, 1, 0, 3, 50_000)]
public abstract class MockingBenchmark : IMockingBenchmark
{
	public abstract void Stub();
	public abstract void Moq();
	public abstract void NSubstitute();
	public abstract void FakeItEasy();
	public abstract void Rocks();
	public abstract void PCLMock();
	public abstract void JustMockLite();
}