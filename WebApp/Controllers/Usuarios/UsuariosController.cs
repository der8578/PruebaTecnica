using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Models.Usuarios;

namespace WebApp.Controllers.Usuarios
{
    [Route("[controller]")]
    public class UsuariosController : Controller
    {
        private readonly ILogger<UsuariosController> _logger;

        public UsuariosController(ILogger<UsuariosController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("Crear")]
        public ActionResult Crear(UsuarioDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                return View(model);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

    }
}