namespace Results;

public class ResultException : Exception
{
    public ResultException()
        : base("Can't get value of failed operation") { }
}
