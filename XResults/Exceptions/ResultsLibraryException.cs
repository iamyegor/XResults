namespace XResults.Exceptions;

public abstract class ResultsLibraryException : Exception
{
    protected ResultsLibraryException(string errorMessage)
        : base(errorMessage) { }
}
