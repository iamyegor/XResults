using FluentAssertions;
using XResults;

namespace Tests;

public class ResultTests
{
    [Fact]
    public void result_succeeds()
    {
        Result result = Result.Ok();

        result.IsSuccess.Should().Be(true);
        result.IsFailure.Should().Be(false);
        result.ErrorMessage.Should().Be(null);
    }

    [Fact]
    public void result_fails()
    {
        Result result = Result.Fail("error");

        result.IsSuccess.Should().Be(false);
        result.IsFailure.Should().Be(true);
        result.ErrorMessage.Should().Be("error");
    }

    [Fact]
    public void automatically_convert_successful_result_of_t_to_result()
    {
        Result result = Result.Ok(123);

        result.IsSuccess.Should().Be(true);
        result.IsFailure.Should().Be(false);
        result.ErrorMessage.Should().Be(null);
    }

    [Fact]
    public void automatically_convert_failed_result_of_t_to_result()
    {
        Result<int> resultOfInt = Result.Fail("error");
        Result result = resultOfInt;

        result.IsSuccess.Should().Be(false);
        result.IsFailure.Should().Be(true);
        result.ErrorMessage.Should().Be("error");
    }
}
