# BenchmarkMockNet Results

### Latest Official Run: 2021-08-18

## Construction

This test simply creates an IThingy object to test using the given framework

|      Method |        Mean |        Error |      StdDev |      Median |  Ratio | RatioSD |  Gen 0 |  Gen 1 | Allocated |
|------------ |------------:|-------------:|------------:|------------:|-------:|--------:|-------:|-------:|----------:|
|        Stub |    23.31 ns |    196.60 ns |    10.78 ns |    17.71 ns |   1.00 |    0.00 |      - |      - |      24 B |
|  FakeItEasy | 5,847.86 ns | 26,505.02 ns | 1,452.83 ns | 5,016.17 ns | 265.77 |   48.83 | 0.1600 | 0.0100 |   3,180 B |
|         Moq | 6,681.89 ns | 23,857.84 ns | 1,307.73 ns | 5,942.02 ns | 307.82 |   69.01 | 0.1300 |      - |   2,496 B |
| NSubstitute | 7,476.60 ns | 28,669.80 ns | 1,571.49 ns | 6,608.68 ns | 343.12 |   72.89 | 0.2800 |      - |   5,392 B |
|     PCLMock |   120.82 ns |  1,116.37 ns |    61.19 ns |    88.18 ns |   5.12 |    0.21 |      - |      - |     144 B |
|       Rocks |    47.90 ns |    403.58 ns |    22.12 ns |    36.48 ns |   2.06 |    0.00 |      - |      - |      48 B |

## Callback

A mock object is created, a method setup with a callback, and that method called

|      Method |         Mean |        Error |      StdDev |       Median |  Ratio | RatioSD |  Gen 0 |  Gen 1 | Allocated |
|------------ |-------------:|-------------:|------------:|-------------:|-------:|--------:|-------:|-------:|----------:|
|        Stub |     29.77 ns |    193.09 ns |    10.58 ns |     24.07 ns |   1.00 |    0.00 |      - |      - |      24 B |
|  FakeItEasy | 13,180.93 ns | 35,708.93 ns | 1,957.33 ns | 12,197.25 ns | 462.18 |   81.90 | 0.2800 | 0.0100 |   5,392 B |
|         Moq | 12,744.21 ns | 24,861.10 ns | 1,362.72 ns | 12,011.98 ns | 450.69 |   95.62 | 0.2300 |      - |   4,424 B |
| NSubstitute | 12,753.48 ns | 25,275.31 ns | 1,385.43 ns | 12,206.96 ns | 450.86 |   94.89 | 0.3800 |      - |   7,128 B |
|     PCLMock |  4,671.52 ns | 15,606.84 ns |   855.46 ns |  4,192.72 ns | 162.66 |   24.25 | 0.1100 |      - |   2,072 B |
|       Rocks |  1,484.97 ns | 12,570.58 ns |   689.04 ns |  1,098.35 ns |  48.74 |    4.84 | 0.0600 |      - |   1,200 B |

## EmptyMethod

A mock object is created, with no method setup, and a void method called

|      Method |        Mean |        Error |       StdDev |      Median |  Ratio | RatioSD |  Gen 0 |  Gen 1 | Allocated |
|------------ |------------:|-------------:|-------------:|------------:|-------:|--------:|-------:|-------:|----------:|
|        Stub |    22.40 ns |    181.71 ns |     9.960 ns |    17.81 ns |   1.00 |    0.00 |      - |      - |      24 B |
|  FakeItEasy | 9,962.64 ns | 29,130.93 ns | 1,596.765 ns | 9,335.17 ns | 478.64 |  114.75 | 0.2100 | 0.0100 |   4,019 B |
|         Moq | 7,947.53 ns | 20,866.77 ns | 1,143.778 ns | 7,483.36 ns | 384.42 |  104.44 | 0.1400 |      - |   2,760 B |
| NSubstitute | 9,812.65 ns | 26,354.09 ns | 1,444.557 ns | 8,994.83 ns | 473.45 |  122.00 | 0.3200 |      - |   6,096 B |
|     PCLMock | 3,859.07 ns | 14,276.11 ns |   782.522 ns | 3,439.65 ns | 183.57 |   38.94 | 0.1000 |      - |   1,872 B |
|       Rocks |    50.67 ns |    377.61 ns |    20.698 ns |    40.21 ns |   2.29 |    0.26 |      - |      - |      48 B |

## EmptyReturn

A mock object is created, with no method setup, and an int method called

|      Method |         Mean |        Error |      StdDev |      Median |  Ratio | RatioSD |  Gen 0 |  Gen 1 | Allocated |
|------------ |-------------:|-------------:|------------:|------------:|-------:|--------:|-------:|-------:|----------:|
|        Stub |     22.85 ns |    213.23 ns |    11.69 ns |    16.64 ns |   1.00 |    0.00 |      - |      - |      24 B |
|  FakeItEasy |  9,825.94 ns | 31,640.15 ns | 1,734.30 ns | 8,849.83 ns | 474.24 |  130.26 | 0.2100 | 0.0100 |   4,067 B |
|         Moq |  7,737.95 ns | 27,718.33 ns | 1,519.34 ns | 6,916.89 ns | 371.48 |   97.08 | 0.1400 |      - |   2,784 B |
| NSubstitute | 10,152.14 ns | 28,237.74 ns | 1,547.81 ns | 9,445.23 ns | 493.59 |  146.34 | 0.3200 |      - |   6,096 B |
|     PCLMock |  3,793.83 ns | 16,408.04 ns |   899.38 ns | 3,296.24 ns | 180.00 |   41.06 | 0.1000 |      - |   1,912 B |
|       Rocks |     51.29 ns |    354.29 ns |    19.42 ns |    44.07 ns |   2.35 |    0.43 |      - |      - |      48 B |

## Return

 A mock object is created, a method setup with a return, and that method called

|      Method |         Mean |        Error |      StdDev |       Median |  Ratio | RatioSD |  Gen 0 |  Gen 1 | Allocated |
|------------ |-------------:|-------------:|------------:|-------------:|-------:|--------:|-------:|-------:|----------:|
|        Stub |     28.70 ns |    363.22 ns |    19.91 ns |     17.93 ns |   1.00 |    0.00 |      - |      - |      24 B |
|  FakeItEasy | 12,182.61 ns | 41,011.83 ns | 2,248.00 ns | 10,902.85 ns | 517.75 |  202.59 | 0.2700 | 0.0100 |   5,199 B |
|         Moq | 12,211.64 ns | 28,060.37 ns | 1,538.08 ns | 11,338.13 ns | 529.62 |  225.84 | 0.2200 |      - |   4,264 B |
| NSubstitute | 13,896.11 ns | 30,978.13 ns | 1,698.02 ns | 13,089.08 ns | 603.34 |  257.83 | 0.4200 | 0.0100 |   7,888 B |
|     PCLMock |  3,767.62 ns | 17,659.30 ns |   967.97 ns |  3,210.64 ns | 156.03 |   53.81 | 0.1000 |      - |   1,912 B |
|       Rocks |  1,447.83 ns | 12,259.59 ns |   671.99 ns |  1,064.00 ns |  55.47 |   11.02 | 0.0500 |      - |   1,120 B |

## Verify

Verifies that the method was called

|      Method |         Mean |        Error |      StdDev |       Median |  Ratio | RatioSD |  Gen 0 |  Gen 1 | Allocated |
|------------ |-------------:|-------------:|------------:|-------------:|-------:|--------:|-------:|-------:|----------:|
|        Stub |     28.74 ns |    206.90 ns |    11.34 ns |     22.81 ns |   1.00 |    0.00 |      - |      - |      24 B |
|  FakeItEasy | 14,773.14 ns | 36,994.12 ns | 2,027.77 ns | 13,626.63 ns | 545.20 |  119.05 | 0.3000 | 0.0100 |   5,713 B |
|         Moq | 12,880.04 ns | 26,570.22 ns | 1,456.40 ns | 12,288.04 ns | 478.20 |  115.87 | 0.2300 |      - |   4,480 B |
| NSubstitute | 13,909.80 ns | 30,507.12 ns | 1,672.20 ns | 12,954.02 ns | 515.25 |  119.28 | 0.4100 |      - |   7,696 B |
|     PCLMock |  4,934.05 ns | 16,984.39 ns |   930.97 ns |  4,403.15 ns | 180.02 |   31.97 | 0.1400 |      - |   2,736 B |
|       Rocks |  2,059.59 ns | 13,228.94 ns |   725.12 ns |  1,646.51 ns |  72.40 |    3.23 | 0.0600 |      - |   1,296 B |

## CallbackOnly

The creation of the mock object and its method setup are done outside the benchmark; only the method's call itself is tested

|      Method |        Mean |        Error |     StdDev |  Ratio | RatioSD |  Gen 0 |  Gen 1 | Allocated |
|------------ |------------:|-------------:|-----------:|-------:|--------:|-------:|-------:|----------:|
|        Stub |    16.26 ns |     45.45 ns |   2.491 ns |   1.00 |    0.00 |      - |      - |         - |
|  FakeItEasy | 3,030.15 ns |  9,270.38 ns | 508.141 ns | 186.16 |    3.35 | 0.0500 | 0.0300 |     976 B |
|         Moq |   498.86 ns |  2,023.56 ns | 110.918 ns |  30.64 |    4.70 |      - |      - |     184 B |
| NSubstitute | 1,799.79 ns |  6,139.63 ns | 336.534 ns | 110.40 |    5.25 | 0.0100 |      - |     352 B |
|     PCLMock | 2,444.07 ns | 14,979.77 ns | 821.092 ns | 147.77 |   25.90 | 0.0300 |      - |     584 B |
|       Rocks |   122.05 ns |    208.40 ns |  11.423 ns |   7.55 |    0.51 |      - |      - |         - |

## EmptyMethodOnly

The creation of the mock object is done outside the benchmark; only an empty method call itself is tested

|      Method |         Mean |         Error |     StdDev |  Ratio | RatioSD |  Gen 0 |  Gen 1 | Allocated |
|------------ |-------------:|--------------:|-----------:|-------:|--------:|-------:|-------:|----------:|
|        Stub |     7.318 ns |     30.939 ns |   1.696 ns |   1.00 |    0.00 |      - |      - |         - |
|  FakeItEasy | 3,906.146 ns | 12,100.321 ns | 663.259 ns | 539.96 |   55.04 | 0.0400 | 0.0300 |     832 B |
|         Moq |   729.346 ns |    809.738 ns |  44.384 ns | 102.64 |   20.62 | 0.0100 |      - |     208 B |
| NSubstitute | 1,602.418 ns |  5,541.974 ns | 303.774 ns | 220.87 |   25.31 | 0.0100 |      - |     232 B |
|     PCLMock | 2,136.307 ns | 13,051.003 ns | 715.370 ns | 287.97 |   50.82 | 0.0200 |      - |     560 B |
|       Rocks |     6.877 ns |     35.271 ns |   1.933 ns |   0.94 |    0.10 |      - |      - |         - |

## EmptyReturnOnly

The creation of the mock object is done outside the benchmark; only an empty method itself is tested

|      Method |         Mean |         Error |     StdDev |       Median |  Ratio | RatioSD |  Gen 0 |  Gen 1 | Allocated |
|------------ |-------------:|--------------:|-----------:|-------------:|-------:|--------:|-------:|-------:|----------:|
|        Stub |     8.405 ns |     75.344 ns |   4.130 ns |     6.021 ns |   1.00 |    0.00 |      - |      - |         - |
|  FakeItEasy | 4,272.859 ns | 12,187.862 ns | 668.058 ns | 4,138.243 ns | 559.41 |  160.45 | 0.0400 | 0.0300 |     880 B |
|         Moq | 1,173.112 ns |  3,322.144 ns | 182.098 ns | 1,228.755 ns | 155.13 |   52.16 | 0.0100 |      - |     232 B |
| NSubstitute | 1,636.554 ns |  5,072.460 ns | 278.039 ns | 1,719.324 ns | 215.78 |   72.14 | 0.0100 |      - |     232 B |
|     PCLMock | 2,146.416 ns | 14,194.929 ns | 778.072 ns | 2,011.492 ns | 266.81 |   58.64 | 0.0300 |      - |     584 B |
|       Rocks |     7.730 ns |     32.316 ns |   1.771 ns |     7.614 ns |   1.00 |    0.27 |      - |      - |         - |

## ReturnOnly

The creation of the mock object and its method setup are done outside the benchmark; only the method's call itself is tested

|      Method |         Mean |         Error |     StdDev |       Median |  Ratio | RatioSD |  Gen 0 |  Gen 1 | Allocated |
|------------ |-------------:|--------------:|-----------:|-------------:|-------:|--------:|-------:|-------:|----------:|
|        Stub |     6.495 ns |     40.363 ns |   2.212 ns |     5.219 ns |   1.00 |    0.00 |      - |      - |         - |
|  FakeItEasy | 2,574.047 ns |  6,425.487 ns | 352.203 ns | 2,398.714 ns | 412.70 |   72.48 | 0.0400 | 0.0200 |     792 B |
|         Moq |   437.022 ns |  1,363.661 ns |  74.747 ns |   423.511 ns |  69.75 |   12.02 |      - |      - |     184 B |
| NSubstitute | 1,060.443 ns |  3,012.884 ns | 165.146 ns | 1,013.804 ns | 169.58 |   29.13 | 0.0100 |      - |     288 B |
|     PCLMock | 1,942.937 ns | 12,369.585 ns | 678.019 ns | 1,554.315 ns | 298.62 |    2.28 | 0.0300 |      - |     584 B |
|       Rocks |   104.943 ns |    189.666 ns |  10.396 ns |    98.957 ns |  16.95 |    3.49 |      - |      - |         - |

## VerifyOnly

The creation of the mock object and its method call are done outside the benchmark; only the verification itself is tested

|      Method |         Mean |         Error |     StdDev |       Median |  Ratio | RatioSD |  Gen 0 | Allocated |
|------------ |-------------:|--------------:|-----------:|-------------:|-------:|--------:|-------:|----------:|
|        Stub |     6.884 ns |     33.842 ns |   1.855 ns |     6.020 ns |   1.00 |    0.00 |      - |         - |
|  FakeItEasy | 2,975.886 ns | 16,656.855 ns | 913.018 ns | 2,451.581 ns | 429.91 |   20.51 | 0.0900 |   1,688 B |
|         Moq | 3,373.669 ns | 15,588.395 ns | 854.453 ns | 2,882.385 ns | 491.65 |   18.75 | 0.0900 |   1,720 B |
| NSubstitute | 3,042.079 ns | 14,468.571 ns | 793.071 ns | 2,588.145 ns | 442.77 |   15.02 | 0.0800 |   1,600 B |
|     PCLMock | 2,158.663 ns | 14,783.524 ns | 810.335 ns | 1,704.797 ns | 308.44 |   32.66 | 0.0400 |     864 B |
|       Rocks | 1,067.056 ns |  1,862.293 ns | 102.079 ns | 1,008.669 ns | 159.46 |   24.99 |      - |     184 B |