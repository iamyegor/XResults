namespace Results;

public class Result : ResultBase
{
    private Result(bool isSuccess, string? errorMessage = null)
        : base(isSuccess, errorMessage) { }

    public static Result Ok()
    {
        return new Result(true);
    }

    public static Result<T> Ok<T>(T value)
    {
        return Result<T>.Ok(value);
    }

    public static Result Fail(string errorMessage)
    {
        return new Result(false, errorMessage);
    }

    public static TError Fail<TError>(TError failure)
    {
        return failure;
    }
}
