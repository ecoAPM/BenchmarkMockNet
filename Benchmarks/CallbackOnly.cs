﻿using BenchmarkDotNet.Attributes;
using FakeItEasy;
using Moq;
using NSubstitute;
using Rocks;

namespace BenchmarkMockNet.Benchmarks
{
    public class CallbackOnly : IMockingBenchmark<bool>
    {
        private readonly ThingStub stub;
        private readonly IThingy fake;
        private readonly IThingy mock;
        private readonly IThingy pclMock;
        private readonly IThingy sub;
        private readonly IThingy chunk;
        private bool fakeCalled;
        private bool mockCalled;
        private bool pclmockCalled;
        private bool subCalled;
        private bool rockCalled;

        public CallbackOnly()
        {
            stub = new ThingStub();

            fake = A.Fake<IThingy>();
            A.CallTo(() => fake.DoSomething()).Invokes(f => fakeCalled = true);

            var mockSetup = new Mock<IThingy>();
            mockSetup.Setup(m => m.DoSomething()).Callback(() => mockCalled = true);
            mock = mockSetup.Object;

            var pclMock = new ThingyMock();
            pclMock.When(x => x.DoSomething()).Do(() => pclmockCalled = true);
            this.pclMock = pclMock;

            sub = Substitute.For<IThingy>();
            sub.When(s => s.DoSomething()).Do(c => subCalled = true);

            var rock = Rock.Create<IThingy>();
            rock.Handle(r => r.DoSomething(), () => rockCalled = true);
            chunk = rock.Make();
        }

        [Benchmark(Baseline = true)]
        public bool Stub()
        {
            stub.Called = false;
            stub.DoSomething();
            return stub.Called;
        }

        //[Benchmark]
        public bool FakeItEasy()
        {
            fakeCalled = false;
            fake.DoSomething();
            return fakeCalled;
        }

        [Benchmark]
        public bool Moq()
        {
            mockCalled = false;
            mock.DoSomething();
            return mockCalled;
        }

        [Benchmark]
        public bool NSubstitute()
        {
            subCalled = false;
            sub.DoSomething();
            return subCalled;
        }

        [Benchmark]
        public bool PCLMock()
        {
            pclmockCalled = false;
            pclMock.DoSomething();
            return pclmockCalled;
        }

        [Benchmark]
        public bool Rocks()
        {
            rockCalled = false;
            chunk.DoSomething();
            return rockCalled;
        }
    }
}