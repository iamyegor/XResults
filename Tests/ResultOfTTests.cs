using FluentAssertions;
using Results;
using Results.Exceptions;

namespace Tests;

public class ResultOfTTests
{
    [Fact]
    public void empty_ok_results_in_empty_ok_exception()
    {
        Assert.Throws<EmptyOkException>(GetResultWithEmptyOk);
    }

    [Fact]
    public void result_succeds()
    {
        Result<int> result = GetSuccess(123);

        result.IsSuccess.Should().Be(true);
        result.Value.Should().Be(123);
        result.ErrorMessage.Should().Be(null);
    }

    [Fact]
    public void result_fails()
    {
        Result<int> result = GetFailure("error");

        result.IsSuccess.Should().Be(false);
        result.ErrorMessage.Should().Be("error");
        Assert.Throws<OperationFailedException>(() => result.Value);
    }

    [Fact]
    public void result_succeeds_when_only_returning_the_value()
    {
        Result<int> result = GetResultWithoutCallingResultOk(123);

        result.IsSuccess.Should().Be(true);
        result.Value.Should().Be(123);
        result.ErrorMessage.Should().Be(null);
    }

    private Result<int> GetResultWithEmptyOk()
    {
        return Result.Ok();
    }

    private Result<int> GetSuccess(int value)
    {
        return Result.Ok(value);
    }

    private Result<int> GetFailure(string errorMessage)
    {
        return Result.Fail(errorMessage);
    }

    private Result<int> GetResultWithoutCallingResultOk(int value)
    {
        return value;
    }
}
