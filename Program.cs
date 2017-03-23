using BenchmarkDotNet.Running;

namespace BenchmarkMockNet
{
    public static class Program
    {
        public static void Main(string[] args)
        {
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
            }).Run();
        }
    }
}