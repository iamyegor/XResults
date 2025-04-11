namespace XResults
{
    public class SuccessOr<TError>
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public TError Error { get; }

        private SuccessOr(bool isSuccess, TError? error)
        {
            IsSuccess = isSuccess;
            Error = error!;
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
}
