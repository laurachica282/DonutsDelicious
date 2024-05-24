using Datos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Negocio;
using Presentacion;

namespace DonutsDelicious
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            using (var serviceProvider = services.BuildServiceProvider())
            {
                ApplicationConfiguration.Initialize();
                Application.Run(serviceProvider.GetRequiredService<Inicio>());
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            // Registrar el contexto de la base de datos con la cadena de conexión
            services.AddDbContext<DonasContext>(options =>
                options.UseMySql("server=localhost;port=3306;database=happydonuts;user=laurac;password=Camila2011",
                Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.37-mysql")));

            // Registrar el servicio AutomataService
            services.AddScoped<AutomataService>();

            // Registrar los formularios
            services.AddScoped<Inicio>();
            services.AddScoped<TamañoDona>();
            services.AddScoped<TipoDona>();
            services.AddScoped<Relleno>();
            services.AddScoped<Cobertura>();
            services.AddScoped<Topings>();
            services.AddScoped<ResumenPedido>();
        }
    }
}