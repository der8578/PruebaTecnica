using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Data.Interfaces.Producto;
using Data.Models.Producto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApp.Controllers.Producto
{
    [Route("[controller]")]
    [Authorize(Roles = "Administrador")]
    public class ProductoController : Controller
    {
        private readonly ILogger<ProductoController> _logger;
        private readonly IProductoServices productoServices;

        public ProductoController(ILogger<ProductoController> logger
            , IProductoServices productoServices)
        {
            _logger = logger;
            this.productoServices = productoServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Buscar")]
        public async Task<ActionResult> Buscar(string searchTerm)
        {
            try
            {
                var result = await productoServices.ObtenerProductos(searchTerm);
                return PartialView("PartialComponents/_Result", result);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpGet("Create")]
        public ActionResult Create()
        {
            try
            {
                ProductoModel model = new();
                return View(model);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost("Grabar")]
        public async Task<IActionResult> Grabar(ProductoModel model)
        {
            return await ProcesarDatos(model, productoServices.Grabar);
        }

        [HttpGet("Edit")]
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                ProductoModel model = await productoServices.ObtenerProductoPorId(id);
                return View(model);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost("Actualizar")]
        public async Task<IActionResult> Actualizar(ProductoModel model)
        {
            return await ProcesarDatos(model, productoServices.Actualizar);
        }

        private async Task<IActionResult> ProcesarDatos(ProductoModel model, Func<ProductoModel, Task> accion)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                await accion(model);
                return Json(new { success = true });
            }
            catch (System.Exception)
            {
                return Json(new { success = false });
            }
        }
    }
}