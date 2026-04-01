namespace TetPee.Service.Models;

public class ApiResponse
{
    public bool Success { get; set; }
    public string Message { get; set; } = null!;
    public object? Data { get; set; }
    public object? Error { get; set; }
    public string? TraceId { get; set; }
    public DateTime TimestampUtc { get; set; }
}

public static class ApiResponseFactory
{
    public static ApiResponse SuccessResponse(object? data, string message = "Request processed successfully",
        string? traceId = null)
    {
        return new ApiResponse
        {
            Success = true,
            Message = message,
            Data = data,
            TraceId = traceId,
            TimestampUtc = DateTime.UtcNow
        };
    }

    public static ApiResponse ErrorResponse(string message, object? errors = null, string? traceId = null)
    {
        return new ApiResponse
        {
            Success = false,
            Message = message,
            Error = errors,
            TraceId = traceId,
            TimestampUtc = DateTime.UtcNow
        };
    }


}