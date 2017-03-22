# BenchmarkMockNet
Using BenchmarkDotNet to compare .NET Core mocking library performance

---

This repo contains the code for -- and results of -- a series of benchmarks around the functionality of some of .NET Core's mocking libraries.

The baseline is a simple [stub](https://github.com/stevedesmond-ca/BenchmarkMockNet/blob/master/ThingStub.cs).

## Current contenders
- [Moq](https://github.com/moq/moq4)
- [NSubstitute](http://nsubstitute.github.io/)
- [FakeItEasy](https://github.com/FakeItEasy/FakeItEasy)

Want to add more? PRs welcome! Just add a method to IMockingBenchmark and IMockingBenchmark<T> and implement it in each of the tests.

## Tests

| Test                                    | How long does it take...                      |
| ----------------------------------------| ----------------------------------------------|
| [Construction](README.md#construction)  | for a mock to be created?                     |
| [Callback](README.md#callback)          | for a mocked method to perform a callback?    |
| [CallbackOnly](README.md#callbackonly)  | for an already set-up method to callback?     |
| [Return](README.md#return)              | for a mocked method to return a value?        |
| [ReturnOnly](README.md#returnonly)      | for an already set-up method to return?       |
| [Verify](README.md#verify        )      | for verification that a method was called?    |
| [VerifyOnly](README.md#verifyonly)      | for an already set-up method to be verified?  |

Want to add more? PRs welcome! Just add a new class implementing IMockingBenchmark or IMockingBenchmark<T> depending on what you're testing.

### Results

#### Construction

This test simply creates an IThingy object to test using the given framework


 |      Method |          Mean |     StdErr |      StdDev |   Scaled | Scaled-StdDev |
 |-------------|--------------:|-----------:|------------:|---------:|--------------:|
 |        Stub |     2.1949 ns |  0.0231 ns |   0.0894 ns |     1.00 |          0.00 |
 |         Moq | 6,293.1911 ns |  9.1317 ns |  34.1676 ns | 2,871.64 |        114.86 |
 | NSubstitute | 6,739.5962 ns | 22.2654 ns |  77.1296 ns | 3,075.34 |        126.53 |
 |  FakeItEasy | 9,261.7292 ns | 33.2922 ns | 128.9401 ns | 4,226.21 |        176.98 |
 
 #### Callback
 
 A mock object is created, a method setup with a callback, and that method called
 
 |      Method |            Mean |        StdDev |     Scaled | Scaled-StdDev |
 |-------------|----------------:|--------------:|-----------:|--------------:|
 |        Stub |       2.5612 ns |     0.0207 ns |       1.00 |          0.00 |
 |         Moq | 270,366.5277 ns | 3,979.4413 ns | 105,568.47 |      1,709.85 |
 | NSubstitute |  23,511.6314 ns |   819.9942 ns |   9,180.45 |        317.42 |
 |  FakeItEasy |  64,550.7406 ns |   791.1672 ns |  25,204.76 |        356.75 |
 
 #### CallbackOnly
 
 The creation of the mock object and its method setup are done outside the benchmark; only the method's call itself is tested
 
 |      Method |           Mean |      StdDev |   Scaled | Scaled-StdDev |
 |-------------|---------------:|------------:|---------:|--------------:|
 |        Stub |      1.2623 ns |   0.0241 ns |     1.00 |          0.00 |
 |         Moq |  2,278.6389 ns |  54.4263 ns | 1,805.77 |         53.22 |
 | NSubstitute | 11,676.3577 ns | 421.3845 ns | 9,253.26 |        364.83 |

_FakeItEasy grows linearly on every run_ **PR me**

#### Return
 
 A mock object is created, a method setup with a return, and that method called
 
 |      Method |            Mean |        StdDev |     Scaled | Scaled-StdDev |
 |-------------|----------------:|--------------:|-----------:|--------------:|
 |        Stub |       2.4094 ns |     0.0723 ns |       1.00 |          0.00 |
 |         Moq | 272,697.1116 ns | 3,356.3097 ns | 113,271.91 |      3,481.06 |
 | NSubstitute |  22,203.9582 ns |   617.9905 ns |   9,223.00 |        360.35 |
 |  FakeItEasy |  47,689.6951 ns |   469.7247 ns |  19,809.17 |        592.15 |
 
 #### ReturnOnly
 
 The creation of the mock object and its method setup are done outside the benchmark; only the method's call itself is tested
 
 |      Method |          Mean |     StdDev |   Scaled | Scaled-StdDev |
 |-------------|--------------:|-----------:|---------:|--------------:|
 |        Stub |     1.2374 ns |  0.0191 ns |     1.00 |          0.00 |
 |         Moq | 1,418.4927 ns | 34.1364 ns | 1,146.56 |         31.62 |
 | NSubstitute | 4,405.8734 ns | 65.8834 ns | 3,561.24 |         73.96 |

_FakeItEasy grows linearly on every run_ **PR me**
 
#### Verify

Verifies that the method was called

 |      Method |            Mean |        StdDev |    Scaled | Scaled-StdDev |
 |-------------|----------------:|--------------:|----------:|--------------:|
 |        Stub |       2.6372 ns |     0.0127 ns |      1.00 |          0.00 |
 |         Moq | 253,361.6548 ns | 1,541.0106 ns | 96,074.55 |        719.64 |
 | NSubstitute |  20,552.2987 ns |   756.1497 ns |  7,793.42 |        279.39 |
 |  FakeItEasy |  63,925.6919 ns |   482.9032 ns | 24,240.58 |        209.95 |

 #### VerifyOnly

 The creation of the mock object and its method call are done outside the benchmark; only the verification itself is tested

 |      Method |            Mean |        StdDev |     Scaled | Scaled-StdDev |
 |-------------|----------------:|--------------:|-----------:|--------------:|
 |        Stub |       1.8545 ns |     0.0235 ns |       1.00 |          0.00 |
 |         Moq | 234,728.7162 ns | 2,997.9582 ns | 126,588.05 |      2,190.56 |
 | NSubstitute |   4,029.1028 ns |   125.5826 ns |   2,172.88 |         70.54 |
 |  FakeItEasy |  20,678.2945 ns |   177.7530 ns |  11,151.70 |        163.96 |
