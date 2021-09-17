# BenchmarkMockNet Results  

### Latest Official Run: 2021-09-17

## Construction

This test simply creates an IThingy object to test using the given framework

|      Method |        Mean |        Error |      StdDev |      Median |  Ratio | RatioSD |  Gen 0 |  Gen 1 | Allocated |
|------------ |------------:|-------------:|------------:|------------:|-------:|--------:|-------:|-------:|----------:|
|        Stub |    20.05 ns |    216.27 ns |    11.85 ns |    13.37 ns |   1.00 |    0.00 |      - |      - |      24 B |
|  FakeItEasy | 4,708.86 ns | 22,058.89 ns | 1,209.12 ns | 4,067.39 ns | 262.76 |   70.89 | 0.1600 | 0.0100 |   3,180 B |
|         Moq | 5,539.68 ns | 23,785.33 ns | 1,303.75 ns | 4,797.94 ns | 311.24 |   88.86 | 0.1300 |      - |   2,496 B |
| NSubstitute | 5,701.61 ns | 20,134.18 ns | 1,103.62 ns | 5,066.07 ns | 324.56 |  102.13 | 0.2800 |      - |   5,392 B |
|     PCLMock |    89.30 ns |    957.20 ns |    52.47 ns |    61.59 ns |   4.46 |    0.14 |      - |      - |     144 B |
|       Rocks |    38.63 ns |    368.46 ns |    20.20 ns |    27.01 ns |   1.97 |    0.12 |      - |      - |      48 B |

## Callback

A mock object is created, a method is setup with a callback, and that method is called

|      Method |         Mean |        Error |       StdDev |      Median |  Ratio | RatioSD |  Gen 0 |  Gen 1 | Allocated |
|------------ |-------------:|-------------:|-------------:|------------:|-------:|--------:|-------:|-------:|----------:|
|        Stub |     24.37 ns |    175.69 ns |     9.630 ns |    18.83 ns |   1.00 |    0.00 |      - |      - |      24 B |
|  FakeItEasy | 10,258.51 ns | 32,859.96 ns | 1,801.165 ns | 9,285.59 ns | 442.54 |   82.34 | 0.2800 | 0.0100 |   5,392 B |
|         Moq | 10,014.75 ns | 33,974.40 ns | 1,862.251 ns | 9,006.81 ns | 431.02 |   76.60 | 0.2300 |      - |   4,424 B |
| NSubstitute | 10,316.59 ns | 27,738.51 ns | 1,520.441 ns | 9,470.56 ns | 447.83 |   93.30 | 0.3800 |      - |   7,128 B |
|     PCLMock |  4,004.79 ns | 15,378.63 ns |   842.955 ns | 3,539.88 ns | 171.41 |   27.01 | 0.1100 |      - |   2,072 B |
|       Rocks |  1,584.09 ns |  8,785.41 ns |   481.558 ns | 1,530.05 ns |  66.80 |   12.66 | 0.0600 |      - |   1,200 B |

## EmptyMethod

A mock object is created, with no method setup, and a method with no return value is called

|      Method |        Mean |        Error |       StdDev |      Median |  Ratio | RatioSD |  Gen 0 |  Gen 1 | Allocated |
|------------ |------------:|-------------:|-------------:|------------:|-------:|--------:|-------:|-------:|----------:|
|        Stub |    18.05 ns |    166.50 ns |     9.126 ns |    12.86 ns |   1.00 |    0.00 |      - |      - |      24 B |
|  FakeItEasy | 6,521.28 ns | 32,242.70 ns | 1,767.331 ns | 5,508.29 ns | 386.65 |   75.54 | 0.2100 | 0.0100 |   4,083 B |
|         Moq | 6,263.58 ns | 27,830.09 ns | 1,525.461 ns | 5,395.06 ns | 374.24 |   81.11 | 0.1400 |      - |   2,760 B |
| NSubstitute | 7,901.10 ns | 23,318.50 ns | 1,278.166 ns | 7,191.83 ns | 482.84 |  134.26 | 0.3200 |      - |   6,096 B |
|     PCLMock | 3,173.19 ns | 17,880.91 ns |   980.113 ns | 2,631.24 ns | 186.15 |   30.98 | 0.1000 |      - |   1,872 B |
|       Rocks |    40.06 ns |    347.85 ns |    19.067 ns |    29.51 ns |   2.24 |    0.06 |      - |      - |      48 B |

## EmptyReturn

A mock object is created, with no method setup, and an method returning an `int` is called

|      Method |        Mean |        Error |       StdDev |      Median |  Ratio | RatioSD |  Gen 0 |  Gen 1 | Allocated |
|------------ |------------:|-------------:|-------------:|------------:|-------:|--------:|-------:|-------:|----------:|
|        Stub |    18.37 ns |    165.08 ns |     9.049 ns |    13.26 ns |   1.00 |    0.00 |      - |      - |      24 B |
|  FakeItEasy | 6,362.78 ns | 26,382.90 ns | 1,446.136 ns | 5,600.13 ns | 373.22 |   82.41 | 0.2100 | 0.0100 |   4,132 B |
|         Moq | 6,897.13 ns | 30,219.35 ns | 1,656.425 ns | 5,969.83 ns | 403.10 |   84.61 | 0.1400 |      - |   2,784 B |
| NSubstitute | 8,567.76 ns | 26,967.15 ns | 1,478.160 ns | 7,732.07 ns | 509.94 |  132.95 | 0.3200 |      - |   6,096 B |
|     PCLMock | 3,266.27 ns | 16,286.76 ns |   892.732 ns | 2,767.60 ns | 189.16 |   34.71 | 0.1000 |      - |   1,912 B |
|       Rocks |    40.88 ns |    406.11 ns |    22.260 ns |    28.16 ns |   2.19 |    0.10 |      - |      - |      48 B |

## OneParameter

A mock object is created, with no method setup, and a method with no return value requiring an `int` parameter is called

|      Method |          Mean |        Error |       StdDev |        Median |     Ratio |  RatioSD |  Gen 0 |  Gen 1 |  Gen 2 | Allocated |
|------------ |--------------:|-------------:|-------------:|--------------:|----------:|---------:|-------:|-------:|-------:|----------:|
|        Stub |      17.78 ns |    163.66 ns |     8.971 ns |      12.65 ns |      1.00 |     0.00 |      - |      - |      - |      24 B |
|  FakeItEasy |   6,675.79 ns | 26,415.01 ns | 1,447.896 ns |   5,873.73 ns |    408.00 |    96.50 | 0.2200 | 0.0100 |      - |   4,220 B |
|         Moq |   6,139.50 ns | 31,838.74 ns | 1,745.189 ns |   5,141.73 ns |    368.24 |    67.93 | 0.1400 |      - |      - |   2,792 B |
| NSubstitute |   8,205.23 ns | 25,324.73 ns | 1,388.134 ns |   7,544.83 ns |    508.21 |   139.10 | 0.3200 |      - |      - |   6,128 B |
|     PCLMock | 171,325.69 ns | 10,441.18 ns |   572.317 ns | 171,042.21 ns | 11,088.04 | 4,308.81 | 0.5600 | 0.2800 | 0.0500 |  10,600 B |
|       Rocks |   1,493.70 ns | 11,709.20 ns |   641.821 ns |   1,136.39 ns |     85.92 |     5.66 | 0.0600 |      - |      - |   1,256 B |

## Return

A mock object is created, a method is setup to a return and `int` value, and that method is called

|      Method |         Mean |        Error |      StdDev |      Median |  Ratio | RatioSD |  Gen 0 |  Gen 1 | Allocated |
|------------ |-------------:|-------------:|------------:|------------:|-------:|--------:|-------:|-------:|----------:|
|        Stub |     19.69 ns |    206.95 ns |    11.34 ns |    13.23 ns |   1.00 |    0.00 |      - |      - |      24 B |
|  FakeItEasy |  9,973.77 ns | 32,521.19 ns | 1,782.60 ns | 8,984.04 ns | 576.08 |  181.12 | 0.2700 | 0.0100 |   5,199 B |
|         Moq | 10,519.75 ns | 31,294.08 ns | 1,715.33 ns | 9,552.62 ns | 610.51 |  198.58 | 0.2200 |      - |   4,264 B |
| NSubstitute | 11,089.96 ns | 34,825.96 ns | 1,908.93 ns | 9,988.37 ns | 641.84 |  204.78 | 0.4200 | 0.0100 |   7,888 B |
|     PCLMock |  3,144.82 ns | 18,578.87 ns | 1,018.37 ns | 2,569.28 ns | 173.64 |   36.25 | 0.1000 |      - |   1,912 B |
|       Rocks |  1,572.89 ns |  8,734.27 ns |   478.76 ns | 1,536.99 ns |  88.18 |   26.68 | 0.0500 |      - |   1,120 B |

## Verify

Verifies that the method was called

|      Method |         Mean |        Error |       StdDev |       Median |  Ratio | RatioSD |  Gen 0 |  Gen 1 | Allocated |
|------------ |-------------:|-------------:|-------------:|-------------:|-------:|--------:|-------:|-------:|----------:|
|        Stub |     25.76 ns |    170.15 ns |     9.327 ns |     20.45 ns |   1.00 |    0.00 |      - |      - |      24 B |
|  FakeItEasy | 11,298.89 ns | 34,468.69 ns | 1,889.345 ns | 10,221.01 ns | 456.93 |   76.20 | 0.3000 | 0.0100 |   5,778 B |
|         Moq | 11,560.02 ns | 36,530.28 ns | 2,002.348 ns | 10,436.21 ns | 466.91 |   75.52 | 0.2300 |      - |   4,480 B |
| NSubstitute | 11,901.68 ns | 29,965.67 ns | 1,642.519 ns | 10,986.54 ns | 484.21 |   92.33 | 0.4100 |      - |   7,696 B |
|     PCLMock |  4,310.65 ns | 17,926.44 ns |   982.609 ns |  3,758.42 ns | 172.14 |   20.00 | 0.1400 |      - |   2,736 B |
|       Rocks |  1,846.41 ns | 14,083.19 ns |   771.947 ns |  1,411.44 ns |  70.80 |    3.66 | 0.0600 |      - |   1,296 B |
