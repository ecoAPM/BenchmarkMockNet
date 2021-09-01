using BenchmarkDotNet.Attributes;
using BenchmarkMockNet.PCLMock;
using FakeItEasy;
using Moq;
using NSubstitute;
using Rocks;

namespace BenchmarkMockNet.Benchmarks
{
   public class Return : MockingBenchmark<int>
   {
      [Benchmark(Baseline = true)]
      public override int Stub()
      {
         var stub = new ThingStub();
         return stub.One();
      }

      [Benchmark]
      public override int FakeItEasy()
      {
         var fake = A.Fake<IThingy>();
         A.CallTo(() => fake.One()).Returns(1);
         return fake.One();
      }

      [Benchmark]
      public override int Moq()
      {
         var mock = new Mock<IThingy>();
         mock.Setup(m => m.One()).Returns(1);
         return mock.Object.One();
      }

      [Benchmark]
      public override int NSubstitute()
      {
         var sub = Substitute.For<IThingy>();
         sub.One().Returns(1);
         return sub.One();
      }

      [Benchmark]
      public override int PCLMock()
      {
         var mock = new ThingyMock();
         mock.When(x => x.One()).Return(1);
         return mock.One();
      }

      [Benchmark]
      public override int Rocks()
      {
         var rock = Rock.Create<IThingy>();
         rock.Methods().One().Returns(1);
         return rock.Instance().One();
      }
   }
}