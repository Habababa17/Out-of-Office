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
    public class EmployeeModel
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [MaxLength(255)]
        public string FullName { get; set; }

        [Required]
        [ForeignKey("Subdivision")]
        public int Subdivision { get; set; }

        [Required]
        [ForeignKey("Position")]
        public int Position { get; set; }

        [Required]
        [ForeignKey("Status")]
        public int Status { get; set; }

        [ForeignKey("PeoplePartner")]
        public Guid? PeoplePartner { get; set; }

        [Required]
        public int OutOfOfficeBalance { get; set; }

        public byte[]? Photo { get; set; }
    }
}
