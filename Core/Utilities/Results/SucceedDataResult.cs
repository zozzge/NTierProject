using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SucceedDataResult<T>:DataResult<T>
    {
        public SucceedDataResult(T data,string message):base(data,true,message)
        {
                
        }

        public SucceedDataResult(T data) : base(data, true)
        {

        }

        public SucceedDataResult(string message) : base(default,true,message)
        {

        }

        public SucceedDataResult() : base(default, true)
        {

        }
    }
}
