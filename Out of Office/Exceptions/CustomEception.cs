using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException(string? message) : base(message)
        {

        }
    }
}
