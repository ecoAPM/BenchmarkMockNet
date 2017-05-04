using System;
using BenchmarkDotNet.Attributes;
using FakeItEasy;
using Moq;
using NSubstitute;

namespace BenchmarkMockNet
{
    public class CallbackOnly : IMockingBenchmark
    {
        private readonly IThingy stub;
        private readonly IThingy mock;
        private readonly IThingy sub;
        private readonly IThingy fake;

        public CallbackOnly()
        {
            stub = new ThingStub();

            var mockSetup = new Mock<IThingy>();
            mockSetup.Setup(m => m.DoSomething()).Callback(() => mockSetup.Object.Called = true);
            mock = mockSetup.Object;

            sub = Substitute.For<IThingy>();
            sub.When(s => s.DoSomething()).Do(c => sub.Called = true);

            var fakey = new Fake<IThingy>();
            fakey.CallsTo(f => f.DoSomething()).Invokes(f => fake.Called = true);
            fake = fakey.FakedObject;
        }

        [Benchmark(Baseline = true)]
        public void Stub() => stub.DoSomething();

        [Benchmark]
        public void Moq() => mock.DoSomething();

        [Benchmark]
        public void NSubstitute() => sub.DoSomething();

        //[Benchmark]
        public void FakeItEasy() => fake.DoSomething();
    }
}