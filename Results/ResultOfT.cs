namespace Results;

public class Result<T> : ResultBase
{
    public T Value => IsSuccess ? _value! : throw new ResultException();
    private readonly T? _value;

    private Result(bool isSuccess, T? value = default, string? errorMessage = null)
        : base(isSuccess, errorMessage)
    {
        _value = value;
    }

    public static Result<T> Ok(T value) => new Result<T>(true, value);

    private static Result<T> Fail(string? errorMessage) =>
        new Result<T>(false, default, errorMessage);

    public static implicit operator Result<T>(Result result)
    {
        if (result.IsSuccess)
        {
            throw new Exception("Can't cast Result to Result<T>");
        }

        return Fail(result.ErrorMessage);
    }
    
    public static implicit operator Result<T>(T value)
    {
        return new Result<T>(true, value);
    }
}