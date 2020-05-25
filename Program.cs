using System.Linq;
using BenchmarkDotNet.Running;
using BenchmarkMockNet.Benchmarks;

namespace BenchmarkMockNet
{
    public static class Program
    {
        public const int InvocationCount = 100_000;
        public const int TargetCount = 10;

        public static void Main(string[] args)
        {
            new BenchmarkTests().RunAll();

            var runner = new BenchmarkSwitcher(new[] {
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
            });

            if (args.Any(a => a.Contains("filter")))
                runner.Run(args);
            else
                runner.RunAll();
        }
    }
}
