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
            throw new ResultCastException();
        }
        else
        {
            return Fail(result.ErrorMessage);
        }
    }

    public static implicit operator Result(Result<T> result)
    {
        return new Result(result.IsSuccess, result.ErrorMessage);
    }

    public static implicit operator Result<T>(T value)
    {
        return new Result<T>(true, value);
    }

    public static implicit operator T(Result<T> result)
    {
        if (result.IsFailure)
        {
            throw new OperationFailedException();
        }

        return result.Value;
    }
}
