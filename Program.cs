using BenchmarkDotNet.Running;
using BenchmarkMockNet.Benchmarks;

namespace BenchmarkMockNet
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            new BenchmarkTests().RunAll();

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
            }).RunAll();
        }
    }
}