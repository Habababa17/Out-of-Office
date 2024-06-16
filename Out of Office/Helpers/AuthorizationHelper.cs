using Out_of_Office.DB_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Out_of_Office.Models.Enums;
using Out_of_Office.Models.Dto_Models;
using Out_of_Office.Helpers.Converters;

namespace Out_of_Office.Helpers
{
    public static class AuthorizationHelper
    {
        public static EmployeeDto loggedInUser;
        public static PositionEnum position;

        public static void SetLoggedInUser(EmployeeModel user)
        {
            loggedInUser = EmployeeConverter.ToDto(user);
            position = loggedInUser.Position;
        }
        public static void SetLoggedInUser(EmployeeDto user)
        {
            loggedInUser = user;
            position = loggedInUser.Position;
        }

        public static bool IsAuthorized(PositionEnum[] requiredPosition)
        {
            if (loggedInUser != null && requiredPosition.Contains(loggedInUser.Position))
            {
                return true;
            }
            return false;
        }
    }
}
