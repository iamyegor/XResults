namespace Results;

public class ResultBase
{
    public bool IsSuccess { get; }
    public string? ErrorMessage { get; private set; }

    protected ResultBase(bool isSuccess, string? errorMessage = null)
    {
        IsSuccess = isSuccess;
        ErrorMessage = errorMessage;
    }
}