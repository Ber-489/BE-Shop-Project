namespace Application.Common.Models;

public class PaginatedResponse<T>
{
    public string Code { get; set; } = "SUCCESS";
    public string Message { get; set; } = "Success";
    public string? Errors { get; set; }
    public string? TraceId { get; set; }

    public IEnumerable<T> Data { get; set; } = new List<T>();

    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public int Total { get; set; }
}