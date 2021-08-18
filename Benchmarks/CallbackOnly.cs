using BenchmarkDotNet.Attributes;
using BenchmarkMockNet.PCLMock;
using FakeItEasy;
using Moq;
using NSubstitute;
using Rocks;

namespace BenchmarkMockNet.Benchmarks
{
    public class CallbackOnly : MockingBenchmark<bool>
    {
        private readonly ThingStub _stub;
        private readonly IThingy _fake;
        private readonly IThingy _mock;
        private readonly IThingy _sub;
        private readonly ThingyMock _pcl;
        private readonly IThingy _rock;

        private bool fakeCalled;
        private bool mockCalled;
        private bool subCalled;
        private bool pclCalled;
        private bool rockCalled;

        public CallbackOnly()
        {
            _stub = new ThingStub();

            _fake = A.Fake<IThingy>();
            A.CallTo(() => _fake.DoSomething()).Invokes(f => fakeCalled = true);

            var mockSetup = new Mock<IThingy>();
            mockSetup.Setup(m => m.DoSomething()).Callback(() => mockCalled = true);
            _mock = mockSetup.Object;

            _sub = Substitute.For<IThingy>();
            _sub.When(s => s.DoSomething()).Do(c => subCalled = true);

            var pclMock = new ThingyMock();
            pclMock.When(x => x.DoSomething()).Do(() => pclCalled = true);
            _pcl = pclMock;

            var rock = Rock.Create<IThingy>();
            rock.Methods().DoSomething().Callback(() => rockCalled = true);
            _rock = rock.Instance();
        }

        [Benchmark(Baseline = true)]
        public override bool Stub()
        {
            _stub.Called = false;
            _stub.DoSomething();
            return _stub.Called;
        }

        [Benchmark]
        public override bool FakeItEasy()
        {
            fakeCalled = false;
            _fake.DoSomething();
            return fakeCalled;
        }

        [Benchmark]
        public override bool Moq()
        {
            mockCalled = false;
            _mock.DoSomething();
            return mockCalled;
        }

        [Benchmark]
        public override bool NSubstitute()
        {
            subCalled = false;
            _sub.DoSomething();
            return subCalled;
        }

        [Benchmark]
        public override bool PCLMock()
        {
            pclCalled = false;
            _pcl.DoSomething();
            return pclCalled;
        }

        [Benchmark]
        public override bool Rocks()
        {
            rockCalled = false;
            _rock.DoSomething();
            return rockCalled;
        }
    }
}