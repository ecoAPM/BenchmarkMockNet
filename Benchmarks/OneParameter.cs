using BenchmarkDotNet.Attributes;
using BenchmarkMockNet.PCLMock;
using FakeItEasy;
using Moq;
using NSubstitute;
using Rocks;
using System;

namespace BenchmarkMockNet.Benchmarks
{
   public class OneParameter : MockingBenchmark
   {
      private readonly string _a = "a";
      private readonly Guid _b = Guid.NewGuid();

      [Benchmark(Baseline = true)]
      public override void Stub()
      {
         var stub = new ThingStub();
         stub.OneParameter(0);
      }

      [Benchmark]
      public override void FakeItEasy()
      {
         var fake = A.Fake<IThingy>();
         fake.OneParameter(0);
      }

      [Benchmark]
      public override void Moq()
      {
         var mock = new Mock<IThingy>();
         mock.Object.OneParameter(0);
      }

      [Benchmark]
      public override void NSubstitute()
      {
         var sub = Substitute.For<IThingy>();
         sub.OneParameter(0);
      }

      [Benchmark]
      public override void PCLMock()
      {
         var mock = new ThingyMock();
         mock.When(x => x.OneParameter(0));
			mock.OneParameter(0);
      }

      [Benchmark]
      public override void Rocks()
      {
         var rock = Rock.Create<IThingy>();
         rock.Methods().OneParameter(0);
         rock.Instance().OneParameter(0);
      }
   }
}