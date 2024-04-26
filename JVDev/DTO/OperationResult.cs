namespace JVDev.DTO
{
    public abstract class Result
    {
        public bool Success { get; set; }
        public string Message { get; set; } = "";
        public string Details { get; set; } = "";
        public List<string> Errors { get; set; } = new List<string>();
    }

    public class OperationResult<T> : Result
    {
        public T Data { get; private set; }

        public static OperationResult<T> CreateOperationResult(T data, string msg = "")
        {
            return new OperationResult<T>()
            {
                Data = data,
                Message = msg,
                Success = true
            };
        }

        public static OperationResult<T> CreateErrorResult(string msg, List<string> errors = null)
        {
            return new OperationResult<T>()
            {
                Data = default,
                Message = msg,
                Success = false,
                Errors = errors
            };
        }

        public static OperationResult<T> CreateExceptionResult(Exception ex, string details = null)
        {
            var _errors = new List<string>();
            if (ex.InnerException != null)
                _errors.Add(ex.InnerException.Message);

            return new OperationResult<T>()
            {
                Data = default,
                Message = ex.Message,
                Success = false,
                Details = details,
                Errors = _errors
            };
        }

        public static OperationResult<T> CreateValidationErrorResult(List<string> errors)
        {
            return new OperationResult<T>()
            {
                Data = default,
                Message = "Validation errors",
                Success = false,
                Errors = errors
            };
        }

    }
}
