using BenchmarkDotNet.Running;
using BenchmarkMockNet.Benchmarks;

namespace BenchmarkMockNet
{
    public static class Program
    {
        public const int InvocationCount = 1_000_000;
        public const int TargetCount = 5;

        public static void Main(string[] args)
        {
            new BenchmarkTests().RunAll();

            if (args.Length == 0)
            {
                // With no options, run all benchmarks at default settings
                args = new[] { "--filter", "*" };
            }

            new BenchmarkSwitcher(new[] {
                typeof(Construction),
                typeof(Callback),
                typeof(EmptyMethod),
                typeof(EmptyReturn),
                typeof(Return),
                typeof(Verify),
                typeof(CallbackOnly),
                typeof(EmptyMethodOnly),
                typeof(EmptyReturnOnly),
                typeof(ReturnOnly),
                typeof(VerifyOnly)
            }).Run(args);
        }
    }
}