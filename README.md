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

|      Method |          Mean |        Error |      StdDev |   Scaled | ScaledSD |
|------------ |--------------:|-------------:|------------:|---------:|---------:|
|        Stub |      6.659 ns |     2.764 ns |   0.7179 ns |     1.00 |     0.00 |
|  FakeItEasy | 11,759.713 ns |   454.849 ns | 118.1454 ns | 1,780.79 |   154.90 |
|         Moq |  4,438.464 ns |   244.415 ns |  63.4859 ns |   672.12 |    58.79 |
| NSubstitute |  5,726.808 ns |   260.085 ns |  67.5561 ns |   867.22 |    75.59 |
|       Rocks |  3,788.702 ns | 3,704.371 ns | 962.1967 ns |   573.73 |   139.91 |

#### Callback

A mock object is created, a method setup with a callback, and that method called

|      Method |          Mean |        Error |        StdDev |   Scaled | ScaledSD |
|------------ |--------------:|-------------:|--------------:|---------:|---------:|
|        Stub |      5.253 ns |     2.547 ns |     0.6615 ns |     1.00 |     0.00 |
|  FakeItEasy | 47,654.720 ns | 1,987.234 ns |   516.1767 ns | 9,174.62 |   913.74 |
|         Moq |  8,770.916 ns |   394.929 ns |   102.5813 ns | 1,688.60 |   168.31 |
| NSubstitute | 15,155.472 ns |   218.178 ns |    56.6710 ns | 2,917.78 |   289.37 |
|       Rocks |  7,854.532 ns | 4,645.665 ns | 1,206.6942 ns | 1,512.18 |   257.03 |

#### EmptyMethod

A mock object is created, with no method setup, and a void method called

|      Method |          Mean |         Error |      StdDev |    Scaled | ScaledSD |
|------------ |--------------:|--------------:|------------:|----------:|---------:|
|        Stub |      1.916 ns |     0.5551 ns |   0.1442 ns |      1.00 |     0.00 |
|  FakeItEasy | 23,136.351 ns | 1,654.8670 ns | 429.8455 ns | 12,128.23 |   830.17 |
|         Moq |  4,758.669 ns |   212.0068 ns |  55.0680 ns |  2,494.53 |   167.63 |
| NSubstitute | 11,516.917 ns |   388.7963 ns | 100.9884 ns |  6,037.24 |   403.63 |
|       Rocks |  3,757.167 ns | 3,720.3574 ns | 966.3490 ns |  1,969.53 |   472.54 |

#### EmptyReturn

A mock object is created, with no method setup, and an int method called

|      Method |          Mean |         Error |      StdDev |    Scaled | ScaledSD |
|------------ |--------------:|--------------:|------------:|----------:|---------:|
|        Stub |      2.141 ns |     0.8435 ns |   0.2191 ns |      1.00 |     0.00 |
|  FakeItEasy | 23,243.319 ns | 1,859.2916 ns | 482.9441 ns | 10,943.45 |   955.92 |
|         Moq |  5,292.765 ns |   262.5680 ns |  68.2011 ns |  2,491.95 |   214.60 |
| NSubstitute | 12,617.985 ns |   322.2223 ns |  83.6960 ns |  5,940.82 |   508.20 |
|       Rocks |  3,744.236 ns | 3,625.7178 ns | 941.7667 ns |  1,762.87 |   425.51 |

#### Return

 A mock object is created, a method setup with a return, and that method called

|      Method |          Mean |         Error |        StdDev |    Scaled | ScaledSD |
|------------ |--------------:|--------------:|--------------:|----------:|---------:|
|        Stub |      2.111 ns |     0.5955 ns |     0.1547 ns |      1.00 |     0.00 |
|  FakeItEasy | 45,354.683 ns | 2,775.1171 ns |   720.8263 ns | 21,574.78 | 1,449.12 |
|         Moq | 11,737.904 ns |   261.7736 ns |    67.9947 ns |  5,583.61 |   367.65 |
| NSubstitute | 19,128.425 ns |   544.4572 ns |   141.4207 ns |  9,099.20 |   600.30 |
|       Rocks |  8,047.362 ns | 4,548.2656 ns | 1,181.3951 ns |  3,828.05 |   562.92 |

#### Verify

Verifies that the method was called

|      Method |          Mean |        Error |        StdDev |   Scaled | ScaledSD |
|------------ |--------------:|-------------:|--------------:|---------:|---------:|
|        Stub |      5.421 ns |     2.826 ns |     0.7339 ns |     1.00 |     0.00 |
|  FakeItEasy | 52,010.805 ns | 2,120.052 ns |   550.6757 ns | 9,723.63 | 1,074.29 |
|         Moq |  9,927.486 ns |   400.920 ns |   104.1376 ns | 1,855.98 |   205.04 |
| NSubstitute | 17,271.550 ns |   239.594 ns |    62.2336 ns | 3,228.99 |   355.57 |
|       Rocks |  8,902.708 ns | 6,463.000 ns | 1,678.7402 ns | 1,664.40 |   336.63 |

#### CallbackOnly

The creation of the mock object and its method setup are done outside the benchmark; only the method's call itself is tested

|      Method |          Mean |          Error |        StdDev |   Scaled | ScaledSD |
|------------ |--------------:|---------------:|--------------:|---------:|---------:|
|        Stub |      2.086 ns |      0.9412 ns |     0.2445 ns |     1.00 |     0.00 |
|  FakeItEasy | 19,727.865 ns | 38,188.8068 ns | 9,919.4005 ns | 9,563.62 | 4,437.73 |
|         Moq |    410.185 ns |    122.4038 ns |    31.7939 ns |   198.85 |    24.93 |
| NSubstitute |  4,182.076 ns |    270.1042 ns |    70.1586 ns | 2,027.38 |   213.51 |
|       Rocks |     23.134 ns |      0.6595 ns |     0.1713 ns |    11.21 |     1.17 |

#### EmptyMethodOnly

The creation of the mock object is done outside the benchmark; only an empty method call itself is tested

|      Method |          Mean |          Error |         StdDev |   Scaled | ScaledSD |
|------------ |--------------:|---------------:|---------------:|---------:|---------:|
|        Stub |      3.316 ns |      0.8390 ns |      0.2179 ns |     1.00 |     0.00 |
|  FakeItEasy | 23,191.044 ns | 45,643.8157 ns | 11,855.8113 ns | 7,019.00 | 3,241.63 |
|         Moq |    434.064 ns |    222.2236 ns |     57.7218 ns |   131.37 |    17.47 |
| NSubstitute |  3,745.566 ns |    254.1618 ns |     66.0176 ns | 1,133.63 |    69.28 |
|       Rocks |      3.360 ns |      1.6770 ns |      0.4356 ns |     1.02 |     0.13 |

#### EmptyReturnOnly

The creation of the mock object is done outside the benchmark; only an empty method itself is tested

|      Method |          Mean |          Error |         StdDev |   Scaled | ScaledSD |
|------------ |--------------:|---------------:|---------------:|---------:|---------:|
|        Stub |      3.046 ns |      1.0342 ns |      0.2686 ns |     1.00 |     0.00 |
|  FakeItEasy | 24,715.367 ns | 47,994.7272 ns | 12,466.4518 ns | 8,160.73 | 3,736.40 |
|         Moq |    689.166 ns |    199.2590 ns |     51.7568 ns |   227.55 |    22.29 |
| NSubstitute |  4,377.139 ns |    313.7320 ns |     81.4907 ns | 1,445.28 |   105.62 |
|       Rocks |      3.015 ns |      0.7124 ns |      0.1850 ns |     1.00 |     0.09 |

#### ReturnOnly

The creation of the mock object and its method setup are done outside the benchmark; only the method's call itself is tested

|      Method |          Mean |          Error |        StdDev |   Scaled | ScaledSD |
|------------ |--------------:|---------------:|--------------:|---------:|---------:|
|        Stub |      3.322 ns |      0.6730 ns |     0.1748 ns |     1.00 |     0.00 |
|  FakeItEasy | 16,297.547 ns | 30,322.5410 ns | 7,876.1672 ns | 4,916.27 | 2,139.20 |
|         Moq |    870.410 ns |    137.8692 ns |    35.8110 ns |   262.57 |    15.44 |
| NSubstitute |  4,408.761 ns |    264.2877 ns |    68.6478 ns | 1,329.93 |    63.70 |
|       Rocks |     19.675 ns |      2.1524 ns |     0.5591 ns |     5.94 |     0.31 |

#### VerifyOnly

The creation of the mock object and its method call are done outside the benchmark; only the verification itself is tested

|      Method |         Mean |       Error |     StdDev |   Scaled | ScaledSD |
|------------ |-------------:|------------:|-----------:|---------:|---------:|
|        Stub |     2.254 ns |   0.6634 ns |  0.1723 ns |     1.00 |     0.00 |
|  FakeItEasy | 8,855.920 ns | 140.6020 ns | 36.5208 ns | 3,947.52 |   262.83 |
|         Moq | 2,218.557 ns |  80.7221 ns | 20.9673 ns |   988.92 |    66.27 |
| NSubstitute | 3,525.986 ns |  49.8206 ns | 12.9407 ns | 1,571.71 |   104.61 |
|       Rocks |   179.575 ns |   7.6692 ns |  1.9921 ns |    80.05 |     5.38 |