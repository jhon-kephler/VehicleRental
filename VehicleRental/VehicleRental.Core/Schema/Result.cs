using System.Text.Json.Serialization;

namespace VehicleRental.Core.Schema
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; } = true;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int StatusCode => IsSuccess ? 200 : 500;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ErrorMessage { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public T? Data { get; set; }

        public void ValidateResult(string errorMessage)
        {
            IsSuccess = false;
            ErrorMessage = errorMessage;
        }

        public void SetSuccess(T data)
        {
            IsSuccess = true;
            Data = data;
        }   
    }

    public class Result : Result<object>
    {
        public Result() { }
    }
}
