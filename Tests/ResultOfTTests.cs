using FluentAssertions;
using XResults;
using XResults.Exceptions;

namespace Tests;

public class ResultOfTTests
{
    [Fact]
    public void empty_ok_results_in_empty_ok_exception()
    {
        Assert.Throws<ResultCastException>(GetResultWithEmptyOk);
    }

    [Fact]
    public void result_succeds()
    {
        Result<int> result = GetSuccess(123);

        result.IsSuccess.Should().Be(true);
        result.IsFailure.Should().Be(false);
        result.Value.Should().Be(123);
        result.ErrorMessage.Should().Be(null);
    }

    [Fact]
    public void result_fails()
    {
        Result<int> result = GetFailure("error");

        result.IsSuccess.Should().Be(false);
        result.IsFailure.Should().Be(true);
        result.ErrorMessage.Should().Be("error");
        Assert.Throws<OperationFailedException>(() => result.Value);
    }

    [Fact]
    public void result_succeeds_when_only_returning_the_value()
    {
        Result<int> result = GetResultWithoutCallingResultOk(123);

        result.IsSuccess.Should().Be(true);
        result.IsFailure.Should().Be(false);
        result.Value.Should().Be(123);
        result.ErrorMessage.Should().Be(null);
    }

    [Fact]
    public void automatically_cast_result_to_returned_type()
    {
        int value = GetSuccess(123);

        value.Should().Be(123);
    }

    [Fact]
    public void throw_when_trying_to_automatically_cast_result_of_failed_operation_to_returned_type()
    {
        Assert.Throws<OperationFailedException>(() =>
        {
            int value = GetFailure("error");
            return value;
        });
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
