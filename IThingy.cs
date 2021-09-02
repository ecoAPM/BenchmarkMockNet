using System;

namespace BenchmarkMockNet
{
	public interface IThingy
	{
		void DoSomething();
		void DoNothing();
		int One();
		int Zero();
		void OneParameter(int a);
	}
}