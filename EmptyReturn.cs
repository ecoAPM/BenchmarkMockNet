using BenchmarkDotNet.Attributes;
using FakeItEasy;
using Moq;
using NSubstitute;
using Rocks;

namespace BenchmarkMockNet
{
    public class EmptyReturn : IMockingBenchmark<int>
    {
        [Benchmark(Baseline = true)]
        public int Stub()
        {
            var stub = new ThingStub();
            return stub.One();
        }

        [Benchmark]
        public int Moq()
        {
            var mock = new Mock<IThingy>();
            return mock.Object.One();
        }

        [Benchmark]
        public int NSubstitute()
        {
            var sub = Substitute.For<IThingy>();
            return sub.One();
        }

        [Benchmark]
        public int FakeItEasy()
        {
            var fake = A.Fake<IThingy>();
            return fake.One();
        }

        [Benchmark]
        public int Rocks()
        {
            var rock = Rock.Create<IThingy>();
            rock.Handle(_ => _.One());
            return rock.Make().One();
        }
    }
}