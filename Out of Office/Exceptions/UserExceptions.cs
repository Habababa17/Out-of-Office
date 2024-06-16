using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Exceptions
{
    public class UserException : CustomException
    {
        public UserException(string? message) : base(message)
        {

        }
    }
    public class UnauthorezedException : UserException
    {
        public UnauthorezedException(string? message) : base("Unauthorized Access")
        {
        }
    }
    public class UserNotFoundException : UserException
    {
        public UserNotFoundException() : base("User not found")
        {

        }
    }
}
