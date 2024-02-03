using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pattern_Software_Design_Qualification.Facades
{
    public class Response<T>
    {
        public Boolean IsSuccess { get; set; }
        public String Message { get; set; }
        public T Payload { get; set; }
    }
}