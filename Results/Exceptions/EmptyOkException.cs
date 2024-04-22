namespace Results.Exceptions;

public class EmptyOkException : ResultsLibraryException
{
    public EmptyOkException()
        : base("You didn't pass anything to Result.Ok() while trying to return Result<T>") { }
}
