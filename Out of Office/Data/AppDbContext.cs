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
using Microsoft.Extensions.Configuration;

namespace Out_of_Office.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<EmployeeModel> Employee { get; set; }
        public DbSet<LeaveRequestModel> LeaveRequest { get; set; }
        public DbSet<ApprovalRequestModel> ApprovalRequest { get; set; }
        public DbSet<ProjectModel> Project { get; set; }
        public DbSet<EmployeeProjectAssignmentModel> EmployeeProjectAssignment { get; set; }


        public string ConnectionString { get; set; }
        public AppDbContext(string? connectionstring = null)
        {
            if (connectionstring == null)
            {
                //ConnectionString = ConfigurationManager.ConnectionStrings["SimpleOfficeDB"].ConnectionString;

                var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
                ConnectionString = config.GetConnectionString("SimpleOfficeDB");
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeProjectAssignmentModel>()
                .HasKey(e => new { e.EmployeeID, e.ProjectID });

            modelBuilder.Entity<EmployeeProjectAssignmentModel>()
                .HasOne(e => e.Project)
                .WithMany()
                .HasForeignKey(e => e.EmployeeID);

            modelBuilder.Entity<EmployeeProjectAssignmentModel>()
                .HasOne(e => e.Employee)
                .WithMany()
                .HasForeignKey(e => e.ProjectID);


            base.OnModelCreating(modelBuilder);
        }
    }
}
