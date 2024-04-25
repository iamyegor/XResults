using FluentAssertions;
using XResults;
using XResults.Exceptions;

namespace Tests;

public class ResultOfTTests
{
    [Fact]
    public void empty_ok_results_in_result_cast_exception()
    {
        Assert.Throws<ResultCastException>(() =>
        {
            Result<int> resultOfInt = Result.Ok();
            return resultOfInt;
        });
    }

    [Fact]
    public void result_succeds()
    {
        Result<int> result = Result.Ok(123);

        result.IsSuccess.Should().Be(true);
        result.IsFailure.Should().Be(false);
        result.Value.Should().Be(123);
        result.ErrorMessage.Should().Be(null);
    }

    [Fact]
    public void result_fails()
    {
        Result<int> result = Result.Fail("error");

        result.IsSuccess.Should().Be(false);
        result.IsFailure.Should().Be(true);
        result.ErrorMessage.Should().Be("error");
        Assert.Throws<OperationFailedException>(() => result.Value);
    }

    [Fact]
    public void automatically_convert_returned_type()
    {
        Result<int> result = 123;

        result.IsSuccess.Should().Be(true);
        result.IsFailure.Should().Be(false);
        result.Value.Should().Be(123);
        result.ErrorMessage.Should().Be(null);
    }

    [Fact]
    public void automatically_cast_result_to_returned_type()
    {
        int value = Result.Ok(123);

        value.Should().Be(123);
    }

    [Fact]
    public void throw_when_casting_result_of_failed_operation_to_returned_type()
    {
        Assert.Throws<OperationFailedException>(() =>
        {
            Result<int> resultOfInt = Result.Fail("error");
            int integer = resultOfInt;
            return integer;
        });
    }
}
