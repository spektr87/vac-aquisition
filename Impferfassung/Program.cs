namespace Impferfassung
{
    using Impferfassung.Contracts;
    using Impferfassung.Data;
    using Impferfassung.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Initializes the application and loads configurations.
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, builder) =>
                {
                    // Add other configuration files...
                })
                .ConfigureServices((context, services) =>
                {
                    ConfigureServices(context.Configuration, services);
                })
                .ConfigureLogging(logging =>
                {
                    // Add other loggers...
                })
                .Build();

            var services = host.Services;

            // Session
            var session = services.GetRequiredService<ISession>();
            session.OperationDate = DateTime.Today;
            session.DefaultSlotLength = 15; // ToDo: Get from appsettings
            session.DefaultVaccineesPerSlot = 12; // ToDo: Get from appsettings

            // Open startup form
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var main = services.GetRequiredService<Main>();
            Application.Run(main);
        }

        /// <summary>
        /// Gets called by the application main entry point. Used for adding services to the container.
        /// </summary>
        /// <param name="configuration">The application configuration.</param>
        /// <param name="services">Dependency injection service container.</param>
        private static void ConfigureServices(
            IConfiguration configuration,
            IServiceCollection services)
        {
            // Database context
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services
                .AddDbContextFactory<FkVaccinationContext>(options =>
                    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            // Application core
            services
                .AddSingleton<ISession, Session>()
                .AddSingleton<Main>()
                .AddTransient<EditVaccinationSlot>();
        }
    }
}