using PCLMock;
using System;

namespace BenchmarkMockNet.PCLMock
{
    // you wouldn't normally write this by hand, but would instead use one of the code generators provided by PCLMock
    public sealed class ThingyMock : MockBase<IThingy>, IThingy
    {
        public ThingyMock(MockBehavior behavior = MockBehavior.Strict)
            : base(behavior)
        {
        }

        public void DoNothing() =>
            this.Apply(x => x.DoNothing());

        public void DoSomething() =>
            this.Apply(x => x.DoSomething());

        public int One() =>
            this.Apply(x => x.One());

        public int Zero() =>
            this.Apply(x => x.Zero());

        public void TwoParameters(string a, Guid b) =>
            this.Apply(x => x.TwoParameters(a, b));

        public void FourParameters(string a, Guid b, string c, Guid d) =>
            this.Apply(x => x.FourParameters(a, b, c, d));
    }
}