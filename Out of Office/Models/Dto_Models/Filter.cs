using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Models.Dto_Models
{
    public class Filter<T> : IFilter<T>
    {
        public virtual List<T>? Filtrate(List<T>? dtos)
        {
            throw new NotImplementedException();
        }
        public virtual void ClearFilters()
        {
            throw new NotImplementedException();
        }
    }
}
