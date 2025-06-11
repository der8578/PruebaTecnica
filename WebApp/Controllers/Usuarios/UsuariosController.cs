
using Data.Interfaces.Grupo;
using Data.Interfaces.Usuario;
using Data.Models.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Models.Usuarios;

namespace WebApp.Controllers.Usuarios
{
    [Route("[controller]")]
    public class UsuariosController : Controller
    {
        private readonly ILogger<UsuariosController> _logger;
        private readonly IGrupoServices grupoServices;
        private readonly IUsuarioServices usuarioServices;

        public UsuariosController(ILogger<UsuariosController> logger
            , IGrupoServices grupoServices
            , IUsuarioServices usuarioServices)
        {
            this.grupoServices = grupoServices;
            this.usuarioServices = usuarioServices;
            _logger = logger;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Register")]
        public async Task<IActionResult> Register()
        {
            await ObtenerGrupos();
            return View();
        }

        public async Task ObtenerGrupos()
        {
            var Grupos = await grupoServices.ObtenerGrupos();
            ViewBag.ListGrupos = Grupos.Select(c => new SelectListItem
            {
                Value = c.IdGrupo.ToString(),
                Text = c.Nombre,
            }).ToList();
        }

        [HttpPost("Crear")]
        public async Task<ActionResult> Crear(UsuarioDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                UsuarioModel Usuario = new()
                {
                    Nombre = model.Usuario,
                    ContraseniaHash = model.Contrasenia,
                    IdGrupo = model.IdGrupo
                };
                await usuarioServices.Grabar(Usuario);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error: " + ex.Message });
            }
        }

    }
}