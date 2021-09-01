using BenchmarkDotNet.Attributes;
using BenchmarkMockNet.PCLMock;
using FakeItEasy;
using Moq;
using NSubstitute;
using Rocks;
using System;

namespace BenchmarkMockNet.Benchmarks
{
    public class TwoParameters : MockingBenchmark
    {
        private readonly string _a = "a";
        private readonly Guid _b = Guid.NewGuid();

        [Benchmark(Baseline = true)]
        public override void Stub()
        {
            var stub = new ThingStub();
            stub.TwoParameters(_a, _b);
        }

        [Benchmark]
        public override void FakeItEasy()
        {
            var fake = A.Fake<IThingy>();
            A.CallTo(() => fake.TwoParameters(_a, _b));
            fake.TwoParameters(_a, _b);
        }

        [Benchmark]
        public override void Moq()
        {
            var mock = new Mock<IThingy>();
            mock.Setup(m => m.TwoParameters(_a, _b));
            mock.Object.TwoParameters(_a, _b);
        }

        [Benchmark]
        public override void NSubstitute()
        {
            var sub = Substitute.For<IThingy>();
            sub.TwoParameters(_a, _b);
        }

        [Benchmark]
        public override void PCLMock()
        {
            var mock = new ThingyMock();
            mock.When(x => x.TwoParameters(_a, _b));
            mock.TwoParameters(_a, _b);
        }

        [Benchmark]
        public override void Rocks()
        {
            var rock = Rock.Create<IThingy>();
            rock.Methods().TwoParameters(_a, _b);
            rock.Instance().TwoParameters(_a, _b);
        }
    }
}