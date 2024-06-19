using Out_of_Office.Models.Dto_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Helpers
{
    public static class BalanceHelper
    {
        /// <summary>
        /// chceck wheather time difference in given dates is no greater than logged in user's blance,
        /// in other case throws an exception
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="EndDate"></param>
        public static void CheckBalance(DateTime startDate, DateTime EndDate)
        {
            //get amount of days leave will take
            TimeSpan difference = EndDate.Subtract(startDate);
            int daysDifference = difference.Days;
            if (daysDifference > AuthorizationHelper.loggedInUser.OutOfOfficeBalance)
            {
                throw (new Exception("Not enough OutofOffice Balance for specified leave request"));
            }
        }
    }
}
