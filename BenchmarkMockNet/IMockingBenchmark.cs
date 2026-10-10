namespace BenchmarkMockNet;

public interface IMockingBenchmark<out T>
{
	T Stub();
	T JustMockLite();
	T Moq();
	T NSubstitute();
	T FakeItEasy();
	T Imposter();
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
	void Imposter();
	void Rocks();
	void PCLMock();
}