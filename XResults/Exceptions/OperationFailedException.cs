namespace XResults.Exceptions
{
    public class OperationFailedException : ResultsLibraryException
    {
        public OperationFailedException()
            : base("Can't get a value of the failed operation") { }
    }
}
