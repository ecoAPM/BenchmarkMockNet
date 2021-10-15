using BenchmarkDotNet.Attributes;
using BenchmarkMockNet.PCLMock;
using FakeItEasy;
using Moq;
using NSubstitute;
using Rocks;
using TelerikMock = Telerik.JustMock.Mock;

namespace BenchmarkMockNet.Benchmarks
{
	public class EmptyMethod : MockingBenchmark
	{
		[Benchmark(Baseline = true)]
		public override void Stub()
		{
			var stub = new ThingStub();
			stub.DoNothing();
		}

		[Benchmark]
		public override void FakeItEasy()
		{
			var fake = A.Fake<IThing>();
			fake.DoNothing();
		}

		[Benchmark]
		public override void JustMock()
		{
			try
			{
				var thing = TelerikMock.Create<IThing>();
				thing.DoNothing();
			}
			finally
			{
				TelerikMock.Reset();
			}
		}

		[Benchmark]
		public override void Moq()
		{
			var mock = new Mock<IThing>();
			mock.Object.DoNothing();
		}

		[Benchmark]
		public override void NSubstitute()
		{
			var sub = Substitute.For<IThing>();
			sub.DoNothing();
		}

		[Benchmark]
		public override void PCLMock()
		{
			var mock = new ThingMock();
			mock.When(x => x.DoNothing());
			mock.DoNothing();
		}

		[Benchmark]
		public override void Rocks()
		{
			var chunk = Rock.Make<IThing>().Instance();
			chunk.DoNothing();
		}
	}
}