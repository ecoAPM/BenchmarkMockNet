using System;

namespace BenchmarkMockNet
{
   public interface IThingy
   {
      void DoSomething();
      void DoNothing();
      int One();
      int Zero();
      void TwoParameters(string a, Guid b);
      void FourParameters(string a, Guid b, string c, Guid d);
   }
}