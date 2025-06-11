using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Data.Interfaces.Usuario;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Models.Usuarios;

namespace WebApp.Controllers.Cuenta
{
    [Route("[controller]")]
    [AllowAnonymous]
    public class CuentaController : Controller
    {
        private readonly ILogger<CuentaController> _logger;
        private readonly IUsuarioServices usuarioServices;

        public CuentaController(ILogger<CuentaController> logger
            , IUsuarioServices usuarioServices)
        {
            _logger = logger;
            this.usuarioServices = usuarioServices;
        }

        [HttpGet("Login")]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var Usuario = await usuarioServices.Login(model.Usuario, model.Contrasenia);

                if (Usuario != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, Usuario.Nombre),
                        new Claim(ClaimTypes.Role, Usuario.Grupo.Nombre)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = "Usuario o contraseña incorrectos";
                    return View(model);
                }

            }
            catch (System.Exception ex)
            {
                return Json(new { success = false, message = "Error: " + ex.Message });
            }
        }

        [HttpGet("Denegado")]
        public ActionResult Denegado()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Cuenta");
        }
    }
}