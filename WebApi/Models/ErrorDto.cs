namespace WebApi
{
    public class ErrorDto
    {
        public object Content { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
}
