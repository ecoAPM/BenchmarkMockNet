namespace BenchmarkMockNet;

public interface IMockingBenchmark<out T>
{
	T Stub();
	T JustMockLite();
	T Moq();
	T NSubstitute();
	T FakeItEasy();
	T Rocks();
	T PCLMock();
}

public interface IMockingBenchmark
{
	void Stub();
	void JustMockLite();
	void Moq();
	void NSubstitute();
	void FakeItEasy();
	void Rocks();
	void PCLMock();
}