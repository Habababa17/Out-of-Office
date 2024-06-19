using Out_of_Office.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Models.Dto_Models
{
    public class EmployeeFiltersDto : Filter<EmployeeDto>
    {
        public SubdivisionEnum? SubdivisionEnum  { get; set; }
        public StatusEnum? StatusEnum { get; set; }
        public PositionEnum? PositionEnum { get; set; }
        public string? FullName { get; set; }


        public EmployeeFiltersDto()
        {
            SubdivisionEnum = null;
            StatusEnum = null;
            PositionEnum = null;
            FullName = null;
        }
        public override List<EmployeeDto>? Filtrate(List<EmployeeDto>? dtos)
        {
            if (dtos == null)
            {
                throw new ArgumentNullException(nameof(dtos));
            }

            var filteredList = dtos.AsQueryable();

            if (SubdivisionEnum.HasValue)
            {
                filteredList = filteredList.Where(e => e.Subdivision == SubdivisionEnum.Value);
            }

            if (StatusEnum.HasValue)
            {
                filteredList = filteredList.Where(e => e.Status == StatusEnum.Value);
            }

            if (PositionEnum.HasValue)
            {
                filteredList = filteredList.Where(e => e.Position == PositionEnum.Value);
            }

            if (!string.IsNullOrEmpty(FullName))
            {
                filteredList = filteredList.Where(e => e.FullName.Contains(FullName, StringComparison.OrdinalIgnoreCase));
            }
            

            return filteredList.ToList();
        }
        public override void ClearFilters()
        {
            SubdivisionEnum = null;
            StatusEnum = null;
            PositionEnum = null;
            FullName = null;
        }
    }
}
