
using Data.Interfaces.Grupo;
using Data.Interfaces.Usuario;
using Data.Repositories.Grupo;
using Data.Repositories.Usuario;
using Data.Services.Grupo;
using Data.Services.Usuario;

namespace WebApp
{
    public static class DependencyInjectionContainer
    {
        public static void Container(IServiceCollection services)
        {
            services.AddScoped<IGrupoRepository, GrupoRepository>()
            .AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<IGrupoServices, GrupoServices>()
            .AddScoped<IUsuarioServices, UsuarioServices>();
        }
    }
}