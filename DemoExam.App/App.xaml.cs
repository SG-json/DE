using DemoExam.App.Context;
using DemoExam.App.Services.Implementations;
using DemoExam.App.Services.Interfaces;
using DemoExam.App.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Windows;

namespace DemoExam.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;
        private IConfiguration _configuration;

        public App()
        {
            var _configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            _configuration = _configurationBuilder.Build();

            var services = new ServiceCollection();

            services.AddSingleton<IConfiguration>(_configuration);

            // Views
            services.AddTransient<AuthView>();

            // ViewModels
            services.AddTransient<AuthViewModel>();

            // Services
            services.AddScoped<IViewService, ViewService>();

            // DbContext
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(_configuration.GetConnectionString("mssql")));
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var viewsManager = _serviceProvider.GetRequiredService<IViewService>();
            var dataContext = _serviceProvider.GetRequiredService<AuthViewModel>();

            viewsManager.Open<AuthView>(dataContext);
        }
    }
}
