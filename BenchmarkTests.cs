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

    static class BenchmarkTestHelpers
    {
        public static void Run<T>(this IMockingBenchmark<T> benchmark, T expected)
        {
            Test(benchmark.GetType().Name, "Stub", () => benchmark.Stub().Equals(expected));
            Test(benchmark.GetType().Name, "Moq", () => benchmark.Moq().Equals(expected));
            Test(benchmark.GetType().Name, "NSubstitute", () => benchmark.NSubstitute().Equals(expected));
            Test(benchmark.GetType().Name, "FakeItEasy", () => benchmark.FakeItEasy().Equals(expected));
            Test(benchmark.GetType().Name, "Rocks", () => benchmark.Rocks().Equals(expected));
            Test(benchmark.GetType().Name, "PCLMock", () => benchmark.PCLMock().Equals(expected));
        }

        private static void Test(string test, string type, Func<bool> pass)
        {
            if (!pass())
                throw new Exception($"{type} failed {test}");
        }

        public static void Run<T>(this IMockingBenchmark<T> benchmark)
        {
            Test(benchmark.GetType().Name, "Stub", () => benchmark.Stub() is IThingy);
            Test(benchmark.GetType().Name, "Moq", () => benchmark.Moq() is IThingy);
            Test(benchmark.GetType().Name, "NSubstitute", () => benchmark.NSubstitute() is IThingy);
            Test(benchmark.GetType().Name, "FakeItEasy", () => benchmark.FakeItEasy() is IThingy);
            Test(benchmark.GetType().Name, "Rocks", () => benchmark.Rocks() is IThingy);
            Test(benchmark.GetType().Name, "PCLMock", () => benchmark.PCLMock() is IThingy);
        }

        public static void Run(this IMockingBenchmark benchmark)
        {
            benchmark.Stub();
            benchmark.Moq();
            benchmark.NSubstitute();
            benchmark.FakeItEasy();
            benchmark.Rocks();
            benchmark.PCLMock();
        }
    }
}
