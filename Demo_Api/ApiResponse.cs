namespace Demo_Api
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ApiResponse(bool success, int statusCode, string message, T data)
        {
            Success = success;
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }

        // Static methods to create success and failure responses
        public static ApiResponse<T> CreateSuccess(T data, string message = "Operation succeeded")
        {
            return new ApiResponse<T>(true, StatusCodes.Status200OK, message, data);
        }

        public static ApiResponse<T> CreateFailure(string message, int statusCode = StatusCodes.Status400BadRequest)
        {
            return new ApiResponse<T>(false, statusCode, message, default);
        }
    }

}
