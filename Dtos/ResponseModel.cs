using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ComplaintSystem.Dtos
{
    public class ResponseModel<T>
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public T Data { get; set; }

        public ResponseModel(bool success, T data, string errorMessage = null!)
        {
            Success = success;
            ErrorMessage = errorMessage;
            Data = data;
        }
    }
}