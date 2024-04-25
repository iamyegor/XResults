namespace XResults;

public class Result
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public string? ErrorMessage { get; }

    internal Result(bool isSuccess, string? errorMessage = null)
    {
        IsSuccess = isSuccess;
        ErrorMessage = errorMessage;
    }

    public static Result Ok()
    {
        return new Result(true);
    }

    public static Result<T> Ok<T>(T value)
    {
        return Result<T>.Ok(value);
    }

    public static Result Fail(string? errorMessage)
    {
        return new Result(false, errorMessage);
    }

    public static TError Fail<TError>(TError failure)
    {
        return failure;
    }
}
