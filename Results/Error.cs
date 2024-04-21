namespace Results;

public class Error
{
    public int StatusCode { get; }
    public string ErrorMessage { get; }

    public Error(int statusCode, string errorMessage)
    {
        ErrorMessage = errorMessage;
        StatusCode = statusCode;
    }

    public static Error Create(int statusCode, string errorMessage)
    {
        return new Error(statusCode, errorMessage);
    }
}
