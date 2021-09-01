using BenchmarkDotNet.Attributes;
using BenchmarkMockNet.PCLMock;
using FakeItEasy;
using Moq;
using NSubstitute;
using Rocks;
using System;

namespace BenchmarkMockNet.Benchmarks
{
   public class FourParameters : MockingBenchmark
   {
      private readonly string _a = "a";
      private readonly Guid _b = Guid.NewGuid();
      private readonly string _c = "c";
      private readonly Guid _d = Guid.NewGuid();

      [Benchmark(Baseline = true)]
      public override void Stub()
      {
         var stub = new ThingStub();
         stub.FourParameters(_a, _b, _c, _d);
      }

      [Benchmark]
      public override void FakeItEasy()
      {
         var fake = A.Fake<IThingy>();
         A.CallTo(() => fake.FourParameters(_a, _b, _c, _d));
         fake.FourParameters(_a, _b, _c, _d);
      }

      [Benchmark]
      public override void Moq()
      {
         var mock = new Mock<IThingy>();
         mock.Setup(m => m.FourParameters(_a, _b, _c, _d));
         mock.Object.FourParameters(_a, _b, _c, _d);
      }

      [Benchmark]
      public override void NSubstitute()
      {
         var sub = Substitute.For<IThingy>();
         sub.FourParameters(_a, _b, _c, _d);
      }

      [Benchmark]
      public override void PCLMock()
      {
         var mock = new ThingyMock();
         mock.When(x => x.FourParameters(_a, _b, _c, _d));
         mock.FourParameters(_a, _b, _c, _d);
      }

      [Benchmark]
      public override void Rocks()
      {
         var rock = Rock.Create<IThingy>();
         rock.Methods().FourParameters(_a, _b, _c, _d);
         rock.Instance().FourParameters(_a, _b, _c, _d);
      }
   }
}