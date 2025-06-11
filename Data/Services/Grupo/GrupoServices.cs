
using Data.Interfaces.Grupo;
using Data.Models.Grupo;

namespace Data.Services.Grupo
{
    public class GrupoServices : IGrupoServices
    {
        private readonly IGrupoRepository repository;

        public GrupoServices(IGrupoRepository repository)
        {
            this.repository = repository;

        }

        public Task<IEnumerable<GrupoModel>> ObtenerGrupos()
        {
            try
            {
                return repository.GetAllAsync();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}