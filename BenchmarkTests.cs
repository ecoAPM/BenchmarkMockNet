using System;
using BenchmarkMockNet.Benchmarks;

namespace BenchmarkMockNet
{
    public class BenchmarkTests
    {
        public void RunAll()
        {
            new Construction().Run();
            new Callback().Run(true);
            new EmptyMethod().Run();
            new EmptyReturn().Run(0);
            new Return().Run(1);
            new Verify().Run();
            new CallbackOnly().Run(true);
            new EmptyMethodOnly().Run();
            new EmptyReturnOnly().Run(0);
            new ReturnOnly().Run(1);
            new VerifyOnly().Run();
        }
    }

    public static class BenchmarkTestHelpers
    {
        public static void Run<T>(this IMockingBenchmark<T> benchmark, T expected)
        {
            test(benchmark.GetType().Name, "Stub", () => benchmark.Stub().Equals(expected));
            test(benchmark.GetType().Name, "Moq", () => benchmark.Moq().Equals(expected));
            test(benchmark.GetType().Name, "NSubstitute", () => benchmark.NSubstitute().Equals(expected));
            test(benchmark.GetType().Name, "FakeItEasy", () => benchmark.FakeItEasy().Equals(expected));
        }

        private static void test(string test, string type, Func<bool> pass)
        {
            if (!pass())
                throw new Exception($"{type} failed {test}");
        }

        public static void Run<T>(this IMockingBenchmark<T> benchmark)
        {
            test(benchmark.GetType().Name, "Stub", () => benchmark.Stub() is IThingy);
            test(benchmark.GetType().Name, "Moq", () => benchmark.Moq() is IThingy);
            test(benchmark.GetType().Name, "NSubstitute", () => benchmark.NSubstitute() is IThingy);
            test(benchmark.GetType().Name, "FakeItEasy", () => benchmark.FakeItEasy() is IThingy);
        }

        public static void Run(this IMockingBenchmark benchmark)
        {
            benchmark.Stub();
            benchmark.Moq();
            benchmark.NSubstitute();
            benchmark.FakeItEasy();
        }
    }
}
