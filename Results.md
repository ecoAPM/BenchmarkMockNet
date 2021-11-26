# BenchmarkMockNet Results

## Official Run: 11/24/2021

| Framework | Version |
|-----------|---------|
| FakeItEasy | 7.0.0.0 |
| Telerik.JustMock | 2021.3.1110.1 |
| Moq | 4.16.0.0 |
| NSubstitute | 4.2.0.0 |
| Moq | 4.16.0.0 |
| Rocks | 6.3.0.0 |

### Construction

This test simply creates an `IThing` object to test using the given framework

|       Method |         Mean |        Error |       StdDev |       Median |    Ratio | RatioSD |  Gen 0 | Allocated |
|------------- |-------------:|-------------:|-------------:|-------------:|---------:|--------:|-------:|----------:|
|         Stub |     21.35 ns |     77.90 ns |     20.23 ns |     12.01 ns |     1.00 |    0.00 |      - |      24 B |
|   FakeItEasy |  7,874.84 ns | 23,403.26 ns |  6,077.75 ns |  6,373.65 ns |   401.44 |   97.31 | 0.1000 |   3,137 B |
| JustMockLite | 47,295.87 ns | 54,561.38 ns | 14,169.42 ns | 38,980.24 ns | 2,921.57 |  945.81 | 0.6000 |  16,834 B |
|          Moq |  9,859.78 ns | 17,933.75 ns |  4,657.34 ns |  7,990.33 ns |   569.65 |  144.37 |      - |   2,432 B |
|  NSubstitute | 10,196.57 ns | 22,013.32 ns |  5,716.79 ns |  8,678.95 ns |   569.23 |  144.82 | 0.2000 |   5,344 B |
|      PCLMock |     92.34 ns |    358.72 ns |     93.16 ns |     50.41 ns |     4.20 |    0.19 |      - |     144 B |
|        Rocks |    185.53 ns |    484.59 ns |    125.85 ns |    130.55 ns |     9.84 |    1.55 |      - |     224 B |

### Return

A mock object is created, a method is setup to a return and `int` value, and that method is called

|       Method |          Mean |        Error |       StdDev |        Median |     Ratio |  RatioSD |  Gen 0 |  Gen 1 | Allocated |
|------------- |--------------:|-------------:|-------------:|--------------:|----------:|---------:|-------:|-------:|----------:|
|         Stub |      21.01 ns |     69.78 ns |     18.12 ns |      12.69 ns |      1.00 |     0.00 |      - |      - |      24 B |
|   FakeItEasy |  15,186.59 ns | 30,931.62 ns |  8,032.84 ns |  12,817.72 ns |    834.01 |   228.39 | 0.2000 |      - |   5,161 B |
| JustMockLite | 220,847.06 ns | 77,110.69 ns | 20,025.40 ns | 211,571.54 ns | 14,114.85 | 5,246.31 | 1.3000 | 0.6000 |  34,245 B |
|          Moq |  14,749.53 ns | 32,406.30 ns |  8,415.81 ns |  13,189.78 ns |    802.17 |   282.14 | 0.1000 |      - |   4,184 B |
|  NSubstitute |  16,839.13 ns | 31,565.87 ns |  8,197.56 ns |  13,844.27 ns |    938.70 |   255.60 | 0.3000 |      - |   7,841 B |
|      PCLMock |   5,602.47 ns |  4,056.50 ns |  1,053.46 ns |   5,161.65 ns |    346.54 |   116.35 |      - |      - |   1,896 B |
|        Rocks |     665.48 ns |  1,204.03 ns |    312.68 ns |     531.42 ns |     37.22 |     8.17 |      - |      - |     744 B |

### EmptyReturn

A mock object is created, with no method setup, and an method returning an `int` is called

|       Method |         Mean |        Error |       StdDev |       Median |    Ratio |  RatioSD |  Gen 0 |  Gen 1 | Allocated |
|------------- |-------------:|-------------:|-------------:|-------------:|---------:|---------:|-------:|-------:|----------:|
|         Stub |     21.02 ns |     70.39 ns |     18.28 ns |     12.67 ns |     1.00 |     0.00 |      - |      - |      24 B |
|   FakeItEasy | 11,056.27 ns | 23,633.58 ns |  6,137.57 ns |  8,464.19 ns |   600.46 |   109.58 | 0.1000 |      - |   4,073 B |
| JustMockLite | 61,078.32 ns | 71,307.47 ns | 18,518.32 ns | 50,306.88 ns | 3,645.89 | 1,085.06 | 0.8000 | 0.1000 |  20,652 B |
|          Moq | 11,372.71 ns | 20,695.06 ns |  5,374.44 ns |  9,673.23 ns |   637.74 |   148.26 | 0.1000 |      - |   2,720 B |
|  NSubstitute | 13,703.08 ns | 26,419.66 ns |  6,861.10 ns | 12,850.67 ns |   763.48 |   217.78 | 0.2000 |      - |   6,048 B |
|      PCLMock |  5,018.14 ns |  7,207.32 ns |  1,871.72 ns |  5,372.80 ns |   298.86 |   121.73 |      - |      - |   1,896 B |
|        Rocks |    669.30 ns |  1,294.45 ns |    336.16 ns |    520.01 ns |    37.10 |     7.64 |      - |      - |     744 B |

### EmptyMethod

A mock object is created, with no method setup, and a method with no return value is called

|       Method |         Mean |        Error |       StdDev |       Median |    Ratio |  RatioSD |  Gen 0 |  Gen 1 | Allocated |
|------------- |-------------:|-------------:|-------------:|-------------:|---------:|---------:|-------:|-------:|----------:|
|         Stub |     19.53 ns |     67.60 ns |     17.56 ns |     11.46 ns |     1.00 |     0.00 |      - |      - |      24 B |
|   FakeItEasy | 10,904.02 ns | 25,071.01 ns |  6,510.86 ns |  8,647.45 ns |   636.46 |   118.06 | 0.1000 |      - |   4,025 B |
| JustMockLite | 58,663.69 ns | 62,002.33 ns | 16,101.81 ns | 50,440.68 ns | 3,871.61 | 1,207.45 | 0.8000 | 0.1000 |  20,540 B |
|          Moq | 11,611.09 ns | 18,535.71 ns |  4,813.67 ns |  9,622.20 ns |   728.30 |   188.87 | 0.1000 |      - |   2,696 B |
|  NSubstitute | 13,337.06 ns | 27,610.92 ns |  7,170.47 ns | 12,808.96 ns |   803.46 |   258.45 | 0.2000 |      - |   6,048 B |
|      PCLMock |  5,624.16 ns |  3,878.12 ns |  1,007.14 ns |  5,186.53 ns |   384.38 |   135.64 |      - |      - |   1,857 B |
|        Rocks |    644.96 ns |  1,139.88 ns |    296.02 ns |    513.87 ns |    39.77 |     9.48 |      - |      - |     736 B |

### OneParameter

A mock object is created, with no method setup, and a method with no return value requiring an `int` parameter is called

|       Method |          Mean |        Error |       StdDev |        Median |     Ratio |  RatioSD |  Gen 0 |  Gen 1 | Allocated |
|------------- |--------------:|-------------:|-------------:|--------------:|----------:|---------:|-------:|-------:|----------:|
|         Stub |      18.80 ns |     61.74 ns |     16.03 ns |      11.45 ns |      1.00 |     0.00 |      - |      - |      24 B |
|   FakeItEasy |  11,287.15 ns | 24,234.66 ns |  6,293.66 ns |   8,757.62 ns |    678.97 |   124.93 | 0.1000 |      - |   4,161 B |
| JustMockLite |  58,990.18 ns | 63,696.61 ns | 16,541.81 ns |  50,687.78 ns |  3,926.25 | 1,158.76 | 0.8000 | 0.1000 |  21,013 B |
|          Moq |  11,426.25 ns | 18,514.58 ns |  4,808.18 ns |   9,473.87 ns |    723.47 |   172.53 | 0.1000 |      - |   2,728 B |
|  NSubstitute |  12,751.85 ns | 28,410.01 ns |  7,377.99 ns |  10,838.73 ns |    762.64 |   210.78 | 0.2000 |      - |   6,080 B |
|      PCLMock | 149,882.47 ns | 29,512.75 ns |  7,664.37 ns | 146,913.46 ns | 10,786.08 | 4,155.59 | 0.4000 | 0.2000 |  10,503 B |
|        Rocks |     850.00 ns |  1,594.65 ns |    414.13 ns |     669.53 ns |     52.52 |    10.98 |      - |      - |     856 B |

### Callback

A mock object is created, a method is setup with a callback, and that method is called

|       Method |          Mean |        Error |       StdDev |        Median |     Ratio |  RatioSD |  Gen 0 |  Gen 1 | Allocated |
|------------- |--------------:|-------------:|-------------:|--------------:|----------:|---------:|-------:|-------:|----------:|
|         Stub |      25.14 ns |     76.40 ns |     19.84 ns |      16.10 ns |      1.00 |     0.00 |      - |      - |      24 B |
|   FakeItEasy |  16,499.24 ns | 31,253.75 ns |  8,116.50 ns |  14,416.96 ns |    739.33 |   192.49 | 0.2000 |      - |   5,345 B |
| JustMockLite | 230,028.74 ns | 82,056.61 ns | 21,309.84 ns | 221,200.67 ns | 11,737.53 | 4,114.81 | 1.3000 | 0.6000 |  34,068 B |
|          Moq |  14,982.50 ns | 32,883.98 ns |  8,539.87 ns |  13,245.74 ns |    656.36 |   216.08 | 0.1000 |      - |   4,344 B |
|  NSubstitute |  15,481.23 ns | 30,965.08 ns |  8,041.53 ns |  12,720.47 ns |    686.02 |   170.15 | 0.2000 |      - |   7,080 B |
|      PCLMock |   6,426.51 ns |  4,667.67 ns |  1,212.18 ns |   6,076.51 ns |    318.35 |   100.73 |      - |      - |   2,056 B |
|        Rocks |     716.44 ns |  1,263.14 ns |    328.03 ns |     569.22 ns |     32.33 |     6.08 |      - |      - |     824 B |

### Verify

Verifies that the method was called

|       Method |          Mean |        Error |       StdDev |        Median |    Ratio |  RatioSD |  Gen 0 |  Gen 1 | Allocated |
|------------- |--------------:|-------------:|-------------:|--------------:|---------:|---------:|-------:|-------:|----------:|
|         Stub |      24.80 ns |     76.88 ns |     19.96 ns |      15.96 ns |     1.00 |     0.00 |      - |      - |      24 B |
|   FakeItEasy |  17,271.96 ns | 33,430.60 ns |  8,681.82 ns |  16,192.30 ns |   790.55 |   236.56 | 0.2000 |      - |   5,729 B |
| JustMockLite | 118,388.48 ns | 85,197.39 ns | 22,125.49 ns | 108,399.06 ns | 5,996.26 | 1,902.87 | 1.6000 | 0.4000 |  40,670 B |
|          Moq |  16,019.05 ns | 30,048.57 ns |  7,803.52 ns |  14,890.23 ns |   737.84 |   227.14 | 0.1000 |      - |   4,392 B |
|  NSubstitute |  17,331.52 ns | 33,247.80 ns |  8,634.35 ns |  16,010.11 ns |   791.59 |   208.16 | 0.3000 |      - |   7,649 B |
|      PCLMock |   7,192.65 ns |  8,387.01 ns |  2,178.08 ns |   7,373.85 ns |   357.89 |   135.54 | 0.1000 |      - |   2,712 B |
|        Rocks |     941.42 ns |  1,750.45 ns |    454.59 ns |     744.51 ns |    43.03 |     7.92 |      - |      - |     920 B |

