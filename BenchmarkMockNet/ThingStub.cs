namespace BenchmarkMockNet;

public class ThingStub : IThing
{
	public bool Called { get; private set; }

	public void DoSomething() => Called = true;

	public void DoNothing()
	{
		//this page intentionally left blank
	}

	public int One() => 1;

	public int Zero() => 0;

	public void OneParameter(int a)
	{
		//this page intentionally left blank
	}
}
