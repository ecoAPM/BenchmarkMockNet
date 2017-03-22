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
                typeof(CallbackOnly),
                typeof(Return),
                typeof(ReturnOnly),
                typeof(Verify),
                typeof(VerifyOnly)
            }).Run();
        }
    }
}