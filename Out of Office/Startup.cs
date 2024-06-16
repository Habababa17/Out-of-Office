using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Out_of_Office.Data;
using Out_of_Office.Data.IRepositories;
using Out_of_Office.Data.Repositories;
using Out_of_Office.Services;
using Out_of_Office.Services.Interfaces;

using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Out_of_Office
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SimpleOfficeDB")));

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();      
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            services.AddScoped<IApprovalRequestRepository, ApprovalRequestRepository>();
            services.AddScoped<IEmployeeProjectAssignmentRepository, EmployeeProjectAssignmentRepository>();

            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ILeaveRequestService, LeaveRequestService>();
            services.AddScoped<IApprovalRequestService, ApprovalRequestService>();
            services.AddScoped<IEmployeeProjectAssignmentService, EmployeeProjectAssignmentService>();
        }
    }
}
