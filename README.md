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
|        Stub |     7.020 ns |     2.976 ns |   0.7729 ns |   1.00 |    0.00 |
|  FakeItEasy | 6,064.985 ns |   137.072 ns |  35.5971 ns | 872.02 |   92.56 |
|         Moq | 5,093.852 ns |   271.726 ns |  70.5664 ns | 731.36 |   66.59 |
| NSubstitute | 5,959.187 ns |   127.784 ns |  33.1851 ns | 856.08 |   82.64 |
|       Rocks | 4,036.312 ns | 3,535.193 ns | 918.0784 ns | 570.51 |   67.45 |

#### Callback

A mock object is created, a method setup with a callback, and that method called

|      Method |          Mean |        Error |        StdDev |    Ratio | RatioSD |
|------------ |--------------:|-------------:|--------------:|---------:|--------:|
|        Stub |      5.198 ns |     2.884 ns |     0.7490 ns |     1.00 |    0.00 |
|  FakeItEasy | 14,738.372 ns | 2,058.563 ns |   534.6024 ns | 2,883.04 |  428.25 |
|         Moq |  8,846.362 ns |   161.455 ns |    41.9292 ns | 1,726.05 |  210.99 |
| NSubstitute | 16,019.492 ns | 1,152.879 ns |   299.3991 ns | 3,123.89 |  369.72 |
|       Rocks |  8,077.037 ns | 4,511.594 ns | 1,171.6466 ns | 1,554.93 |   61.61 |

#### EmptyMethod

A mock object is created, with no method setup, and a void method called

|      Method |          Mean |         Error |      StdDev |    Ratio | RatioSD |
|------------ |--------------:|--------------:|------------:|---------:|--------:|
|        Stub |      2.069 ns |     0.4757 ns |   0.1235 ns |     1.00 |    0.00 |
|  FakeItEasy |  7,350.389 ns |   210.5169 ns |  54.6706 ns | 3,563.18 |  215.36 |
|         Moq |  5,163.727 ns |   278.7915 ns |  72.4013 ns | 2,501.71 |  123.02 |
| NSubstitute | 11,316.609 ns |   259.5282 ns |  67.3986 ns | 5,484.49 |  304.18 |
|       Rocks |  3,929.603 ns | 3,504.0733 ns | 909.9967 ns | 1,888.02 |  328.10 |

#### EmptyReturn

A mock object is created, with no method setup, and an int method called

|      Method |          Mean |         Error |      StdDev |    Ratio | RatioSD |
|------------ |--------------:|--------------:|------------:|---------:|--------:|
|        Stub |      2.135 ns |     0.3851 ns |   0.1000 ns |     1.00 |    0.00 |
|  FakeItEasy |  7,536.479 ns |    54.3858 ns |  14.1238 ns | 3,535.88 |  162.14 |
|         Moq |  5,955.640 ns |   219.8502 ns |  57.0944 ns | 2,793.86 |  121.26 |
| NSubstitute | 12,557.926 ns |   657.7845 ns | 170.8245 ns | 5,891.38 |  271.49 |
|       Rocks |  3,957.649 ns | 3,525.7061 ns | 915.6147 ns | 1,847.42 |  368.18 |

#### Return

 A mock object is created, a method setup with a return, and that method called

|      Method |          Mean |         Error |        StdDev |    Ratio | RatioSD |
|------------ |--------------:|--------------:|--------------:|---------:|--------:|
|        Stub |      2.184 ns |     0.6082 ns |     0.1579 ns |     1.00 |    0.00 |
|  FakeItEasy | 13,881.120 ns |   130.1447 ns |    33.7982 ns | 6,384.19 |  476.25 |
|         Moq |  8,759.949 ns |   367.7998 ns |    95.5165 ns | 4,028.28 |  291.93 |
| NSubstitute | 19,935.253 ns |   374.8967 ns |    97.3595 ns | 9,168.07 |  674.55 |
|       Rocks |  8,286.584 ns | 5,096.9801 ns | 1,323.6696 ns | 3,805.45 |  612.00 |

#### Verify

Verifies that the method was called

|      Method |          Mean |        Error |        StdDev |    Ratio | RatioSD |
|------------ |--------------:|-------------:|--------------:|---------:|--------:|
|        Stub |      5.508 ns |     2.749 ns |     0.7139 ns |     1.00 |    0.00 |
|  FakeItEasy | 14,955.980 ns |   527.737 ns |   137.0517 ns | 2,749.36 |  329.64 |
|         Moq | 10,650.331 ns |   326.567 ns |    84.8084 ns | 1,955.63 |  213.54 |
| NSubstitute | 17,546.704 ns |    65.236 ns |    16.9415 ns | 3,223.64 |  366.87 |
|       Rocks |  8,399.815 ns | 4,448.938 ns | 1,155.3750 ns | 1,524.97 |   57.41 |

#### CallbackOnly

The creation of the mock object and its method setup are done outside the benchmark; only the method's call itself is tested

|      Method |         Mean |       Error |      StdDev |    Ratio | RatioSD |
|------------ |-------------:|------------:|------------:|---------:|--------:|
|        Stub |     2.024 ns |   0.9290 ns |   0.2413 ns |     1.00 |    0.00 |
|  FakeItEasy | 2,025.312 ns | 625.1310 ns | 162.3445 ns | 1,005.01 |   53.72 |
|         Moq |   474.834 ns | 108.9669 ns |  28.2983 ns |   236.26 |   19.17 |
| NSubstitute | 4,697.860 ns | 350.8859 ns |  91.1239 ns | 2,342.71 |  221.22 |
|       Rocks |    24.396 ns |   2.1904 ns |   0.5689 ns |    12.18 |    1.30 |

#### EmptyMethodOnly

The creation of the mock object is done outside the benchmark; only an empty method call itself is tested

|      Method |         Mean |      Error |      StdDev |    Ratio | RatioSD |
|------------ |-------------:|-----------:|------------:|---------:|--------:|
|        Stub |     3.447 ns |   1.027 ns |   0.2668 ns |     1.00 |    0.00 |
|  FakeItEasy | 1,643.314 ns | 712.892 ns | 185.1357 ns |   477.69 |   50.27 |
|         Moq |   443.591 ns | 236.244 ns |  61.3519 ns |   129.62 |   23.72 |
| NSubstitute | 4,036.239 ns | 276.987 ns |  71.9328 ns | 1,176.88 |   98.99 |
|       Rocks |     3.440 ns |   1.187 ns |   0.3082 ns |     1.00 |    0.07 |

#### EmptyReturnOnly

The creation of the mock object is done outside the benchmark; only an empty method itself is tested

|      Method |         Mean |      Error |      StdDev |    Ratio | RatioSD |
|------------ |-------------:|-----------:|------------:|---------:|--------:|
|        Stub |     3.446 ns |   1.186 ns |   0.3081 ns |     1.00 |    0.00 |
|  FakeItEasy | 2,004.099 ns | 670.990 ns | 174.2539 ns |   583.25 |   49.83 |
|         Moq |   839.878 ns | 234.187 ns |  60.8175 ns |   245.15 |   27.06 |
| NSubstitute | 4,601.288 ns | 302.515 ns |  78.5622 ns | 1,342.15 |   99.97 |
|       Rocks |     3.254 ns |   1.034 ns |   0.2687 ns |     0.95 |    0.12 |

#### ReturnOnly

The creation of the mock object and its method setup are done outside the benchmark; only the method's call itself is tested

|      Method |         Mean |       Error |      StdDev |    Ratio | RatioSD |
|------------ |-------------:|------------:|------------:|---------:|--------:|
|        Stub |     3.068 ns |   0.7844 ns |   0.2037 ns |     1.00 |    0.00 |
|  FakeItEasy | 1,941.458 ns | 550.1790 ns | 142.8797 ns |   634.45 |   56.53 |
|         Moq |   474.743 ns | 242.8775 ns |  63.0745 ns |   155.25 |   22.36 |
| NSubstitute | 4,622.001 ns | 362.1362 ns |  94.0456 ns | 1,510.99 |   89.00 |
|       Rocks |    20.061 ns |   1.8731 ns |   0.4864 ns |     6.56 |    0.38 |

#### VerifyOnly

The creation of the mock object and its method call are done outside the benchmark; only the verification itself is tested

|      Method |         Mean |      Error |     StdDev |    Ratio | RatioSD |
|------------ |-------------:|-----------:|-----------:|---------:|--------:|
|        Stub |     1.700 ns |  0.6678 ns |  0.1734 ns |     1.00 |    0.00 |
|  FakeItEasy | 2,399.910 ns | 40.9298 ns | 10.6293 ns | 1,421.59 |  125.54 |
|         Moq | 2,314.763 ns | 48.1444 ns | 12.5030 ns | 1,371.16 |  121.24 |
| NSubstitute | 3,649.837 ns | 95.0420 ns | 24.6821 ns | 2,162.34 |  195.01 |
|       Rocks |   177.523 ns | 10.3892 ns |  2.6980 ns |   105.13 |    9.00 |