namespace Demo_Api
{
    public sealed class Result<T>
    {
        public T Value { get; }
        public Error Error { get; }
        public bool IsSuccess { get; private set; }
        private Result(T value)
        {
            Value = value;
            IsSuccess = true;
        }
        private Result(Error error)
        {
            Error = error;
            IsSuccess = false;
        }

        public static Result<T> Success(T value) => new Result<T>(value); 
        public static Result<T> Failure(Error error) => new Result<T>(error); 
    }
    public record Error(ErrorType Type, string Description)
    {
        public static Error NoLineItems => new Error(ErrorType.Validation, "Line Items are Empty");
        public static Error NotEnoughStock => new Error(ErrorType.Validation, "Not Enough Stock for Order");
        public static Error PaymentFailed => new Error(ErrorType.Validation, "Failed to Process Payment");
    }
    public enum ErrorType
    {
        Failure = 0,
        Validation = 1,
    }
}
