using Assignment10_3.Data;
using Assignment10_3.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
namespace Assignment10_3 {
    public partial class App : Application {

        private ServiceProvider provider;

        public App() {

            ServiceCollection services = new ServiceCollection();
            services.AddDbContext<CarContext>(options => {
                options.UseSqlite("Data Source=cars.db");
            });
            services.AddSingleton<ICRUD, CRUD>();
            services.AddSingleton<MainWindow>();
            provider = services.BuildServiceProvider();

        }

        private void OnStartUp(object sender, StartupEventArgs e) {
            MainWindow mainWindow = provider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }
}
