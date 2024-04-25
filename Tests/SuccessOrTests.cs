using FluentAssertions;
using Tests.Fixtures;
using XResults;

namespace Tests;

public class SuccessOrTests
{
    [Fact]
    public void result_succeeds()
    {
        SuccessOr<CustomError> result = Result.Ok();

        result.IsSuccess.Should().Be(true);
        result.IsFailure.Should().Be(false);
        result.Error.Should().Be(null);
    }

    [Fact]
    public void result_fails()
    {
        SuccessOr<CustomError> result = Result.Fail(new CustomError());

        result.IsSuccess.Should().Be(false);
        result.IsFailure.Should().Be(true);
        result.Error.Should().BeOfType<CustomError>();
    }

    [Fact]
    public void result_fails_without_custom_error_when_error_message_is_provided()
    {
        SuccessOr<CustomError> result = Result.Fail("error");

        result.IsSuccess.Should().Be(false);
        result.IsFailure.Should().Be(true);
        result.Error.Should().Be(null);
    }

    [Fact]
    public void result_fails_when_only_the_error_returned()
    {
        SuccessOr<CustomError> result = new CustomError();

        result.IsSuccess.Should().Be(false);
        result.IsFailure.Should().Be(true);
        result.Error.Should().BeOfType<CustomError>();
    }
}
