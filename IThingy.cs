namespace BenchmarkMockNet
{
    public interface IThingy
    {
        bool Called { get; set; }
        void Do();
        int One();
    }
}