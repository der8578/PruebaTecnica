using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApp.Controllers.Cuenta
{
    [Route("[controller]")]
    public class CuentaController : Controller
    {
        private readonly ILogger<CuentaController> _logger;

        public CuentaController(ILogger<CuentaController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Login")]
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet("Denegado")]
        public ActionResult Denegado()
        {
            return View();
        }

    }
}