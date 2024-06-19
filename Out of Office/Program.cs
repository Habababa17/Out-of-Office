using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Out_of_Office.Data;
using Out_of_Office.Forms;
using Out_of_Office.Models.DB_Models;
using Out_of_Office.Models.Enums;
using Out_of_Office.Services.Interfaces;

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
            var serviceProvider = BuildApp();
            ApplicationConfiguration.Initialize();

            var pservice = serviceProvider.GetRequiredService<IProjectService>();

            Application.Run(new LoginForm(serviceProvider));
            //Application.Run(new MainForm(serviceProvider));


            //ProjectModel newProject = new ProjectModel
            //{
            //    ID = Guid.NewGuid(), // Assign a new GUID for the ID
            //    ProjectType = (int)ProjectTypeEnum.Internal, // Assign ProjectTypeEnum value
            //    StartDate = DateTime.Parse("2024-07-01"),
            //    EndDate = DateTime.Parse("2025-12-31"),
            //    ProjectManager = new Guid("C46169DC-1D0F-4929-B40C-2D82AE7F4173"), // Assign the GUID of the project manager
            //    Comment = "HA hhuuhuu HI HI",
            //    Status = (int)ProjectStatusEnum.Active // Optionally set, though it defaults to "Active" in the model
            //};

            //pservice.AddProject(newProject);



            //using (var dbContext = new AppDbContext()) // Instantiate your DbContext
            //{
            //    dbContext.Project.Add(newProject); // Add the new project to the DbSet
            //    dbContext.SaveChanges(); // Save changes to the database
            //}






        }
        public static ServiceProvider BuildApp()
        {
            //throw (new Exception(Directory.GetCurrentDirectory()));
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var services = new ServiceCollection();

            // Configure services
            var startup = new Startup(config);
            startup.ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }
    }
}