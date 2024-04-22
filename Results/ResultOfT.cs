using Results.Exceptions;

namespace Results;

public class Result<T>
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public string? ErrorMessage { get; }
    public T Value => IsSuccess ? _value! : throw new OperationFailedException();
    private readonly T? _value;

    private Result(bool isSuccess, T? value = default, string? errorMessage = null)
    {
        IsSuccess = isSuccess;
        _value = value;
        ErrorMessage = errorMessage;
    }

    internal static Result<T> Ok(T value)
    {
        return new Result<T>(true, value);
    }

    private static Result<T> Fail(string? errorMessage)
    {
        return new Result<T>(false, default, errorMessage);
    }

    public static implicit operator Result<T>(Result result)
    {
        if (result.IsSuccess)
        {
            throw new EmptyOkException();
        }

        return Fail(result.ErrorMessage);
    }

    public static implicit operator Result<T>(T value)
    {
        return new Result<T>(true, value);
    }
}
