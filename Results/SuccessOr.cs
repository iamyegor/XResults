namespace Results;

public class SuccessOr<TError>
{
    public bool IsSuccess { get; }
    public TError? Error =>
        !IsSuccess ? _error : throw new Exception("Can't get error from successfull operation");
    private readonly TError? _error;

    private SuccessOr(bool isSuccess, TError? error)
    {
        IsSuccess = isSuccess;
        _error = error;
    }

    public static implicit operator SuccessOr<TError>(Result result)
    {
        return new SuccessOr<TError>(result.IsSuccess, default);
    }

    public static implicit operator SuccessOr<TError>(TError result)
    {
        return new SuccessOr<TError>(false, result);
    }
}
