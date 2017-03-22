namespace BenchmarkMockNet
{
    public interface IMockingBenchmark<out T>
    {
        T Stub();
        T Moq();
        T NSubstitute();
        T FakeItEasy();
    }

    public interface IMockingBenchmark
    {
        void Stub();
        void Moq();
        void NSubstitute();
        void FakeItEasy();
    }
}