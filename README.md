# BenchmarkMockNet

This repo contains the code for, and results of, a series of performance benchmarks running against various .NET mocking libraries, using [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet).

[![Results](https://img.shields.io/badge/Results-latest-darkgreen?logo=github)](https://github.com/ecoAPM/BenchmarkMockNet/blob/main/Results.md)
[![CI](https://github.com/ecoAPM/BenchmarkMockNet/actions/workflows/CI.yml/badge.svg)](https://github.com/ecoAPM/BenchmarkMockNet/actions/workflows/CI.yml)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=ecoAPM_BenchmarkMockNet&metric=coverage)](https://sonarcloud.io/dashboard?id=ecoAPM_BenchmarkMockNet)

[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=ecoAPM_BenchmarkMockNet&metric=sqale_rating)](https://sonarcloud.io/dashboard?id=ecoAPM_BenchmarkMockNet)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=ecoAPM_BenchmarkMockNet&metric=reliability_rating)](https://sonarcloud.io/dashboard?id=ecoAPM_BenchmarkMockNet)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=ecoAPM_BenchmarkMockNet&metric=security_rating)](https://sonarcloud.io/dashboard?id=ecoAPM_BenchmarkMockNet)

## Current contenders (alphabetical order)

The baseline is a simple [stub class](BenchmarkMockNet/ThingStub.cs).

- [FakeItEasy](https://fakeiteasy.github.io)
- [JustMockLite](https://www.telerik.com/justmock/free-mocking)
- [Moq](https://www.moqthis.com/moq4/)
- [NSubstitute](http://nsubstitute.github.io/)
- [PCLMock](https://github.com/kentcb/PCLMock)
- [Rocks](https://github.com/JasonBock/Rocks)

Want to add more? PRs welcome!
- Add a method named after the framework to
	- `IMockingBenchmark`
	- `IMockingBenchmark<T>`
	- `MockingBenchmark`
	- `MockingBenchmark<T>`
- Implement it in each of classes in the `Benchmarks` directory
- Add a reference to it in `All.Frameworks`

### A note about PCLMock

`PCLMock` is a little different than the other libraries tested here, in that it requires explicitly generated mock classes. Compared against the other contenders, which use underlying parts of the framework like reflection to mock classes more "on the fly", `PCLMock` boasts improved performance over its more dynamic counterparts, at the cost of some additional effort during development time.

## Tests

These tests cover standard mocking framework functionality

| Test                                     | How long does it take...                           |
| ---------------------------------------- | -------------------------------------------------- |
| [Construction](Results.md#construction)  | for a mock to be created?                          |
| [Return](Results.md#return)              | for a mocked method to return a value?             |
| [EmptyReturn](Results.md#emptyreturn)    | for a mocked method to return default?             |
| [EmptyMethod](Results.md#emptymethod)    | for a mocked method to be called?                  |
| [OneParameter](Results.md#oneparameter)  | for a mocked method to be called with a parameter? |
| [Callback](Results.md#callback)          | for a mocked method to perform a callback?         |
| [Verify](Results.md#verify)              | for verification that a method was called?         |

Want to add more? PRs welcome! Add a new class extending `MockingBenchmark` or `MockingBenchmark<T>`, depending on what you're testing, and a test case to `BenchmarkTests` with the relevant assertion.

### Results

Latest official results from the GitHub Actions workflow are available on the [Results](Results.md) page.

## Building/Running from source

### Requirements

- .NET SDK 8

### Installation

1. Run `dotnet restore` to install all dependent libraries and prep for build
1. Run `dotnet publish -c Release` to build the benchmarks (the `-c Release` flag is important to maximize accuracy)

### Usage

1. Once restored and built, run `dotnet bin/Release/net9.0/publish/BenchmarkMockNet.dll` to execute the benchmarks
2. Benchmarks will take about 5 minutes to run
3. Results are stored in the `BenchmarkDotNet.Artifacts` directory, in both HTML and Markdown formats
