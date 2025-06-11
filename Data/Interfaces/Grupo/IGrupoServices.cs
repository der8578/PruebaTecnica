
using Data.Models.Grupo;

namespace Data.Interfaces.Grupo
{
    public interface IGrupoServices
    {
        Task<IEnumerable<GrupoModel>> ObtenerGrupos();
    }
}