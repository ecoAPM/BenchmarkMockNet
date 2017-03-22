# BenchmarkMockNet
Using BenchmarkDotNet to compare .NET Core mocking library performance
---

This repo contains the code for -- and results of -- a series of benchmarks around the functionality of some of .NET Core's mocking libraries.

The baseline is a simple [stub](https://github.com/stevedesmond-ca/BenchmarkMockNet/blob/master/ThingStub.cs).

Current contenders:
- [Moq](https://github.com/moq/moq4)
- [NSubstitute](http://nsubstitute.github.io/)
- [FakeItEasy](https://github.com/FakeItEasy/FakeItEasy)

## Tests

| Test                                    | How long does it take...                   |
| --------------------------------------- | ------------------------------------------ |
| [Construction](README.md#Construction)  | for a mock to be created?                  |
| [Return](README.md#Return)              | for a mocked method to return a value?     |
| [Callback](README.md#Callback)          | for a mocked method to perform a callback? |
| [ReturnOnly](README.md#ReturnOnly)      | for an already set-up method to return?    |
| [CallbackOnly](README.md#CallbackOnly)  | for an already set-up method to callback?  |

### Results

#### Construction

 |      Method |          Mean |     StdErr |      StdDev |   Scaled | Scaled-StdDev |
 |------------ |-------------- |----------- |------------ |--------- |-------------- |
 |        Stub |     2.1949 ns |  0.0231 ns |   0.0894 ns |     1.00 |          0.00 |
 |         Moq | 6,293.1911 ns |  9.1317 ns |  34.1676 ns | 2,871.64 |        114.86 |
 | NSubstitute | 6,739.5962 ns | 22.2654 ns |  77.1296 ns | 3,075.34 |        126.53 |
 |  FakeItEasy | 9,261.7292 ns | 33.2922 ns | 128.9401 ns | 4,226.21 |        176.98 |
 
 #### Return
 
 |      Method |            Mean |        StdDev |     Scaled | Scaled-StdDev |
 |------------ |---------------- |-------------- |----------- |-------------- |
 |        Stub |       2.4094 ns |     0.0723 ns |       1.00 |          0.00 |
 |         Moq | 272,697.1116 ns | 3,356.3097 ns | 113,271.91 |      3,481.06 |
 | NSubstitute |  22,203.9582 ns |   617.9905 ns |   9,223.00 |        360.35 |
 |  FakeItEasy |  47,689.6951 ns |   469.7247 ns |  19,809.17 |        592.15 |
 
 #### Callback
 
 |      Method |            Mean |        StdDev |     Scaled | Scaled-StdDev |
 |------------ |---------------- |-------------- |----------- |-------------- |
 |        Stub |       2.5612 ns |     0.0207 ns |       1.00 |          0.00 |
 |         Moq | 270,366.5277 ns | 3,979.4413 ns | 105,568.47 |      1,709.85 |
 | NSubstitute |  23,511.6314 ns |   819.9942 ns |   9,180.45 |        317.42 |
 |  FakeItEasy |  64,550.7406 ns |   791.1672 ns |  25,204.76 |        356.75 |
 
 #### ReturnOnly
 
 |      Method |          Mean |     StdDev |   Scaled | Scaled-StdDev |
 |------------ |-------------- |----------- |--------- |-------------- |
 |        Stub |     1.2374 ns |  0.0191 ns |     1.00 |          0.00 |
 |         Moq | 1,418.4927 ns | 34.1364 ns | 1,146.56 |         31.62 |
 | NSubstitute | 4,405.8734 ns | 65.8834 ns | 3,561.24 |         73.96 |

_FakeItEasy grows linearly on every run_ **PR me**
 
 #### CallbackOnly
 
 |      Method |           Mean |      StdDev |   Scaled | Scaled-StdDev |
 |------------ |--------------- |------------ |--------- |-------------- |
 |        Stub |      1.2623 ns |   0.0241 ns |     1.00 |          0.00 |
 |         Moq |  2,278.6389 ns |  54.4263 ns | 1,805.77 |         53.22 |
 | NSubstitute | 11,676.3577 ns | 421.3845 ns | 9,253.26 |        364.83 |

_FakeItEasy grows linearly on every run_ **PR me**
