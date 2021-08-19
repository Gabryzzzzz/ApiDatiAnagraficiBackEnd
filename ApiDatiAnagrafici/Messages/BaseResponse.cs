using System;

namespace DatiAnagrafici.Messages
{
    public class BaseResponse
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public void SetException(Exception ex)
        {
            IsSuccess = false;
            ErrorMessage = ex.ToString();
        }
    }
}
