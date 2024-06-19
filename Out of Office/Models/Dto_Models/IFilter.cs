using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Models.Dto_Models
{
    public interface IFilter<T>
    {
        public abstract List<T>? Filtrate(List<T>? dtos);
    }
}
