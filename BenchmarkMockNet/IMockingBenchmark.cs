namespace BenchmarkMockNet
{
	public interface IMockingBenchmark<out T>
	{
		T Stub();
		T JustMock();
		T Moq();
		T NSubstitute();
		T FakeItEasy();
		T Rocks();
		T PCLMock();
	}

	public interface IMockingBenchmark
	{
		void Stub();
		void JustMock();
		void Moq();
		void NSubstitute();
		void FakeItEasy();
		void Rocks();
		void PCLMock();
	}
}