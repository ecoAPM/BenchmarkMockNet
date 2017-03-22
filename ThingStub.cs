namespace BenchmarkMockNet
{
    public class ThingStub : IThingy
    {
        public bool Called { get; set; }

        public void Do()
        {
            Called = true;
        }

        public int One()
        {
            return 1;
        }
    }
}