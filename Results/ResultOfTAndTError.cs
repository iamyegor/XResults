using Results.Exceptions;

namespace Results;

public class Result<T, TError>
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public T? Value => IsSuccess ? _value : throw new OperationFailedException();
    private readonly T? _value;
    public TError? Error { get; }

    private Result(bool isSuccess, T? value = default, TError? error = default)
    {
        IsSuccess = isSuccess;
        _value = value;
        Error = error;
    }

    public static implicit operator Result<T, TError>(Result<T> result)
    {
        return new Result<T, TError>(true, result.Value);
    }

    public static implicit operator Result<T, TError>(TError error)
    {
        return new Result<T, TError>(false, default, error);
    }

    public static implicit operator Result<T, TError>(T value)
    {
        return new Result<T, TError>(true, value);
    }
}
