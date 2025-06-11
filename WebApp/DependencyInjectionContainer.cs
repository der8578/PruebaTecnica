
using Data.Interfaces.Grupo;
using Data.Interfaces.Producto;
using Data.Interfaces.Usuario;
using Data.Repositories.Grupo;
using Data.Repositories.Producto;
using Data.Repositories.Usuario;
using Data.Services.Grupo;
using Data.Services.Producto;
using Data.Services.Usuario;

namespace WebApp
{
    public static class DependencyInjectionContainer
    {
        public static void Container(IServiceCollection services)
        {
            services.AddScoped<IGrupoRepository, GrupoRepository>()
            .AddScoped<IUsuarioRepository, UsuarioRepository>()
            .AddScoped<IProductoRepository, ProductoRepository>();

            services.AddScoped<IGrupoServices, GrupoServices>()
            .AddScoped<IUsuarioServices, UsuarioServices>()
            .AddScoped<IProductoServices, ProductoServices>();
        }
    }
}