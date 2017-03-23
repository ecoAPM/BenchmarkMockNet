namespace BenchmarkMockNet
{
    public class ThingStub : IThingy
    {
        public bool Called { get; set; }

        public void DoSomething()
        {
            Called = true;
        }

        public void DoNothing()
        {
        }

        public int One()
        {
            return 1;
        }

        public int Zero()
        {
            return 0;
        }
    }
}