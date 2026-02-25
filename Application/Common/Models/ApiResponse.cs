namespace Application.Common.Models;
public class ApiResponse<T>
{
    public string Code { get; set; } = "200";
    public string Message { get; set; } = "Success";
    public object? Errors { get; set; }
    public string? TraceId { get; set; }
    public T? Data { get; set; }

    public static ApiResponse<T> Success(T data, string message = "Success")
        => new()
        {
            Code = "200",
            Message = message,
            Data = data
        };

    public static ApiResponse<T> Fail(string code, string message, object? errors = null)
        => new()
        {
            Code = code,
            Message = message,
            Errors = errors
        };
}