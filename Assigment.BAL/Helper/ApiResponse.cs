using System;
using System.Collections.Generic;

namespace AssigmentApp.BAL.Helper
{

    public class ApiResponse
    {
        public ApiResponse()
        {
            Status = 200;
            Message = string.Empty;
        }
        public ApiResponse(Exception ex)
        {
            Status = -1;
            Errors = new
            {
                ExeptionMsg = ex.Message,
                InnerExceptionMsg = (ex.InnerException != null) ? ex.InnerException.Message : null
            };
            Message = ex.Message;
        }
        public int Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public object Errors { get; set; }
    }
}
