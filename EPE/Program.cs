using EPE.Application.Core.Abstractions;
using EPE.Application.DependencyInjectionExtensions;
using EPE.Infrastructure.AutoMapper;
using EPE.Infrastructure.Persistence.DbContexts;
using EPE.Infrastructure.Persistence.UnitofWork;
using EPE.Infrastructure.SqlServer.DbContexts;
using EPE.Presention.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EPE
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
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.SetHighDpiMode(HighDpiMode.SystemAware);

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            using (var scope = ServiceProvider.CreateScope())
            {
                using (var dbcontext = scope.ServiceProvider.GetService<SqlServerCommandDbContext>())
                    dbcontext.Database.EnsureCreated();
            }

            System.Windows.Forms.Application.Run(ServiceProvider.GetRequiredService<MainForm>());
        }

        public static IServiceProvider ServiceProvider { get; private set; }
        static IHostBuilder CreateHostBuilder()
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {

                    services.AddDbContext<CommandDbContext, SqlServerCommandDbContext>(options =>
                    options.UseLazyLoadingProxies()
                    .UseSqlServer(configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped);

                    //services.AddScoped<IExceptionHandler, ExceptionHandler>();


                    services.AddAutoMapper(typeof(EmployeeManagementProfile));
                    services.AddAutoMapper(typeof(PerformanceEvaluateProfile));


                    services.AddEmployeeManagementModules();
                    services.AddMasterDataModules();
                    services.AddPerformanceEvaluateModules();

                    services.AddScoped<IUnitOfWork, MainUnitOfWork>();


                    services.AddScoped<MainForm>();



                });
        }
    }
}