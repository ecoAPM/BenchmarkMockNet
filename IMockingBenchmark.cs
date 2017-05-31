namespace BenchmarkMockNet
{
    public interface IMockingBenchmark<out T>
    {
        T Stub();
        T Moq();
        T NSubstitute();
        T FakeItEasy();
        T PCLMock();
        T Rocks();
    }

    public interface IMockingBenchmark
    {
        void Stub();
        void Moq();
        void NSubstitute();
        void FakeItEasy();
        void PCLMock();
        void Rocks();
    }
}