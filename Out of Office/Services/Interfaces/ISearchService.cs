using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Services.Interfaces
{
    public interface ISearchService<T, F>
        where T : class
        where F : class
    {
        public IQueryable<T> Search(IQueryable<T> collection, F filter, string searchString);
    }
}
