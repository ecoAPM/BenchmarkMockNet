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

|      Method |         Mean |        Error |        StdDev |  Ratio | RatioSD |
|------------ |-------------:|-------------:|--------------:|-------:|--------:|
|        Stub |     6.899 ns |     2.002 ns |     0.5199 ns |   1.00 |    0.00 |
|  FakeItEasy | 6,178.790 ns |   986.620 ns |   256.2222 ns | 900.17 |   82.66 |
|         Moq | 4,543.258 ns |   346.732 ns |    90.0453 ns | 660.80 |   38.72 |
| NSubstitute | 5,846.214 ns |   650.866 ns |   169.0279 ns | 850.22 |   51.01 |
|       Rocks | 4,021.333 ns | 4,106.871 ns | 1,066.5414 ns | 576.97 |  102.19 |

#### Callback

A mock object is created, a method setup with a callback, and that method called

|      Method |          Mean |        Error |        StdDev |    Ratio | RatioSD |
|------------ |--------------:|-------------:|--------------:|---------:|--------:|
|        Stub |      6.341 ns |     3.210 ns |     0.8338 ns |     1.00 |    0.00 |
|  FakeItEasy | 14,142.899 ns | 2,058.325 ns |   534.5404 ns | 2,262.16 |  318.01 |
|         Moq |  9,009.491 ns |   459.440 ns |   119.3151 ns | 1,439.25 |  177.94 |
| NSubstitute | 12,339.562 ns | 2,006.935 ns |   521.1946 ns | 1,968.69 |  237.29 |
|       Rocks |  8,118.725 ns | 4,659.140 ns | 1,209.9639 ns | 1,281.96 |  102.98 |

#### EmptyMethod

A mock object is created, with no method setup, and a void method called

|      Method |         Mean |         Error |      StdDev |    Ratio | RatioSD |
|------------ |-------------:|--------------:|------------:|---------:|--------:|
|        Stub |     2.224 ns |     0.9206 ns |   0.2391 ns |     1.00 |    0.00 |
|  FakeItEasy | 6,961.136 ns | 1,331.1715 ns | 345.7010 ns | 3,170.20 |  463.39 |
|         Moq | 4,882.881 ns |   334.8941 ns |  86.9709 ns | 2,215.70 |  231.20 |
| NSubstitute | 9,056.792 ns | 1,209.4232 ns | 314.0834 ns | 4,106.80 |  422.59 |
|       Rocks | 3,762.301 ns | 3,561.0657 ns | 924.7974 ns | 1,706.97 |  446.53 |

#### EmptyReturn

A mock object is created, with no method setup, and an int method called

|      Method |         Mean |         Error |      StdDev |    Ratio | RatioSD |
|------------ |-------------:|--------------:|------------:|---------:|--------:|
|        Stub |     2.132 ns |     0.4232 ns |   0.1099 ns |     1.00 |    0.00 |
|  FakeItEasy | 7,001.548 ns |   531.6501 ns | 138.0678 ns | 3,291.36 |  181.96 |
|         Moq | 5,463.500 ns |   446.3749 ns | 115.9221 ns | 2,569.03 |  157.56 |
| NSubstitute | 9,729.461 ns |   930.1345 ns | 241.5530 ns | 4,571.89 |  214.03 |
|       Rocks | 3,795.673 ns | 3,463.6349 ns | 899.4950 ns | 1,778.80 |  392.28 |

#### Return

 A mock object is created, a method setup with a return, and that method called

|      Method |          Mean |         Error |        StdDev |    Ratio | RatioSD |
|------------ |--------------:|--------------:|--------------:|---------:|--------:|
|        Stub |      2.069 ns |     0.4461 ns |     0.1158 ns |     1.00 |    0.00 |
|  FakeItEasy | 13,354.168 ns | 1,733.7883 ns |   450.2593 ns | 6,471.02 |  450.78 |
|         Moq |  8,419.628 ns |   713.2147 ns |   185.2196 ns | 4,075.52 |  164.50 |
| NSubstitute | 14,396.515 ns |   884.6727 ns |   229.7467 ns | 6,972.33 |  361.37 |
|       Rocks |  8,118.552 ns | 4,379.2063 ns | 1,137.2660 ns | 3,909.84 |  314.54 |

#### Verify

Verifies that the method was called

|      Method |          Mean |        Error |        StdDev |    Ratio | RatioSD |
|------------ |--------------:|-------------:|--------------:|---------:|--------:|
|        Stub |      5.808 ns |     2.564 ns |     0.6660 ns |     1.00 |    0.00 |
|  FakeItEasy | 15,131.197 ns |   211.793 ns |    55.0019 ns | 2,633.65 |  315.33 |
|         Moq | 10,250.098 ns |   638.245 ns |   165.7501 ns | 1,786.21 |  238.94 |
| NSubstitute | 13,362.496 ns |   265.581 ns |    68.9707 ns | 2,325.42 |  274.58 |
|       Rocks |  8,297.035 ns | 4,441.297 ns | 1,153.3907 ns | 1,431.94 |  144.97 |

#### CallbackOnly

The creation of the mock object and its method setup are done outside the benchmark; only the method's call itself is tested

|      Method |         Mean |       Error |      StdDev |    Ratio | RatioSD |
|------------ |-------------:|------------:|------------:|---------:|--------:|
|        Stub |     1.941 ns |   0.7475 ns |   0.1941 ns |     1.00 |    0.00 |
|  FakeItEasy | 1,967.819 ns | 593.3002 ns | 154.0782 ns | 1,018.12 |   89.67 |
|         Moq |   411.297 ns | 113.5750 ns |  29.4951 ns |   212.34 |    6.22 |
| NSubstitute | 2,861.560 ns | 241.5333 ns |  62.7254 ns | 1,483.63 |  121.73 |
|       Rocks |    22.754 ns |   1.6355 ns |   0.4247 ns |    11.80 |    0.95 |

#### EmptyMethodOnly

The creation of the mock object is done outside the benchmark; only an empty method call itself is tested

|      Method |         Mean |       Error |      StdDev |  Ratio | RatioSD |
|------------ |-------------:|------------:|------------:|-------:|--------:|
|        Stub |     3.492 ns |   1.1114 ns |   0.2886 ns |   1.00 |    0.00 |
|  FakeItEasy | 1,583.685 ns | 665.2041 ns | 172.7514 ns | 454.72 |   46.69 |
|         Moq |   438.276 ns | 230.1989 ns |  59.7819 ns | 125.75 |   15.70 |
| NSubstitute | 2,343.602 ns | 909.2729 ns | 236.1353 ns | 671.56 |   45.35 |
|       Rocks |     3.353 ns |   0.6836 ns |   0.1775 ns |   0.97 |    0.10 |

#### EmptyReturnOnly

The creation of the mock object is done outside the benchmark; only an empty method itself is tested

|      Method |         Mean |      Error |      StdDev |    Ratio | RatioSD |
|------------ |-------------:|-----------:|------------:|---------:|--------:|
|        Stub |     3.110 ns |   1.482 ns |   0.3849 ns |     1.00 |    0.00 |
|  FakeItEasy | 2,047.923 ns | 476.381 ns | 123.7148 ns |   664.00 |   67.01 |
|         Moq |   800.971 ns | 227.355 ns |  59.0435 ns |   261.23 |   41.08 |
| NSubstitute | 3,168.338 ns | 485.015 ns | 125.9569 ns | 1,026.98 |   86.96 |
|       Rocks |     3.218 ns |   1.062 ns |   0.2757 ns |     1.04 |    0.07 |

#### ReturnOnly

The creation of the mock object and its method setup are done outside the benchmark; only the method's call itself is tested

|      Method |         Mean |       Error |      StdDev |  Ratio | RatioSD |
|------------ |-------------:|------------:|------------:|-------:|--------:|
|        Stub |     3.399 ns |   0.6023 ns |   0.1564 ns |   1.00 |    0.00 |
|  FakeItEasy | 2,025.894 ns | 620.3275 ns | 161.0971 ns | 595.58 |   29.50 |
|         Moq |   467.451 ns | 211.5496 ns |  54.9387 ns | 138.06 |   20.38 |
| NSubstitute | 2,530.560 ns | 417.4566 ns | 108.4122 ns | 745.11 |   33.35 |
|       Rocks |    22.340 ns |   7.5976 ns |   1.9731 ns |   6.60 |    0.84 |

#### VerifyOnly

The creation of the mock object and its method call are done outside the benchmark; only the verification itself is tested

|      Method |         Mean |       Error |     StdDev |    Ratio | RatioSD |
|------------ |-------------:|------------:|-----------:|---------:|--------:|
|        Stub |     2.291 ns |   0.7154 ns |  0.1858 ns |     1.00 |    0.00 |
|  FakeItEasy | 2,309.342 ns | 127.8635 ns | 33.2057 ns | 1,012.60 |   70.44 |
|         Moq | 2,283.298 ns | 171.8979 ns | 44.6413 ns | 1,000.58 |   59.65 |
| NSubstitute | 3,046.409 ns | 184.6742 ns | 47.9593 ns | 1,335.26 |   83.49 |
|       Rocks |   186.840 ns |  12.6577 ns |  3.2872 ns |    81.97 |    6.49 |