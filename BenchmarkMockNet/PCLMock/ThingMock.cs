using PCLMock;

namespace BenchmarkMockNet.PCLMock;

// you wouldn't normally write this by hand, but would instead use one of the code generators provided by PCLMock
public sealed class ThingMock : MockBase<IThing>, IThing
{
	public ThingMock(MockBehavior behavior = MockBehavior.Strict)
		: base(behavior)
	{
	}

	public void DoNothing() => Apply(x => x.DoNothing());

	public void DoSomething() => Apply(x => x.DoSomething());

	public int One() => Apply(x => x.One());

	public int Zero() => Apply(x => x.Zero());

	public void OneParameter(int a) => Apply(x => x.OneParameter(a));
}
