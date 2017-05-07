# BenchmarkMockNet
Using BenchmarkDotNet to compare .NET Core mocking library performance

---

This repo contains the code for -- and results of -- a series of benchmarks around the functionality of some of .NET Core's mocking libraries.

The baseline is a simple [stub](https://github.com/stevedesmond-ca/BenchmarkMockNet/blob/master/ThingStub.cs).

## Current contenders (alphabetical order)
- [FakeItEasy](https://github.com/FakeItEasy/FakeItEasy)
- [Moq](https://github.com/moq/moq4)
- [NSubstitute](http://nsubstitute.github.io/)
- [Rocks](https://github.com/JasonBock/Rocks)

Want to add more? PRs welcome! Just add a method to IMockingBenchmark and IMockingBenchmark<T>, implement it in each of the benchmarks, and add it to the BenchmarkTestHelpers methods.

## Tests

These tests cover standard mocking framework functionality

 | Test                                         | How long does it take...                          |
 | -------------------------------------------- | ------------------------------------------------- |
 | [Construction](README.md#construction)       | for a mock to be created?                         |
 | [Callback](README.md#callback)               | for a mocked method to perform a callback?        |
 | [EmptyMethod](README.md#emptymethod)         | for an un-setup method to be called?              |
 | [EmptyReturn](README.md#emptyreturn)         | for an un-setup method to return default?         |
 | [Return](README.md#return)                   | for a mocked method to return a value?            |
 | [Verify](README.md#verify)                   | for verification that a method was called?        |

Each test (other than construction, obviously) also has an "Only" version, where the mock is setup in the constructor, and only the method call itself is measured.

This is more accurate when comparing against larger testing classes, where you have a fixture- or assembly-level setup, that doesn't get run with every test.

Note that FakeItEasy fails all of these tests, its time growing linearly with each iteration over the method. This may be due to a FakeItEasy memory leak.

 | Test                                         | How long does it take...                          |
 | -------------------------------------------- | ------------------------------------------------- |
 | [CallbackOnly](README.md#callbackonly)       | for an already set-up method to callback?         |
 | [EmptyMethodOnly](README.md#emptymethodonly) | for an already un-setup method to be called?      |
 | [EmptyReturnOnly](README.md#emptyreturnonly) | for an already un-setup method to return default? |
 | [ReturnOnly](README.md#returnonly)           | for an already set-up method to return?           |
 | [VerifyOnly](README.md#verifyonly)           | for an already set-up method to be verified?      |

Want to add more? PRs welcome! Just add a new class implementing IMockingBenchmark or IMockingBenchmark<T> depending on what you're testing.

### Results

#### Construction

This test simply creates an IThingy object to test using the given framework

 |      Method |         Mean |      Error |     StdDev |   Scaled | ScaledSD |
 |------------ |-------------:|-----------:|-----------:|---------:|---------:|
 |        Stub |     2.634 ns |  0.0308 ns |  0.0273 ns |     1.00 |     0.00 |
 |  FakeItEasy | 8,480.165 ns | 61.5024 ns | 54.5203 ns | 3,219.41 |    37.59 |
 |         Moq | 6,139.763 ns | 12.3983 ns | 10.9908 ns | 2,330.90 |    23.42 |
 | NSubstitute | 6,538.927 ns | 30.4356 ns | 28.4695 ns | 2,482.44 |    26.70 |
 |       Rocks | 3,396.038 ns | 10.4772 ns |  8.1799 ns | 1,289.27 |    13.10 |

 #### Callback

 A mock object is created, a method setup with a callback, and that method called

 |      Method |           Mean |         Error |        StdDev |     Scaled | ScaledSD |
 |------------ |---------------:|--------------:|--------------:|-----------:|---------:|
 |        Stub |       2.308 ns |     0.0191 ns |     0.0169 ns |       1.00 |     0.00 |
 |  FakeItEasy |  46,608.652 ns |   573.1943 ns |   536.1663 ns |  20,198.94 |   265.47 |
 |         Moq | 276,662.731 ns | 1,289.5281 ns | 1,076.8143 ns | 119,898.22 |   953.13 |
 | NSubstitute |  16,657.810 ns |    47.0011 ns |    43.9649 ns |   7,219.05 |    53.88 |
 |       Rocks |   9,839.282 ns |   266.4347 ns |   612.1780 ns |   4,264.08 |   264.89 |

#### EmptyMethod

A mock object is created, with no method setup, and a void method called

 |      Method |          Mean |       Error |      StdDev |   Scaled | ScaledSD |
 |------------ |--------------:|------------:|------------:|---------:|---------:|
 |        Stub |      2.582 ns |   0.0429 ns |   0.0402 ns |     1.00 |     0.00 |
 |  FakeItEasy | 15,355.419 ns | 300.2998 ns | 280.9006 ns | 5,948.07 |   137.27 |
 |         Moq |  7,375.027 ns | 135.5076 ns | 126.7539 ns | 2,856.79 |    63.62 |
 | NSubstitute | 12,780.400 ns | 207.5963 ns | 194.1857 ns | 4,950.61 |   103.34 |
 |       Rocks |  3,929.685 ns |  56.8768 ns |  53.2026 ns | 1,522.20 |    30.11 |

#### EmptyReturn

A mock object is created, with no method setup, and an int method called

 |      Method |          Mean |       Error |      StdDev |   Scaled | ScaledSD |
 |------------ |--------------:|------------:|------------:|---------:|---------:|
 |        Stub |      2.808 ns |   0.0874 ns |   0.1361 ns |     1.00 |     0.00 |
 |  FakeItEasy | 16,340.198 ns | 107.9547 ns |  84.2839 ns | 5,832.94 |   274.10 |
 |         Moq |  8,124.206 ns | 138.2203 ns | 122.5287 ns | 2,900.09 |   141.94 |
 | NSubstitute | 13,830.083 ns | 265.4984 ns | 345.2229 ns | 4,936.91 |   260.40 |
 |       Rocks |  3,997.144 ns | 104.8586 ns | 120.7553 ns | 1,426.86 |    78.83 |

#### Return

 A mock object is created, a method setup with a return, and that method called

 |      Method |           Mean |         Error |        StdDev |     Scaled | ScaledSD |
 |------------ |---------------:|--------------:|--------------:|-----------:|---------:|
 |        Stub |       2.751 ns |     0.0305 ns |     0.0254 ns |       1.00 |     0.00 |
 |  FakeItEasy |  44,562.681 ns |   934.3760 ns |   917.6820 ns |  16,197.91 |   353.63 |
 |         Moq | 288,629.140 ns | 2,464.5745 ns | 2,305.3643 ns | 104,912.66 | 1,235.04 |
 | NSubstitute |  21,374.916 ns |   276.9526 ns |   259.0616 ns |   7,769.48 |   114.23 |
 |       Rocks |  10,150.884 ns |   173.3831 ns |   153.6996 ns |   3,689.70 |    63.04 |

#### Verify

Verifies that the method was called

 |      Method |           Mean |         Error |        StdDev |    Scaled | ScaledSD |
 |------------ |---------------:|--------------:|--------------:|----------:|---------:|
 |        Stub |       2.742 ns |     0.0798 ns |     0.0784 ns |      1.00 |     0.00 |
 |  FakeItEasy |  53,738.145 ns |   575.9481 ns |   538.7422 ns | 19,614.77 |   572.84 |
 |         Moq | 270,312.770 ns | 2,537.2127 ns | 1,980.8886 ns | 98,665.89 | 2,805.13 |
 | NSubstitute |  21,176.545 ns |   190.6430 ns |   169.0000 ns |  7,729.57 |   221.10 |
 |       Rocks |   9,966.483 ns |   149.3100 ns |   139.6647 ns |  3,637.83 |   111.68 |

#### CallbackOnly

The creation of the mock object and its method setup are done outside the benchmark; only the method's call itself is tested

 |      Method |          Mean |      Error |     StdDev | Scaled | ScaledSD |
 |------------ |--------------:|-----------:|-----------:|-------:|---------:|
 |        Stub |     0.0000 ns |  0.0000 ns |  0.0000 ns |      ? |        ? |
 |         Moq |   935.6888 ns | 17.4571 ns | 17.9272 ns |      ? |        ? |
 | NSubstitute | 4,809.8186 ns | 78.2166 ns | 69.3369 ns |      ? |        ? |
 |       Rocks |    38.5109 ns |  0.7128 ns |  0.6667 ns |      ? |        ? |

#### EmptyMethodOnly

The creation of the mock object is done outside the benchmark; only an empty method call itself is tested

 |      Method |         Mean |      Error |     StdDev |   Scaled | ScaledSD |
 |------------ |-------------:|-----------:|-----------:|---------:|---------:|
 |        Stub |     1.228 ns |  0.0180 ns |  0.0150 ns |     1.00 |     0.00 |
 |         Moq | 1,000.768 ns | 19.8332 ns | 32.0269 ns |   814.92 |    27.41 |
 | NSubstitute | 4,133.032 ns | 80.9668 ns | 83.1469 ns | 3,365.51 |    76.60 |
 |       Rocks |     1.235 ns |  0.0141 ns |  0.0132 ns |     1.01 |     0.02 |

#### EmptyReturnOnly

The creation of the mock object is done outside the benchmark; only an empty method itself is tested

 |      Method |         Mean |      Error |      StdDev |   Scaled | ScaledSD |
 |------------ |-------------:|-----------:|------------:|---------:|---------:|
 |        Stub |     1.395 ns |  0.0106 ns |   0.0088 ns |     1.00 |     0.00 |
 |         Moq | 1,204.166 ns | 23.1322 ns |  33.9069 ns |   863.35 |    24.45 |
 | NSubstitute | 4,842.011 ns | 96.8704 ns | 161.8486 ns | 3,471.58 |   116.34 |
 |       Rocks |     1.432 ns |  0.0454 ns |   0.0402 ns |     1.03 |     0.03 |

#### ReturnOnly

The creation of the mock object and its method setup are done outside the benchmark; only the method's call itself is tested

 |      Method |         Mean |      Error |     StdDev |   Scaled | ScaledSD |
 |------------ |-------------:|-----------:|-----------:|---------:|---------:|
 |        Stub |     1.443 ns |  0.0380 ns |  0.0355 ns |     1.00 |     0.00 |
 |         Moq | 1,431.085 ns | 28.1130 ns | 58.0582 ns |   992.16 |    46.18 |
 | NSubstitute | 4,623.484 ns | 78.1182 ns | 65.2322 ns | 3,205.42 |    86.94 |
 |       Rocks |    37.805 ns |  0.7545 ns |  0.8074 ns |    26.21 |     0.82 |

#### VerifyOnly

The creation of the mock object and its method call are done outside the benchmark; only the verification itself is tested

 |      Method |            Mean |         Error |        StdDev |       Scaled |   ScaledSD |
 |------------ |----------------:|--------------:|--------------:|-------------:|-----------:|
 |        Stub |       0.1222 ns |     0.0068 ns |     0.0064 ns |         1.00 |       0.00 |
 |  FakeItEasy |  19,565.8368 ns |   108.1973 ns |    90.3496 ns |   160,509.02 |   8,257.01 |
 |         Moq | 250,298.0688 ns | 3,541.1154 ns | 3,312.3612 ns | 2,053,328.83 | 108,467.38 |
 | NSubstitute |   4,092.2133 ns |    24.1976 ns |    22.6345 ns |    33,570.61 |   1,729.86 |
 |       Rocks |     183.5329 ns |     1.4665 ns |     1.3718 ns |     1,505.62 |      77.93 |
