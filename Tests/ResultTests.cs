using FluentAssertions;
using XResults;

namespace Tests;

public class ResultTests
{
    [Fact]
    public void result_succeeds()
    {
        Result result = GetSuccess();

        result.IsSuccess.Should().Be(true);
        result.IsFailure.Should().Be(false);
        result.ErrorMessage.Should().Be(null);
    }

    [Fact]
    public void result_fails()
    {
        Result result = GetFailure("error");

        result.IsSuccess.Should().Be(false);
        result.IsFailure.Should().Be(true);
        result.ErrorMessage.Should().Be("error");
    }

    [Fact]
    public void automatically_convert_successful_result_of_t_to_result()
    {
        Result result = GetSuccessWithValue(123);

        result.IsSuccess.Should().Be(true);
        result.IsFailure.Should().Be(false);
        result.ErrorMessage.Should().Be(null);
    }

    [Fact]
    public void automatically_convert_failed_result_of_t_to_result()
    {
        Result result = GetFailureWithErrorMessage("error");

        result.IsSuccess.Should().Be(false);
        result.IsFailure.Should().Be(true);
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
    
    private Result<int> GetSuccessWithValue(int value)
    {
        return Result.Ok(value);
    }

    private Result<int> GetFailureWithErrorMessage(string errorMessage)
    {
        return Result.Fail(errorMessage);
    }
}
