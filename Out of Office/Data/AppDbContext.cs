using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Out_of_Office.DB_Models;
using Out_of_Office.Models.DB_Models;
using Microsoft.Identity.Client;

namespace Out_of_Office.Data
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<LeaveRequest> LeaveRequest { get; set; }
        public DbSet<ApprovalRequest> ApprovalRequest { get; set; }
        public DbSet<Project> Project { get; set; }


        public string ConnectionString { get; set; }
        public AppDbContext(string? connectionstring = null)
        {
            if (connectionstring == null)
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["SimpleOfficeDB"].ConnectionString;
            }
            else
            {
                ConnectionString = connectionstring;
            }
        }   
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseSqlServer(ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
        
    }
}
