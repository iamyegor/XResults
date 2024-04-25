using FluentAssertions;
using Tests.Fixtures;
using XResults;
using XResults.Exceptions;

namespace Tests;

public class ResultOfTAndTErrorTests
{
    [Fact]
    public void result_succeeds()
    {
        Result<int, CustomError> result = Result.Ok(123);

        result.IsSuccess.Should().Be(true);
        result.IsFailure.Should().Be(false);
        result.Error.Should().Be(null);
        result.Value.Should().Be(123);
    }

    [Fact]
    public void result_fails()
    {
        Result<int, CustomError> result = Result.Fail(new CustomError());

        result.IsSuccess.Should().Be(false);
        result.IsFailure.Should().Be(true);
        result.Error.Should().BeOfType<CustomError>();
        Assert.Throws<OperationFailedException>(() => result.Value);
    }

    [Fact]
    public void automatically_convertes_returned_type()
    {
        Result<int, CustomError> result = 123;

        result.IsSuccess.Should().Be(true);
        result.IsFailure.Should().Be(false);
        result.Value.Should().Be(123);
        result.Error.Should().Be(null);
    }

    [Fact]
    public void result_fails_when_only_returning_the_error()
    {
        Result<int, CustomError> result = new CustomError();

        result.IsSuccess.Should().Be(false);
        result.IsFailure.Should().Be(true);
        result.Error.Should().BeOfType<CustomError>();
        Assert.Throws<OperationFailedException>(() => result.Value);
    }

    [Fact]
    public void automatically_cast_result_to_returned_type()
    {
        int value = Result.Ok(123);

        value.Should().Be(123);
    }

    [Fact]
    public void throw_when_trying_to_automatically_cast_result_of_failed_operation_to_returned_type()
    {
        Assert.Throws<OperationFailedException>(() =>
        {
            Result<int, CustomError> resultOfIntAndCustomError = Result.Fail(new CustomError());
            int integer = resultOfIntAndCustomError;
            return integer;
        });
    }
}
