# BenchmarkMockNet

This repo contains the code for, and results of, a series of performance benchmarks running against various .NET mocking libraries, using [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet).

## Current contenders (alphabetical order)

The baseline is a simple [stub class](ThingStub.cs).

- [FakeItEasy](https://github.com/FakeItEasy/FakeItEasy)
- [Moq](https://github.com/moq/moq4)
- [NSubstitute](http://nsubstitute.github.io/)
- [PCLMock](https://github.com/kentcb/PCLMock)
- [Rocks](https://github.com/JasonBock/Rocks)

Want to add more? PRs welcome! Just add a method to `IMockingBenchmark` and `IMockingBenchmark<T>`, implement it in each of the benchmarks, and add it to the `BenchmarkTestHelpers` methods.

### A note about PCLMock

`PCLMock` is a little different than the other libraries tested here, in that it requires explicitly generated mock classes. Compared against the other contenders, which use underlying parts of the framework like reflection to mock classes more "on the fly", `PCLMock` boasts much higher performance than its more dynamic counterparts, at the cost of some additional effort during development time.

## Tests

These tests cover standard mocking framework functionality

 | Test                                         | How long does it take...                          |
 | -------------------------------------------- | ------------------------------------------------- |
 | [Construction](Results.md#construction)       | for a mock to be created?                         |
 | [Callback](Results.md#callback)               | for a mocked method to perform a callback?        |
 | [EmptyMethod](Results.md#emptymethod)         | for an un-setup method to be called?              |
 | [EmptyReturn](Results.md#emptyreturn)         | for an un-setup method to return default?         |
 | [Return](Results.md#return)                   | for a mocked method to return a value?            |
 | [Verify](Results.md#verify)                   | for verification that a method was called?        |

Each test (other than construction, obviously) also has an "Only" version, where the mock is setup in the constructor, and only the method call itself is measured.

This is more accurate when comparing against larger testing classes, where you have a fixture- or assembly-level setup that doesn't get run with every test.

 | Test                                         | How long does it take...                          |
 | -------------------------------------------- | ------------------------------------------------- |
 | [CallbackOnly](Results.md#callbackonly)       | for an already set-up method to callback?         |
 | [EmptyMethodOnly](Results.md#emptymethodonly) | for an already un-setup method to be called?      |
 | [EmptyReturnOnly](Results.md#emptyreturnonly) | for an already un-setup method to return default? |
 | [ReturnOnly](Results.md#returnonly)           | for an already set-up method to return?           |
 | [VerifyOnly](Results.md#verifyonly)           | for an already set-up method to be verified?      |

Want to add more? PRs welcome! Just add a new class extending `MockingBenchmark` or `MockingBenchmark<T>`, depending on what you're testing.

### Results

Latest official results from the GitHub Actions workflow are available on the [Results](Results.md) page.

## Building/Running from source

### Requirements

- .NET SDK v5.0.400 (or newer)

### Installation

1. Run `dotnet restore` to install all dependent libraries and prep for build
1. Run `dotnet publish -c Release` to build the benchmarks (the `-c Release` flag is important to maximize accuracy)

### Usage

1. Once restored and built, run `dotnet bin/Release/net5.0/publish/BenchmarkMockNet.dll` to execute the benchmarks
2. Benchmarks will take about 5 minutes to run
3. Results are stored in the `BenchmarkDotNet.Artifacts` directory, in both HTML and Markdown formats
