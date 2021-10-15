using BenchmarkDotNet.Attributes;
using BenchmarkMockNet.PCLMock;
using FakeItEasy;
using Moq;
using NSubstitute;
using Rocks;
using TelerikMock = Telerik.JustMock.Mock;

namespace BenchmarkMockNet.Benchmarks
{
	public class OneParameter : MockingBenchmark
	{
		[Benchmark(Baseline = true)]
		public override void Stub()
		{
			var stub = new ThingStub();
			stub.OneParameter(0);
		}

		[Benchmark]
		public override void FakeItEasy()
		{
			var fake = A.Fake<IThing>();
			fake.OneParameter(0);
		}

		[Benchmark]
		public override void JustMock()
		{
			try
			{
				var thing = TelerikMock.Create<IThing>();
				thing.OneParameter(0);
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
			mock.Object.OneParameter(0);
		}

		[Benchmark]
		public override void NSubstitute()
		{
			var sub = Substitute.For<IThing>();
			sub.OneParameter(0);
		}

		[Benchmark]
		public override void PCLMock()
		{
			var mock = new ThingMock();
			mock.When(x => x.OneParameter(0));
			mock.OneParameter(0);
		}

		[Benchmark]
		public override void Rocks()
		{
			var rock = Rock.Create<IThing>();
			rock.Methods().OneParameter(0);
			rock.Instance().OneParameter(0);
		}
	}
}