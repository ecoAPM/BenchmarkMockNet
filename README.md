# BenchmarkMockNet

This repo contains the code for, and results of, a series of performance benchmarks running against various .NET mocking libraries, using [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet).

## Current contenders (alphabetical order)

The baseline is a simple [stub class](https://github.com/stevedesmond-ca/BenchmarkMockNet/blob/master/ThingStub.cs).

- [FakeItEasy](https://github.com/FakeItEasy/FakeItEasy)
- [Moq](https://github.com/moq/moq4)
- [NSubstitute](http://nsubstitute.github.io/)
- [PCLMock](https://github.com/kentcb/PCLMock)
- [Rocks](https://github.com/JasonBock/Rocks)

Want to add more? PRs welcome! Just add a method to `IMockingBenchmark` and `IMockingBenchmark<T>`, implement it in each of the benchmarks, and add it to the `BenchmarkTestHelpers` methods.

### A note about PCLMock

`PCLMock` is a little different than the other libraries tested here, in that it requires explicitly generated mock classes. Compared against the other contenders, which use underlying parts of the framework like reflection to mock classes more "on the fly", `PCLMock` boasts much higher performance than its more dynamic counterparts, at the cost of some additional effort during development time.

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

Want to add more? PRs welcome! Just add a new class extending `MockingBenchmark` or `MockingBenchmark<T>`, depending on what you're testing.

### Results

#### Construction

This test simply creates an IThingy object to test using the given framework

|      Method |        Mean |        Error |       StdDev |      Median |  Ratio | RatioSD |
|------------ |------------:|-------------:|-------------:|------------:|-------:|--------:|
|        Stub |    15.75 ns |     8.248 ns |     5.455 ns |    14.13 ns |   1.00 |    0.00 |
|  FakeItEasy | 4,880.67 ns | 1,039.852 ns |   687.797 ns | 4,684.60 ns | 321.44 |   38.87 |
|         Moq | 5,683.25 ns | 1,241.096 ns |   820.908 ns | 5,475.38 ns | 374.04 |   44.41 |
| NSubstitute | 5,766.44 ns | 1,338.676 ns |   885.451 ns | 5,490.69 ns | 379.13 |   45.40 |
|       Rocks | 7,749.92 ns | 9,682.991 ns | 6,404.699 ns | 5,860.53 ns | 451.36 |  137.27 |
|     PCLMock |    81.12 ns |    43.083 ns |    28.497 ns |    71.95 ns |   5.17 |    0.68 |

#### Callback

A mock object is created, a method setup with a callback, and that method called

|      Method |         Mean |         Error |       StdDev |  Ratio | RatioSD |
|------------ |-------------:|--------------:|-------------:|-------:|--------:|
|        Stub |     20.98 ns |      8.609 ns |     5.694 ns |   1.00 |    0.00 |
|  FakeItEasy | 11,818.95 ns |  2,036.474 ns | 1,347.001 ns | 576.89 |   56.74 |
|         Moq | 11,181.10 ns |  1,786.024 ns | 1,181.344 ns | 546.73 |   59.71 |
| NSubstitute | 10,931.16 ns |  1,668.137 ns | 1,103.369 ns | 534.56 |   56.20 |
|       Rocks | 12,907.65 ns | 11,730.313 ns | 7,758.876 ns | 584.74 |  126.13 |
|     PCLMock |  4,875.70 ns |    965.447 ns |   638.583 ns | 237.41 |   21.38 |

#### EmptyMethod

A mock object is created, with no method setup, and a void method called

|      Method |        Mean |        Error |       StdDev |      Median |  Ratio | RatioSD |
|------------ |------------:|-------------:|-------------:|------------:|-------:|--------:|
|        Stub |    16.44 ns |     8.146 ns |     5.388 ns |    14.91 ns |   1.00 |    0.00 |
|  FakeItEasy | 6,455.03 ns | 1,678.036 ns | 1,109.917 ns | 6,159.02 ns | 404.05 |   43.00 |
|         Moq | 6,249.19 ns | 1,107.322 ns |   732.425 ns | 6,037.57 ns | 394.76 |   52.27 |
| NSubstitute | 8,400.04 ns | 1,339.535 ns |   886.020 ns | 8,214.30 ns | 532.68 |   81.78 |
|       Rocks | 7,856.87 ns | 9,709.397 ns | 6,422.165 ns | 5,815.25 ns | 439.08 |  137.94 |
|     PCLMock | 3,537.35 ns |   851.914 ns |   563.488 ns | 3,368.28 ns | 221.83 |   24.33 |

#### EmptyReturn

A mock object is created, with no method setup, and an int method called

|      Method |        Mean |        Error |       StdDev |      Median |  Ratio | RatioSD |
|------------ |------------:|-------------:|-------------:|------------:|-------:|--------:|
|        Stub |    15.78 ns |     7.500 ns |     4.961 ns |    14.22 ns |   1.00 |    0.00 |
|  FakeItEasy | 6,477.08 ns | 1,622.928 ns | 1,073.466 ns | 6,148.67 ns | 421.03 |   39.74 |
|         Moq | 6,661.27 ns | 1,170.558 ns |   774.252 ns | 6,438.73 ns | 436.58 |   53.21 |
| NSubstitute | 8,413.48 ns | 1,203.191 ns |   795.837 ns | 8,238.06 ns | 553.32 |   73.24 |
|       Rocks | 8,057.05 ns | 9,636.791 ns | 6,374.140 ns | 6,119.93 ns | 470.82 |  144.48 |
|     PCLMock | 3,704.11 ns |   770.102 ns |   509.375 ns | 3,550.80 ns | 241.88 |   26.26 |

#### Return

 A mock object is created, a method setup with a return, and that method called

|      Method |         Mean |         Error |       StdDev |       Median |  Ratio | RatioSD |
|------------ |-------------:|--------------:|-------------:|-------------:|-------:|--------:|
|        Stub |     16.55 ns |      7.738 ns |     5.119 ns |     15.02 ns |   1.00 |    0.00 |
|  FakeItEasy | 11,176.40 ns |  2,235.448 ns | 1,478.610 ns | 10,726.57 ns | 696.62 |   82.25 |
|         Moq | 12,097.37 ns |  1,496.481 ns |   989.830 ns | 11,817.26 ns | 759.83 |  106.42 |
| NSubstitute | 11,810.45 ns |  1,904.562 ns | 1,259.750 ns | 11,588.41 ns | 738.53 |   90.88 |
|       Rocks | 12,490.91 ns | 12,510.210 ns | 8,274.729 ns |  9,912.12 ns | 712.69 |  162.88 |
|     PCLMock |  3,768.73 ns |    888.181 ns |   587.477 ns |  3,556.43 ns | 234.07 |   26.24 |

#### Verify

Verifies that the method was called

|      Method |         Mean |         Error |       StdDev |  Ratio | RatioSD |
|------------ |-------------:|--------------:|-------------:|-------:|--------:|
|        Stub |     22.14 ns |      8.401 ns |     5.557 ns |   1.00 |    0.00 |
|  FakeItEasy | 12,416.12 ns |  2,148.414 ns | 1,421.043 ns | 572.19 |   51.96 |
|         Moq | 13,796.84 ns |  1,810.969 ns | 1,197.844 ns | 638.39 |   69.12 |
| NSubstitute | 13,151.66 ns |  1,766.553 ns | 1,168.466 ns | 608.38 |   65.39 |
|       Rocks | 13,141.08 ns | 12,619.397 ns | 8,346.950 ns | 561.49 |  146.54 |
|     PCLMock |  5,324.70 ns |    799.769 ns |   528.998 ns | 246.01 |   25.67 |

#### CallbackOnly

The creation of the mock object and its method setup are done outside the benchmark; only the method's call itself is tested

|      Method |        Mean |      Error |     StdDev |  Ratio | RatioSD |
|------------ |------------:|-----------:|-----------:|-------:|--------:|
|        Stub |    16.38 ns |   2.821 ns |   1.866 ns |   1.00 |    0.00 |
|  FakeItEasy | 3,056.80 ns | 543.521 ns | 359.506 ns | 188.66 |   31.64 |
|         Moq |   401.84 ns | 159.713 ns | 105.640 ns |  24.58 |    5.82 |
| NSubstitute | 1,571.09 ns | 454.653 ns | 300.725 ns |  96.04 |   14.05 |
|       Rocks |    66.04 ns |   6.050 ns |   4.002 ns |   4.07 |    0.41 |
|     PCLMock | 2,356.95 ns | 826.181 ns | 546.468 ns | 143.52 |   22.71 |

#### EmptyMethodOnly

The creation of the mock object is done outside the benchmark; only an empty method call itself is tested

|      Method |         Mean |      Error |      StdDev |  Ratio | RatioSD |
|------------ |-------------:|-----------:|------------:|-------:|--------:|
|        Stub |     5.805 ns |   1.872 ns |   1.2384 ns |   1.00 |    0.00 |
|  FakeItEasy | 2,586.000 ns | 499.538 ns | 330.4135 ns | 460.84 |  113.65 |
|         Moq |   324.227 ns | 118.354 ns |  78.2838 ns |  56.96 |   14.13 |
| NSubstitute | 1,190.206 ns | 247.011 ns | 163.3827 ns | 208.12 |   24.00 |
|       Rocks |     5.745 ns |   1.056 ns |   0.6983 ns |   1.01 |    0.12 |
|     PCLMock | 1,802.797 ns | 715.797 ns | 473.4551 ns | 310.71 |   43.04 |

#### EmptyReturnOnly

The creation of the mock object is done outside the benchmark; only an empty method itself is tested

|      Method |         Mean |      Error |      StdDev |  Ratio | RatioSD |
|------------ |-------------:|-----------:|------------:|-------:|--------:|
|        Stub |     5.923 ns |   1.708 ns |   1.1300 ns |   1.00 |    0.00 |
|  FakeItEasy | 2,755.055 ns | 393.708 ns | 260.4138 ns | 472.24 |   51.69 |
|         Moq |   875.675 ns | 345.344 ns | 228.4239 ns | 148.98 |   35.28 |
| NSubstitute | 1,268.174 ns | 301.661 ns | 199.5301 ns | 215.88 |   21.80 |
|       Rocks |     5.004 ns |   1.388 ns |   0.9181 ns |   0.85 |    0.10 |
|     PCLMock | 1,876.473 ns | 732.520 ns | 484.5169 ns | 314.98 |   29.54 |

#### ReturnOnly

The creation of the mock object and its method setup are done outside the benchmark; only the method's call itself is tested

|      Method |         Mean |      Error |     StdDev |  Ratio | RatioSD |
|------------ |-------------:|-----------:|-----------:|-------:|--------:|
|        Stub |     5.659 ns |   1.549 ns |   1.024 ns |   1.00 |    0.00 |
|  FakeItEasy | 2,619.555 ns | 617.680 ns | 408.557 ns | 472.38 |   94.27 |
|         Moq |   373.764 ns | 121.920 ns |  80.643 ns |  66.67 |   13.70 |
| NSubstitute |   922.115 ns | 179.822 ns | 118.941 ns | 164.35 |   14.07 |
|       Rocks |    66.312 ns |   5.126 ns |   3.391 ns |  11.93 |    1.44 |
|     PCLMock | 1,980.146 ns | 887.391 ns | 586.954 ns | 347.91 |   63.50 |

#### VerifyOnly

The creation of the mock object and its method call are done outside the benchmark; only the verification itself is tested

|      Method |         Mean |      Error |     StdDev |       Median |  Ratio | RatioSD |
|------------ |-------------:|-----------:|-----------:|-------------:|-------:|--------:|
|        Stub |     6.277 ns |   3.833 ns |   2.535 ns |     5.317 ns |   1.00 |    0.00 |
|  FakeItEasy | 3,042.957 ns | 923.238 ns | 610.665 ns | 2,940.703 ns | 520.24 |  112.80 |
|         Moq | 3,506.629 ns | 886.613 ns | 586.439 ns | 3,343.991 ns | 603.65 |  133.59 |
| NSubstitute | 3,081.019 ns | 750.531 ns | 496.430 ns | 2,919.888 ns | 528.36 |  109.25 |
|       Rocks |   345.472 ns | 228.593 ns | 151.200 ns |   254.984 ns |  58.37 |   25.39 |
|     PCLMock | 1,781.514 ns | 815.947 ns | 539.699 ns | 1,558.300 ns | 301.94 |   71.54 |

## Building/Running from source

### Requirements

- .NET SDK v5.0.400 (or newer)

### Installation

1. Run `dotnet restore` to install all dependent libraries and prep for build
1. Run `dotnet publish -c Release` to build the benchmarks (the `-c Release` flag is important to maximize accuracy)

### Usage

1. Once restored and built, run `dotnet bin/Release/net5.0/publish/BenchmarkMockNet.dll` to execute the benchmarks
2. Benchmarks will take about 5 minutes to run
3. Results are stored in the `BenchmarkDotNet.Artifacts` directory, in both HTML and Markdown formats
