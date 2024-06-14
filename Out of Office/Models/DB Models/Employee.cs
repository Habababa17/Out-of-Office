using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Out_of_Office.Models.Enums;

namespace Out_of_Office.DB_Models
{
    public class Employee
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [MaxLength(255)]
        public string FullName { get; set; }

        [Required]
        [ForeignKey("Subdivision")]
        public SubdivisionEnum Subdivision { get; set; }

        [Required]
        [ForeignKey("Position")]
        public PositionEnum Position { get; set; }

        [Required]
        [MaxLength(10)]
        [RegularExpression("Active|Inactive")]
        public string Status { get; set; }

        public Guid? PeoplePartner { get; set; }

        [Required]
        public int OutOfOfficeBalance { get; set; }

        public byte[]? Photo { get; set; }

        // Navigation properties
        [ForeignKey("PeoplePartner")]
        public Employee PeoplePartnerObject { get; set; }
    }
}
