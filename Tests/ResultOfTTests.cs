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
    public void create_successful_result()
    {
        Result<int> result = Result<int>.Create(true, 123);

        result.IsSuccess.Should().Be(true);
        result.IsFailure.Should().Be(false);
        result.Value.Should().Be(123);
        result.ErrorMessage.Should().Be(null);
    }

    [Fact]
    public void create_failed_result()
    {
        Result<int> result = Result<int>.Create(false, 0, "error");

        result.IsSuccess.Should().Be(false);
        result.IsFailure.Should().Be(true);
        Assert.Throws<OperationFailedException>(() => result.Value);
        result.ErrorMessage.Should().Be("error");
    }

    [Fact]
    public void throw_when_creating_successful_result_with_error_message()
    {
        Assert.Throws<Exception>(() => Result<int>.Create(true, 0, "error"));
    }
    
    [Fact]
    public void throw_when_creating_failed_result_with_value()
    {
        Assert.Throws<Exception>(() => Result<int>.Create(false, 123, "error"));
    }
}
