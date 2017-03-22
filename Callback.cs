using BenchmarkDotNet.Attributes;
using FakeItEasy;
using Moq;
using NSubstitute;

namespace BenchmarkMockNet
{
    public class Callback : IMockingBenchmark
    {
        [Benchmark(Baseline = true)]
        public void Stub()
        {
            var stub = new ThingStub();
            stub.Do();
        }

        [Benchmark]
        public void Moq()
        {
            var mock = new Mock<IThingy>();
            mock.Setup(m => m.Do()).Callback(() => mock.Object.Called = true);
            mock.Object.Do();
        }

        [Benchmark]
        public void NSubstitute()
        {
            var sub = Substitute.For<IThingy>();
            sub.When(s => s.Do()).Do(c => sub.Called = true);
            sub.Do();
        }

        public void FakeItEasy()
        {
            var fake = A.Fake<IThingy>();
            A.CallTo(() => fake.Do()).Invokes(() => fake.Called = true);
            fake.Do();
        }
    }
}