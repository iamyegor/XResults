using FluentAssertions;
using Results;
using Results.Exceptions;
using Tests.Fixtures;

namespace Tests;

public class ResultOfTAndTErrorTests
{
    [Fact]
    public void result_succeeds()
    {
        Result<int, CustomError> result = GetSuccess(123);

        result.IsSuccess.Should().Be(true);
        result.IsFailure.Should().Be(false);
        result.Error.Should().Be(null);
        result.Value.Should().Be(123);
    }

    [Fact]
    public void result_fails()
    {
        Result<int, CustomError> result = GetFailure(new CustomError());

        result.IsSuccess.Should().Be(false);
        result.IsFailure.Should().Be(true);
        result.Error.Should().BeOfType<CustomError>();
        Assert.Throws<OperationFailedException>(() => result.Value);
    }

    [Fact]
    public void result_succeeds_when_only_returning_the_value()
    {
        Result<int, CustomError> result = GetSuccessWithoutCallingResultOk(123);

        result.IsSuccess.Should().Be(true);
        result.IsFailure.Should().Be(false);
        result.Value.Should().Be(123);
        result.Error.Should().Be(null);
    }

    [Fact]
    public void result_fails_when_only_returning_the_error()
    {
        Result<int, CustomError> result = GetFailureWithoutCallingResultFail();

        result.IsSuccess.Should().Be(false);
        result.IsFailure.Should().Be(true);
        result.Error.Should().BeOfType<CustomError>();
        Assert.Throws<OperationFailedException>(() => result.Value);
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
            int value = GetFailure(new CustomError());
            return value;
        });
    }

    private Result<int, CustomError> GetSuccess(int value)
    {
        return Result.Ok(value);
    }

    private Result<int, CustomError> GetFailure(CustomError error)
    {
        return Result.Fail(error);
    }

    private Result<int, CustomError> GetSuccessWithoutCallingResultOk(int value)
    {
        return value;
    }

    private Result<int, CustomError> GetFailureWithoutCallingResultFail()
    {
        return new CustomError();
    }
}
