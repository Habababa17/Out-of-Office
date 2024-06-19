using Out_of_Office.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Helpers
{
    internal static class AvalibilityHelper
    {
        /// <summary>
        /// Returns bool table of allowed buttons from selection list part of UI.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static bool[] SelectionListAvalibility(PositionEnum position)
        {
            switch (position)
            {
                case PositionEnum.HRManager:
                    return new bool[] { true, true, true, true };
                case PositionEnum.ProjectManager:
                    return new bool[] { true, true, true, true };
                case PositionEnum.Employee:
                    return new bool[] { true, true, true, true };
                default:
                    throw new ArgumentException("Invalid position enum value.");
            }
        }

    }
}
