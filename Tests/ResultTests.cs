using FluentAssertions;
using Results;

namespace Tests;

public class ResultTests
{
    [Fact]
    public void result_succeeds()
    {
        Result result = GetSuccess();

        result.IsSuccess.Should().Be(true);
        result.ErrorMessage.Should().Be(null);
    }

    [Fact]
    public void result_fails()
    {
        Result result = GetFailure("error");

        result.IsSuccess.Should().Be(false);
        result.ErrorMessage.Should().Be("error");
    }

    private Result GetSuccess()
    {
        return Result.Ok();
    }

    private Result GetFailure(string errorMessage)
    {
        return Result.Fail(errorMessage);
    }
}
