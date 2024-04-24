namespace Results.Exceptions;

public class ResultCastException : ResultsLibraryException
{
    public ResultCastException()
        : base("You can't cast Result to Result<T>") { }
}
