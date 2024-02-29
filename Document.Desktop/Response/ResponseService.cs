namespace Document.Desktop.Response
{
    public class ResponseService
    {
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;

        public static ResponseService Ok() => new ResponseService();
        public static ResponseService Error(string errorMessage) => new ResponseService()
        {
            ErrorMessage = errorMessage,
            IsError = true
        };
    }

    public class ResponseService<T>
    {
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
        public T Value { get; set; }

        public static ResponseService<T> Ok(T value) => new ResponseService<T>() { Value = value };
        public static ResponseService<T> Error(string errorMessage) => new ResponseService<T>()
        {
            ErrorMessage = string.Empty,
            IsError = true,
        };
    }
}