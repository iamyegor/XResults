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

    public static Result Create(bool isSuccess, string? errorMessage = null)
    {
        if (isSuccess && errorMessage != null)
        {
            throw new Exception("Can't create a successful result with error message");
        }

        return new Result(isSuccess, errorMessage);
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
