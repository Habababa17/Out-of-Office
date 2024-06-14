using Out_of_Office.Data;
using Out_of_Office.Models.DB_Models;
using Out_of_Office.Models.Enums;

namespace Out_of_Office
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            
            //Project newProject = new Project
            //{
            //    ID = Guid.NewGuid(), // Assign a new GUID for the ID
            //    ProjectType = ProjectTypeEnum.Internal, // Assign ProjectTypeEnum value
            //    StartDate = DateTime.Parse("2024-07-01"),
            //    EndDate = DateTime.Parse("2025-12-31"),
            //    ProjectManager = new Guid("C46169DC-1D0F-4929-B40C-2D82AE7F4173"), // Assign the GUID of the project manager
            //    Comment = "awawawawaw",
            //    Status = "Active" // Optionally set, though it defaults to "Active" in the model
            //};
            //using (var dbContext = new AppDbContext()) // Instantiate your DbContext
            //{
            //    dbContext.Project.Add(newProject); // Add the new project to the DbSet
            //    dbContext.SaveChanges(); // Save changes to the database
            //}
            Application.Run(new Form1());
        }
    }
}