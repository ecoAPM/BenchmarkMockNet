# BenchmarkMockNet
Using BenchmarkDotNet to compare .NET Core mocking library performance

---

This repo contains the code for -- and results of -- a series of benchmarks around the functionality of some of .NET Core's mocking libraries.

The baseline is a simple [stub](https://github.com/stevedesmond-ca/BenchmarkMockNet/blob/master/ThingStub.cs).

## Current contenders (alphabetical order)
- [FakeItEasy](https://github.com/FakeItEasy/FakeItEasy) v5.1.1
- [Moq](https://github.com/moq/moq4) v4.10.1
- [NSubstitute](http://nsubstitute.github.io/) v4.1.0
- [Rocks](https://github.com/JasonBock/Rocks) v3.1.0

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

This is more accurate when comparing against larger testing classes, where you have a fixture- or assembly-level setup that doesn't get run with every test.

 | Test                                         | How long does it take...                          |
 | -------------------------------------------- | ------------------------------------------------- |
 | [CallbackOnly](README.md#callbackonly)       | for an already set-up method to callback?         |
 | [EmptyMethodOnly](README.md#emptymethodonly) | for an already un-setup method to be called?      |
 | [EmptyReturnOnly](README.md#emptyreturnonly) | for an already un-setup method to return default? |
 | [ReturnOnly](README.md#returnonly)           | for an already set-up method to return?           |
 | [VerifyOnly](README.md#verifyonly)           | for an already set-up method to be verified?      |

Want to add more? PRs welcome! Just add a new class extending MockingBenchmark or MockingBenchmark<T>, depending on what you're testing.

### Results

#### Construction

This test simply creates an IThingy object to test using the given framework

|      Method |         Mean |        Error |      StdDev |  Ratio | RatioSD |
|------------ |-------------:|-------------:|------------:|-------:|--------:|
|        Stub |     7.860 ns |     2.222 ns |   0.5770 ns |   1.00 |    0.00 |
|  FakeItEasy | 5,869.604 ns |   217.398 ns |  56.4575 ns | 749.74 |   50.70 |
|         Moq | 4,309.662 ns |   257.179 ns |  66.7886 ns | 550.04 |   29.27 |
| NSubstitute | 4,584.571 ns |   410.362 ns | 106.5698 ns | 585.15 |   33.42 |
|       Rocks | 3,937.106 ns | 3,575.241 ns | 928.4787 ns | 496.58 |   74.57 |

#### Callback

A mock object is created, a method setup with a callback, and that method called

|      Method |          Mean |        Error |        StdDev |    Ratio | RatioSD |
|------------ |--------------:|-------------:|--------------:|---------:|--------:|
|        Stub |      5.611 ns |     2.832 ns |     0.7354 ns |     1.00 |    0.00 |
|  FakeItEasy | 13,555.659 ns |   610.923 ns |   158.6547 ns | 2,447.34 |  299.03 |
|         Moq |  8,368.881 ns |   282.985 ns |    73.4904 ns | 1,508.62 |  163.53 |
| NSubstitute |  8,820.286 ns |   261.134 ns |    67.8157 ns | 1,590.20 |  174.38 |
|       Rocks |  7,947.490 ns | 4,415.532 ns | 1,146.6995 ns | 1,415.60 |   51.15 |

#### EmptyMethod

A mock object is created, with no method setup, and a void method called

|      Method |         Mean |         Error |      StdDev |    Ratio | RatioSD |
|------------ |-------------:|--------------:|------------:|---------:|--------:|
|        Stub |     2.150 ns |     0.7782 ns |   0.2021 ns |     1.00 |    0.00 |
|  FakeItEasy | 6,793.720 ns |   134.0598 ns |  34.8149 ns | 3,181.61 |  282.66 |
|         Moq | 4,510.529 ns |   223.6569 ns |  58.0830 ns | 2,112.18 |  185.72 |
| NSubstitute | 6,370.727 ns |   261.1094 ns |  67.8093 ns | 2,982.64 |  253.54 |
|       Rocks | 3,762.237 ns | 3,664.2182 ns | 951.5858 ns | 1,756.83 |  434.38 |

#### EmptyReturn

A mock object is created, with no method setup, and an int method called

|      Method |         Mean |         Error |      StdDev |    Ratio | RatioSD |
|------------ |-------------:|--------------:|------------:|---------:|--------:|
|        Stub |     2.121 ns |     0.6638 ns |   0.1724 ns |     1.00 |    0.00 |
|  FakeItEasy | 7,200.350 ns |   894.0824 ns | 232.1904 ns | 3,414.20 |  320.59 |
|         Moq | 5,270.607 ns |   212.1592 ns |  55.0971 ns | 2,497.01 |  188.85 |
| NSubstitute | 6,964.487 ns |   837.1808 ns | 217.4132 ns | 3,297.66 |  234.82 |
|       Rocks | 3,833.976 ns | 3,560.0844 ns | 924.5426 ns | 1,803.77 |  366.38 |

#### Return

 A mock object is created, a method setup with a return, and that method called

|      Method |          Mean |         Error |        StdDev |    Ratio | RatioSD |
|------------ |--------------:|--------------:|--------------:|---------:|--------:|
|        Stub |      2.199 ns |     0.6483 ns |     0.1684 ns |     1.00 |    0.00 |
|  FakeItEasy | 13,531.261 ns |   778.2718 ns |   202.1147 ns | 6,179.76 |  440.16 |
|         Moq |  8,272.339 ns |   322.9447 ns |    83.8677 ns | 3,779.14 |  284.75 |
| NSubstitute |  9,253.538 ns |   137.9796 ns |    35.8329 ns | 4,227.36 |  315.92 |
|       Rocks |  8,416.369 ns | 4,545.9801 ns | 1,180.5766 ns | 3,845.74 |  610.60 |

#### Verify

Verifies that the method was called

|      Method |          Mean |        Error |        StdDev |    Ratio | RatioSD |
|------------ |--------------:|-------------:|--------------:|---------:|--------:|
|        Stub |      5.697 ns |     2.421 ns |     0.6286 ns |     1.00 |    0.00 |
|  FakeItEasy | 14,684.605 ns |   122.547 ns |    31.8250 ns | 2,599.94 |  253.53 |
|         Moq |  9,329.822 ns |   220.555 ns |    57.2773 ns | 1,650.96 |  150.84 |
| NSubstitute | 11,071.515 ns |   285.866 ns |    74.2384 ns | 1,959.20 |  179.63 |
|       Rocks |  8,306.876 ns | 4,618.326 ns | 1,199.3645 ns | 1,454.31 |   45.84 |

#### CallbackOnly

The creation of the mock object and its method setup are done outside the benchmark; only the method's call itself is tested

|      Method |         Mean |       Error |      StdDev |  Ratio | RatioSD |
|------------ |-------------:|------------:|------------:|-------:|--------:|
|        Stub |     2.308 ns |   0.6986 ns |   0.1814 ns |   1.00 |    0.00 |
|  FakeItEasy | 2,006.852 ns | 697.0320 ns | 181.0170 ns | 872.16 |   85.47 |
|         Moq |   419.280 ns | 120.0604 ns |  31.1793 ns | 181.78 |    3.73 |
| NSubstitute | 1,297.698 ns | 157.6560 ns |  40.9428 ns | 564.28 |   33.27 |
|       Rocks |    22.813 ns |   2.0029 ns |   0.5201 ns |   9.92 |    0.56 |

#### EmptyMethodOnly

The creation of the mock object is done outside the benchmark; only an empty method call itself is tested

|      Method |         Mean |       Error |      StdDev |  Ratio | RatioSD |
|------------ |-------------:|------------:|------------:|-------:|--------:|
|        Stub |     3.050 ns |   0.6142 ns |   0.1595 ns |   1.00 |    0.00 |
|  FakeItEasy | 1,626.815 ns | 730.8575 ns | 189.8014 ns | 532.88 |   46.92 |
|         Moq |   435.654 ns | 242.9907 ns |  63.1039 ns | 143.33 |   23.75 |
| NSubstitute | 1,181.949 ns | 142.8519 ns |  37.0982 ns | 388.23 |   20.31 |
|       Rocks |     3.340 ns |   0.5395 ns |   0.1401 ns |   1.10 |    0.02 |

#### EmptyReturnOnly

The creation of the mock object is done outside the benchmark; only an empty method itself is tested

|      Method |         Mean |       Error |      StdDev |  Ratio | RatioSD |
|------------ |-------------:|------------:|------------:|-------:|--------:|
|        Stub |     3.418 ns |   0.7232 ns |   0.1878 ns |   1.00 |    0.00 |
|  FakeItEasy | 1,906.414 ns | 933.3018 ns | 242.3755 ns | 559.86 |   87.01 |
|         Moq |   774.190 ns | 208.5461 ns |  54.1588 ns | 227.06 |   20.77 |
| NSubstitute | 1,224.316 ns | 151.8240 ns |  39.4282 ns | 358.70 |   15.48 |
|       Rocks |     3.382 ns |   0.7179 ns |   0.1864 ns |   0.99 |    0.05 |

#### ReturnOnly

The creation of the mock object and its method setup are done outside the benchmark; only the method's call itself is tested

|      Method |         Mean |       Error |      StdDev |  Ratio | RatioSD |
|------------ |-------------:|------------:|------------:|-------:|--------:|
|        Stub |     3.388 ns |   0.9389 ns |   0.2438 ns |   1.00 |    0.00 |
|  FakeItEasy | 1,920.774 ns | 688.5346 ns | 178.8102 ns | 569.98 |   73.91 |
|         Moq |   467.283 ns | 219.1283 ns |  56.9069 ns | 138.06 |   14.72 |
| NSubstitute |   744.708 ns |  81.7324 ns |  21.2256 ns | 220.77 |   17.71 |
|       Rocks |    20.204 ns |   1.5290 ns |   0.3971 ns |   5.99 |    0.42 |

#### VerifyOnly

The creation of the mock object and its method call are done outside the benchmark; only the verification itself is tested

|      Method |         Mean |      Error |     StdDev |    Ratio | RatioSD |
|------------ |-------------:|-----------:|-----------:|---------:|--------:|
|        Stub |     1.665 ns |  0.7907 ns |  0.2053 ns |     1.00 |    0.00 |
|  FakeItEasy | 2,333.642 ns | 14.2155 ns |  3.6917 ns | 1,415.95 |  148.82 |
|         Moq | 2,189.797 ns | 23.3928 ns |  6.0750 ns | 1,328.94 |  142.45 |
| NSubstitute | 2,330.673 ns | 51.0714 ns | 13.2631 ns | 1,413.79 |  145.18 |
|       Rocks |   172.622 ns |  5.8290 ns |  1.5138 ns |   104.68 |   10.40 |