namespace ApiFirstProject
{
    public class Result<T> where T : class, new()
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public bool Show { get; set; }
        public T? Data { get; set; }




        public static Result<T> Success(int statusCode, T data)
        {
            return new Result<T>()
            {
                StatusCode = statusCode,
                Show = true,
                Data = data,
                IsSuccess = true,
                Message = "İşlem Başarılı"
            };
        }
        public static Result<T> Success(int statusCode)
        {
            return new Result<T>()
            {
                Data = null,
                StatusCode = 200,
                IsSuccess=true,
                Message = "İşlem Başarılı. Geri Dönüş Data Boş.",
                Show= true
            };
        }
        public static Result<T> Fail(int statusCode, string message)
        {
            return new Result<T>()
            {
                IsSuccess = false,
                Show = true,
                Message = message,
                StatusCode = statusCode,
                Data = null

            };
        }
    }
}
