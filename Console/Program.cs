// See https://aka.ms/new-console-template for more information


using Results;

Console.WriteLine(GetResult(true).IsSuccess);

SuccessOr<Error> GetResult(bool isSuccess)
{
    if (isSuccess)
    {
        return Result.Ok();
    }
    else
    {
        return Result.Fail(new Error(404, "NotFound"));
    }
}
