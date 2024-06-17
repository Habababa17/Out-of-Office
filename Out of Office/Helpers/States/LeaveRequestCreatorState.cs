using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Helpers.States
{
    public static class LeaveRequestCreatorState
    {
        /// <summary>
        /// return how LeaveRequestCreator should behave in context.
        /// it is way to late of an hour to be writing that.
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public static bool[] GetState(int state)
        {
            bool[][] a = new bool[][]
            {
                new bool[] {true },
            };
            return a[state];
        }
    }
}
