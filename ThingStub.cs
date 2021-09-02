using System;

namespace BenchmarkMockNet
{
	public class ThingStub : IThingy
	{
		public bool Called { get; private set; }

		public void DoSomething() => Called = true;

		public void DoNothing()
		{
		}

		public int One() => 1;

		public int Zero() => 0;

		public void OneParameter(int a) { }
	}
}