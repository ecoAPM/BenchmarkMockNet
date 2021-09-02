# BenchmarkMockNet Results

### Latest Official Run: 2021-09-02

## Construction

This test simply creates an IThingy object to test using the given framework

|      Method |        Mean |        Error |       StdDev |      Median |  Ratio | RatioSD |  Gen 0 |  Gen 1 | Allocated |
|------------ |------------:|-------------:|-------------:|------------:|-------:|--------:|-------:|-------:|----------:|
|        Stub |    20.02 ns |    170.91 ns |     9.368 ns |    15.02 ns |   1.00 |    0.00 |      - |      - |      24 B |
|  FakeItEasy | 5,115.23 ns | 23,792.40 ns | 1,304.142 ns | 4,375.04 ns | 270.79 |   49.35 | 0.1600 | 0.0100 |   3,180 B |
|         Moq | 5,624.45 ns | 23,656.63 ns | 1,296.700 ns | 4,921.73 ns | 299.70 |   60.76 | 0.1300 |      - |   2,496 B |
| NSubstitute | 6,264.42 ns | 26,214.91 ns | 1,436.928 ns | 5,447.73 ns | 333.81 |   67.14 | 0.2800 |      - |   5,392 B |
|     PCLMock |   105.63 ns |    866.43 ns |    47.492 ns |    78.89 ns |   5.31 |    0.13 |      - |      - |     144 B |
|       Rocks |    43.85 ns |    342.55 ns |    18.776 ns |    34.50 ns |   2.21 |    0.09 |      - |      - |      48 B |

## Callback

A mock object is created, a method setup with a callback, and that method called

|      Method |         Mean |        Error |      StdDev |  Ratio | RatioSD |  Gen 0 |  Gen 1 | Allocated |
|------------ |-------------:|-------------:|------------:|-------:|--------:|-------:|-------:|----------:|
|        Stub |     26.69 ns |    190.58 ns |    10.45 ns |   1.00 |    0.00 |      - |      - |      24 B |
|  FakeItEasy | 10,631.86 ns | 30,893.03 ns | 1,693.35 ns | 420.12 |   84.71 | 0.2800 | 0.0100 |   5,392 B |
|         Moq | 10,352.39 ns | 26,711.00 ns | 1,464.12 ns | 410.71 |   88.75 | 0.2300 |      - |   4,424 B |
| NSubstitute | 10,399.85 ns | 29,275.21 ns | 1,604.67 ns | 411.39 |   84.49 | 0.3800 |      - |   7,128 B |
|     PCLMock |  3,989.09 ns | 16,514.83 ns |   905.23 ns | 155.26 |   22.78 | 0.1100 |      - |   2,072 B |
|       Rocks |  1,624.60 ns |  7,532.68 ns |   412.89 ns |  62.85 |    7.93 | 0.0600 |      - |   1,200 B |

## EmptyMethod

A mock object is created, with no method setup, and a void method called

|      Method |        Mean |        Error |      StdDev |      Median |  Ratio | RatioSD |  Gen 0 |  Gen 1 | Allocated |
|------------ |------------:|-------------:|------------:|------------:|-------:|--------:|-------:|-------:|----------:|
|        Stub |    20.01 ns |    203.10 ns |    11.13 ns |    14.14 ns |   1.00 |    0.00 |      - |      - |      24 B |
|  FakeItEasy | 6,336.41 ns | 26,874.13 ns | 1,473.06 ns | 5,492.96 ns | 351.03 |   93.47 | 0.2100 | 0.0100 |   4,083 B |
|         Moq | 6,394.45 ns | 22,998.21 ns | 1,260.61 ns | 5,673.37 ns | 358.03 |  104.57 | 0.1400 |      - |   2,760 B |
| NSubstitute | 8,381.43 ns | 27,913.50 ns | 1,530.03 ns | 7,516.83 ns | 471.27 |  142.16 | 0.3200 |      - |   6,096 B |
|     PCLMock | 3,122.31 ns | 19,176.16 ns | 1,051.11 ns | 2,517.60 ns | 167.56 |   31.67 | 0.1000 |      - |   1,872 B |
|       Rocks |    43.64 ns |    381.19 ns |    20.89 ns |    33.18 ns |   2.24 |    0.15 |      - |      - |      48 B |

## EmptyReturn

A mock object is created, with no method setup, and an int method called

|      Method |        Mean |        Error |       StdDev |      Median |  Ratio | RatioSD |  Gen 0 |  Gen 1 | Allocated |
|------------ |------------:|-------------:|-------------:|------------:|-------:|--------:|-------:|-------:|----------:|
|        Stub |    19.69 ns |    175.09 ns |     9.597 ns |    14.91 ns |   1.00 |    0.00 |      - |      - |      24 B |
|  FakeItEasy | 6,575.13 ns | 26,359.57 ns | 1,444.857 ns | 5,752.06 ns | 360.40 |   82.50 | 0.2100 | 0.0100 |   4,132 B |
|         Moq | 6,986.35 ns | 25,981.71 ns | 1,424.145 ns | 6,211.91 ns | 384.74 |   93.85 | 0.1400 |      - |   2,784 B |
| NSubstitute | 8,534.37 ns | 26,039.82 ns | 1,427.330 ns | 7,718.67 ns | 474.45 |  127.45 | 0.3200 |      - |   6,096 B |
|     PCLMock | 3,204.30 ns | 18,191.98 ns |   997.164 ns | 2,633.42 ns | 171.32 |   27.35 | 0.1000 |      - |   1,912 B |
|       Rocks |    42.82 ns |    349.96 ns |    19.182 ns |    32.46 ns |   2.20 |    0.10 |      - |      - |      48 B |

## Return

 A mock object is created, a method setup with a return, and that method called

|      Method |         Mean |        Error |       StdDev |       Median |  Ratio | RatioSD |  Gen 0 |  Gen 1 | Allocated |
|------------ |-------------:|-------------:|-------------:|-------------:|-------:|--------:|-------:|-------:|----------:|
|        Stub |     19.19 ns |    169.13 ns |     9.271 ns |     14.30 ns |   1.00 |    0.00 |      - |      - |      24 B |
|  FakeItEasy | 10,131.31 ns | 36,073.62 ns | 1,977.317 ns |  8,995.59 ns | 571.74 |  137.11 | 0.2700 | 0.0100 |   5,199 B |
|         Moq | 10,068.77 ns | 27,052.28 ns | 1,482.827 ns |  9,225.80 ns | 575.44 |  158.58 | 0.2200 |      - |   4,264 B |
| NSubstitute | 11,331.67 ns | 27,772.85 ns | 1,522.324 ns | 10,464.41 ns | 649.76 |  184.94 | 0.4200 | 0.0100 |   7,888 B |
|     PCLMock |  3,217.24 ns | 18,767.15 ns | 1,028.691 ns |  2,631.43 ns | 175.55 |   25.02 | 0.1000 |      - |   1,912 B |
|       Rocks |  1,555.03 ns |  8,962.65 ns |   491.273 ns |  1,533.62 ns |  85.44 |   19.74 | 0.0500 |      - |   1,120 B |

## Verify

Verifies that the method was called

|      Method |         Mean |        Error |      StdDev |       Median |  Ratio | RatioSD |  Gen 0 |  Gen 1 | Allocated |
|------------ |-------------:|-------------:|------------:|-------------:|-------:|--------:|-------:|-------:|----------:|
|        Stub |     24.71 ns |    215.96 ns |    11.84 ns |     18.27 ns |   1.00 |    0.00 |      - |      - |      24 B |
|  FakeItEasy | 11,017.38 ns | 37,079.76 ns | 2,032.47 ns |  9,845.29 ns | 483.24 |  117.49 | 0.3000 | 0.0100 |   5,777 B |
|         Moq | 10,841.74 ns | 28,366.02 ns | 1,554.84 ns | 10,010.30 ns | 480.63 |  131.34 | 0.2300 |      - |   4,480 B |
| NSubstitute | 12,093.00 ns | 29,203.49 ns | 1,600.74 ns | 11,189.96 ns | 537.66 |  151.50 | 0.4100 |      - |   7,696 B |
|     PCLMock |  4,274.89 ns | 17,785.45 ns |   974.88 ns |  3,720.95 ns | 185.37 |   38.97 | 0.1400 |      - |   2,736 B |
|       Rocks |  1,804.96 ns | 14,075.41 ns |   771.52 ns |  1,368.89 ns |  74.13 |    3.99 | 0.0600 |      - |   1,296 B |