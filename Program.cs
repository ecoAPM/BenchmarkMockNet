using BenchmarkDotNet.Running;

namespace BenchmarkMockNet
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<Construction>();
            BenchmarkRunner.Run<CallbackOnly>();
            BenchmarkRunner.Run<ReturnOnly>();
            BenchmarkRunner.Run<Callback>();
            BenchmarkRunner.Run<Return>();
        }
    }
}