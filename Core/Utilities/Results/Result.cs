﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResults
    {
        

        public Result(bool isSuccess,string message):this(isSuccess)
        {
            IsSuccess = isSuccess;
            Message = message;  
        }

        public Result(bool isSuccess)
        {
            IsSuccess=isSuccess;
        }



        public bool IsSuccess {  get;  }

        public string Message {  get; } 
    }
}
