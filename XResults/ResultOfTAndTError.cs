using XResults.Exceptions;

namespace XResults;

public class Result<T, TError>
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public T Value => IsSuccess ? _value : throw new OperationFailedException();
    private readonly T _value;
    public TError Error { get; }

    private Result(bool isSuccess, T? value = default, TError? error = default)
    {
        IsSuccess = isSuccess;
        _value = value!;
        Error = error!;
    }

    public static Result<T, TError> Create(
        bool isSuccess,
        T? value = default,
        TError? error = default
    )
    {
        if (isSuccess && error != null)
        {
            throw new Exception("Can't create a successful result with error message");
        }

        bool isDefaultValue = EqualityComparer<T>.Default.Equals(value, default);
        if (!isSuccess && !isDefaultValue)
        {
            throw new Exception("Can't create an unsuccessful result with value");
        }

        return new Result<T, TError>(isSuccess, value, error);
    }

    public static implicit operator Result<T, TError>(Result<T> result)
    {
        if (result.IsSuccess)
        {
            return new Result<T, TError>(result.IsSuccess, result.Value);
        }
        else
        {
            throw new ResultCastException(
                "You can't cast Result<T> to Result<T, TError> when Result<T> is failure"
            );
        }
    }

    public static implicit operator Result<T, TError>(TError error)
    {
        return new Result<T, TError>(false, default, error);
    }

    public static implicit operator Result<T, TError>(T value)
    {
        return new Result<T, TError>(true, value);
    }

    public static implicit operator T(Result<T, TError> result)
    {
        if (result.IsFailure)
        {
            throw new OperationFailedException();
        }

        return result.Value;
    }
}
