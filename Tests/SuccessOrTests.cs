using FluentAssertions;
using Results;
using Tests.Fixtures;

namespace Tests;

public class SuccessOrTests
{
    [Fact]
    public void result_succeeds()
    {
        SuccessOr<CustomError> result = GetSuccess();

        result.IsSuccess.Should().Be(true);
        result.IsFailure.Should().Be(false);
        result.Error.Should().Be(null);
    }

    [Fact]
    public void result_fails()
    {
        SuccessOr<CustomError> result = GetFailure();

        result.IsSuccess.Should().Be(false);
        result.IsFailure.Should().Be(true);
        result.Error.Should().BeOfType<CustomError>();
    }

    [Fact]
    public void result_fails_without_custom_error_when_error_message_is_provided()
    {
        SuccessOr<CustomError> result = GetFailureWhenReturningMessage("error");

        result.IsSuccess.Should().Be(false);
        result.IsFailure.Should().Be(true);
        result.Error.Should().Be(null);
    }

    [Fact]
    public void result_fails_when_only_the_error_returned()
    {
        SuccessOr<CustomError> result = GetFailureWithoutCallingResultsFail();

        result.IsSuccess.Should().Be(false);
        result.IsFailure.Should().Be(true);
        result.Error.Should().BeOfType<CustomError>();
    }

    private SuccessOr<CustomError> GetSuccess()
    {
        return Result.Ok();
    }

    private SuccessOr<CustomError> GetFailure()
    {
        return Result.Fail(new CustomError());
    }

    private SuccessOr<CustomError> GetFailureWhenReturningMessage(string errorMessage)
    {
        return Result.Fail(errorMessage);
    }

    private SuccessOr<CustomError> GetFailureWithoutCallingResultsFail()
    {
        return new CustomError();
    }
}
