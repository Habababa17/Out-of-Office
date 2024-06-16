using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Helpers
{
    public static class PageHelper
    {
        /// <summary>
        /// Retrieves a specified page from an IQueryable source. Pages numeration starts at 1.
        /// </summary>
        public static IQueryable<T> GetPage<T>(IQueryable<T> source, int pageNumber, int pageSize)
        {
            int skip = (pageNumber - 1) * pageSize;
            IQueryable<T> page = source.Skip(skip).Take(pageSize);
            return page;
        }
    }
}
