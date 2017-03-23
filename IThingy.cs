namespace BenchmarkMockNet
{
    public interface IThingy
    {
        bool Called { get; set; }
        void DoSomething();
        void DoNothing();
        int One();
        int Zero();
    }
}