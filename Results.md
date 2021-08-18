# BenchmarkMockNet Results

### Latest Official Run: 2021-08-18

## Construction

This test simply creates an IThingy object to test using the given framework

|      Method |        Mean |        Error |      StdDev |      Median |  Ratio | RatioSD |  Gen 0 |  Gen 1 |  Gen 2 | Allocated |
|------------ |------------:|-------------:|------------:|------------:|-------:|--------:|-------:|-------:|-------:|----------:|
|        Stub |    22.53 ns |    212.11 ns |    11.63 ns |    15.91 ns |   1.00 |    0.00 |      - |      - |      - |      24 B |
|  FakeItEasy | 6,344.52 ns | 27,584.17 ns | 1,511.98 ns | 5,507.18 ns | 305.62 |   69.95 | 0.1200 | 0.0200 | 0.0100 |   3,191 B |
|         Moq | 7,014.58 ns | 27,869.42 ns | 1,527.62 ns | 6,141.97 ns | 339.85 |   82.93 | 0.0900 |      - |      - |   2,496 B |
| NSubstitute | 7,502.63 ns | 29,801.48 ns | 1,633.52 ns | 6,617.89 ns | 363.50 |   88.69 | 0.2000 |      - |      - |   5,392 B |
|     PCLMock |   128.77 ns |  1,639.21 ns |    89.85 ns |    81.49 ns |   5.40 |    0.97 |      - |      - |      - |     144 B |
|       Rocks |    57.15 ns |    717.34 ns |    39.32 ns |    37.27 ns |   2.40 |    0.43 |      - |      - |      - |      48 B |

## Callback

A mock object is created, a method setup with a callback, and that method called

|      Method |         Mean |        Error |      StdDev |       Median |  Ratio | RatioSD |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|------------ |-------------:|-------------:|------------:|-------------:|-------:|--------:|-------:|-------:|------:|----------:|
|        Stub |     68.11 ns |  1,067.82 ns |    58.53 ns |     47.51 ns |   1.00 |    0.00 |      - |      - |     - |      24 B |
|  FakeItEasy | 13,857.12 ns | 48,929.32 ns | 2,681.98 ns | 12,372.81 ns | 331.37 |  228.41 | 0.2000 | 0.0100 |     - |   5,401 B |
|         Moq | 13,375.73 ns | 38,688.93 ns | 2,120.67 ns | 12,303.15 ns | 321.78 |  226.91 | 0.1600 |      - |     - |   4,424 B |
| NSubstitute | 14,602.93 ns | 39,962.73 ns | 2,190.49 ns | 13,411.45 ns | 348.66 |  242.94 | 0.2700 |      - |     - |   7,128 B |
|     PCLMock |  4,778.91 ns | 15,565.63 ns |   853.20 ns |  4,290.38 ns | 114.19 |   78.94 | 0.0700 |      - |     - |   2,072 B |
|       Rocks |  1,542.29 ns | 11,632.29 ns |   637.60 ns |  1,190.68 ns |  36.38 |   24.14 | 0.0400 |      - |     - |   1,200 B |

## EmptyMethod

A mock object is created, with no method setup, and a void method called

|      Method |         Mean |        Error |      StdDev |      Median |  Ratio | RatioSD |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|------------ |-------------:|-------------:|------------:|------------:|-------:|--------:|-------:|-------:|------:|----------:|
|        Stub |     23.51 ns |    196.20 ns |    10.75 ns |    18.11 ns |   1.00 |    0.00 |      - |      - |     - |      24 B |
|  FakeItEasy |  9,472.21 ns | 39,381.19 ns | 2,158.62 ns | 8,422.67 ns | 428.21 |   83.09 | 0.1500 | 0.0100 |     - |   4,010 B |
|         Moq |  8,802.34 ns | 24,990.95 ns | 1,369.84 ns | 8,011.67 ns | 405.49 |  102.84 | 0.1000 |      - |     - |   2,760 B |
| NSubstitute | 10,410.91 ns | 31,077.36 ns | 1,703.45 ns | 9,450.00 ns | 478.67 |  118.84 | 0.2300 |      - |     - |   6,096 B |
|     PCLMock |  3,590.01 ns | 17,116.49 ns |   938.21 ns | 3,143.30 ns | 161.21 |   30.14 | 0.0700 |      - |     - |   1,872 B |
|       Rocks |     48.76 ns |    468.52 ns |    25.68 ns |    34.12 ns |   2.04 |    0.16 |      - |      - |     - |      48 B |

## EmptyReturn

A mock object is created, with no method setup, and an int method called

|      Method |         Mean |        Error |      StdDev |      Median |  Ratio | RatioSD |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|------------ |-------------:|-------------:|------------:|------------:|-------:|--------:|-------:|-------:|------:|----------:|
|        Stub |     21.55 ns |    207.47 ns |    11.37 ns |    15.47 ns |   1.00 |    0.00 |      - |      - |     - |      24 B |
|  FakeItEasy | 10,019.56 ns | 33,860.58 ns | 1,856.01 ns | 8,956.69 ns | 515.29 |  143.64 | 0.1500 | 0.0100 |     - |   4,058 B |
|         Moq |  9,346.25 ns | 31,747.61 ns | 1,740.19 ns | 8,409.38 ns | 480.47 |  133.15 | 0.1000 |      - |     - |   2,784 B |
| NSubstitute | 10,737.02 ns | 31,376.08 ns | 1,719.83 ns | 9,869.23 ns | 556.02 |  164.33 | 0.2300 |      - |     - |   6,096 B |
|     PCLMock |  4,127.74 ns | 12,438.47 ns |   681.79 ns | 3,735.01 ns | 213.50 |   62.64 | 0.0700 |      - |     - |   1,912 B |
|       Rocks |     45.47 ns |    430.46 ns |    23.59 ns |    33.81 ns |   2.12 |    0.20 |      - |      - |     - |      48 B |

## Return

 A mock object is created, a method setup with a return, and that method called

|      Method |         Mean |        Error |      StdDev |       Median |  Ratio | RatioSD |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|------------ |-------------:|-------------:|------------:|-------------:|-------:|--------:|-------:|-------:|------:|----------:|
|        Stub |     21.04 ns |    223.51 ns |    12.25 ns |     13.97 ns |   1.00 |    0.00 |      - |      - |     - |      24 B |
|  FakeItEasy | 13,182.99 ns | 48,565.63 ns | 2,662.05 ns | 11,817.49 ns | 709.80 |  215.12 | 0.1900 | 0.0100 |     - |   5,209 B |
|         Moq | 13,104.19 ns | 31,520.72 ns | 1,727.76 ns | 12,273.05 ns | 720.85 |  253.17 | 0.1600 |      - |     - |   4,264 B |
| NSubstitute | 14,834.53 ns | 30,671.65 ns | 1,681.22 ns | 13,921.65 ns | 820.47 |  297.76 | 0.3000 |      - |     - |   7,888 B |
|     PCLMock |  3,831.24 ns | 12,231.71 ns |   670.46 ns |  3,529.72 ns | 208.05 |   67.25 | 0.0700 |      - |     - |   1,912 B |
|       Rocks |  1,435.96 ns | 11,744.71 ns |   643.77 ns |  1,087.94 ns |  71.43 |    8.41 | 0.0400 |      - |     - |   1,120 B |

## Verify

Verifies that the method was called

|      Method |         Mean |        Error |      StdDev |       Median |  Ratio | RatioSD |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|------------ |-------------:|-------------:|------------:|-------------:|-------:|--------:|-------:|-------:|------:|----------:|
|        Stub |     25.93 ns |    212.93 ns |    11.67 ns |     19.59 ns |   1.00 |    0.00 |      - |      - |     - |      24 B |
|  FakeItEasy | 16,659.79 ns | 47,454.79 ns | 2,601.16 ns | 15,500.34 ns | 693.02 |  168.49 | 0.2100 | 0.0100 |     - |   5,724 B |
|         Moq | 14,555.20 ns | 29,073.80 ns | 1,593.63 ns | 13,714.82 ns | 612.55 |  171.19 | 0.1700 |      - |     - |   4,480 B |
| NSubstitute | 15,183.74 ns | 33,027.28 ns | 1,810.34 ns | 14,260.08 ns | 637.53 |  173.85 | 0.2900 |      - |     - |   7,696 B |
|     PCLMock |  4,915.26 ns | 15,331.68 ns |   840.38 ns |  4,487.64 ns | 203.78 |   47.79 | 0.1000 |      - |     - |   2,736 B |
|       Rocks |  2,029.63 ns | 13,405.44 ns |   734.80 ns |  1,639.82 ns |  80.16 |    7.10 | 0.0400 |      - |     - |   1,296 B |

## CallbackOnly

The creation of the mock object and its method setup are done outside the benchmark; only the method's call itself is tested

|      Method |        Mean |        Error |    StdDev |      Median |  Ratio | RatioSD |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|------------ |------------:|-------------:|----------:|------------:|-------:|--------:|-------:|-------:|------:|----------:|
|        Stub |    25.58 ns |    335.26 ns |  18.38 ns |    15.42 ns |   1.00 |    0.00 |      - |      - |     - |         - |
|  FakeItEasy | 2,601.20 ns |  7,205.72 ns | 394.97 ns | 2,506.23 ns | 128.03 |   56.20 | 0.0300 | 0.0100 |     - |     976 B |
|         Moq |   503.73 ns |  1,793.17 ns |  98.29 ns |   510.58 ns |  24.67 |   11.24 |      - |      - |     - |     184 B |
| NSubstitute | 1,816.35 ns |  5,575.62 ns | 305.62 ns | 1,639.91 ns |  88.53 |   36.67 | 0.0100 |      - |     - |     352 B |
|     PCLMock | 2,439.56 ns | 13,988.25 ns | 766.74 ns | 2,089.81 ns | 112.88 |   37.68 | 0.0200 |      - |     - |     584 B |
|       Rocks |   150.54 ns |    299.62 ns |  16.42 ns |   144.73 ns |   7.50 |    3.36 |      - |      - |     - |         - |

## EmptyMethodOnly

The creation of the mock object is done outside the benchmark; only an empty method call itself is tested

|      Method |         Mean |         Error |     StdDev |  Ratio | RatioSD |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|------------ |-------------:|--------------:|-----------:|-------:|--------:|-------:|-------:|------:|----------:|
|        Stub |     7.569 ns |     35.426 ns |   1.942 ns |   1.00 |    0.00 |      - |      - |     - |         - |
|  FakeItEasy | 3,533.817 ns |  8,424.995 ns | 461.802 ns | 477.61 |   70.75 | 0.0300 | 0.0200 |     - |     832 B |
|         Moq |   455.379 ns |  1,764.190 ns |  96.701 ns |  60.58 |    2.89 |      - |      - |     - |     208 B |
| NSubstitute | 1,405.790 ns |  4,975.111 ns | 272.703 ns | 187.92 |   20.64 |      - |      - |     - |     232 B |
|     PCLMock | 1,956.143 ns | 12,221.887 ns | 669.923 ns | 255.14 |   21.78 | 0.0200 |      - |     - |     560 B |
|       Rocks |     7.596 ns |     33.002 ns |   1.809 ns |   1.01 |    0.05 |      - |      - |     - |         - |

## EmptyReturnOnly

The creation of the mock object is done outside the benchmark; only an empty method itself is tested

|      Method |         Mean |        Error |     StdDev |       Median |  Ratio | RatioSD |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|------------ |-------------:|-------------:|-----------:|-------------:|-------:|--------:|-------:|-------:|------:|----------:|
|        Stub |     7.141 ns |    52.734 ns |   2.891 ns |     5.573 ns |   1.00 |    0.00 |      - |      - |     - |         - |
|  FakeItEasy | 3,678.668 ns | 6,800.396 ns | 372.753 ns | 3,491.175 ns | 552.81 |  140.16 | 0.0300 | 0.0200 |     - |     880 B |
|         Moq | 1,014.228 ns | 3,306.162 ns | 181.222 ns | 1,063.972 ns | 151.16 |   39.84 |      - |      - |     - |     232 B |
| NSubstitute | 1,413.260 ns | 5,949.857 ns | 326.132 ns | 1,263.947 ns | 206.18 |   30.95 |      - |      - |     - |     232 B |
|     PCLMock | 1,972.386 ns | 9,826.604 ns | 538.629 ns | 1,876.235 ns | 285.75 |   47.13 | 0.0200 |      - |     - |     584 B |
|       Rocks |     7.249 ns |    61.889 ns |   3.392 ns |     5.394 ns |   1.00 |    0.07 |      - |      - |     - |         - |

## ReturnOnly

The creation of the mock object and its method setup are done outside the benchmark; only the method's call itself is tested

|      Method |         Mean |         Error |     StdDev |  Ratio | RatioSD |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|------------ |-------------:|--------------:|-----------:|-------:|--------:|-------:|-------:|------:|----------:|
|        Stub |     6.977 ns |     40.810 ns |   2.237 ns |   1.00 |    0.00 |      - |      - |     - |         - |
|  FakeItEasy | 2,358.587 ns |  3,187.623 ns | 174.724 ns | 354.06 |   74.86 | 0.0300 | 0.0200 |     - |     792 B |
|         Moq |   505.720 ns |  1,008.775 ns |  55.294 ns |  75.47 |   14.19 |      - |      - |     - |     184 B |
| NSubstitute | 1,146.104 ns |  3,289.116 ns | 180.288 ns | 171.40 |   42.04 | 0.0100 |      - |     - |     288 B |
|     PCLMock | 2,083.621 ns | 11,681.962 ns | 640.328 ns | 300.59 |   40.11 | 0.0200 |      - |     - |     584 B |
|       Rocks |   125.549 ns |    165.765 ns |   9.086 ns |  18.87 |    4.11 |      - |      - |     - |         - |

## VerifyOnly

The creation of the mock object and its method call are done outside the benchmark; only the verification itself is tested

|      Method |         Mean |         Error |       StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |-------------:|--------------:|-------------:|-------:|--------:|-------:|------:|------:|----------:|
|        Stub |     7.970 ns |     48.111 ns |     2.637 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|  FakeItEasy | 3,244.635 ns | 19,155.012 ns | 1,049.951 ns | 408.63 |   50.02 | 0.0600 |     - |     - |   1,688 B |
|         Moq | 3,564.755 ns | 17,132.796 ns |   939.106 ns | 453.20 |   27.22 | 0.0600 |     - |     - |   1,720 B |
| NSubstitute | 3,393.670 ns | 15,629.651 ns |   856.714 ns | 432.45 |   31.02 | 0.0600 |     - |     - |   1,600 B |
|     PCLMock | 1,821.236 ns |  9,685.507 ns |   530.895 ns | 230.30 |    8.43 | 0.0300 |     - |     - |     864 B |
|       Rocks | 1,050.835 ns |  2,047.544 ns |   112.233 ns | 139.24 |   37.37 |      - |     - |     - |     184 B |