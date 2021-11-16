using System.Reflection;
using BenchmarkMockNet.Benchmarks;
using FakeItEasy;
using Moq;
using NSubstitute;
using Rocks;
using Callback = BenchmarkMockNet.Benchmarks.Callback;
using JustMock = Telerik.JustMock.Mock;

namespace BenchmarkMockNet;

public static class All
{
	public static readonly Type[] Benchmarks =
	{
		typeof(Construction),
		typeof(Return),
		typeof(EmptyReturn),
		typeof(EmptyMethod),
		typeof(OneParameter),
		typeof(Callback),
		typeof(Verify)
	};

	public static readonly AssemblyName[] Frameworks =
	{
		typeof(Fake).Assembly.GetName(),
		typeof(JustMock).Assembly.GetName(),
		typeof(Mock).Assembly.GetName(),
		typeof(Substitute).Assembly.GetName(),
		typeof(MockBehavior).Assembly.GetName(),
		typeof(Rock).Assembly.GetName()
	};
}