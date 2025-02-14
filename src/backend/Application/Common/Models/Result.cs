namespace TodoApp.Application.Common.Models;

public class Result<T>
{
    private Result(bool succeeded, IEnumerable<string> errors, T? value = default)
    {
        Succeeded = succeeded;
        Value = value;
        Error = errors.FirstOrDefault();
    }

    public bool Succeeded { get; init; }

    public string? Error { get; init; }

    public T? Value { get; init; }

    public static Result<T> Success(T? entity = default)
    {
        return new Result<T>(true, [], entity);
    }

    public static Result<T> Failure(IEnumerable<string> errors)
    {
        return new Result<T>(false, errors);
    }
}

public class Error
{
    public string[] Message { get; set; } = [];
}
