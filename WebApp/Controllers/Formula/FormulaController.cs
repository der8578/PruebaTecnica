using Data.Interfaces.Formula;
using Data.Interfaces.Producto;
using Data.Models.Formula;
using Data.Models.FormulaMateriales;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Models.Formula;
using WebApp.Validators.Formula;

namespace WebApp.Controllers.Formula
{
    [Route("[controller]")]
    [Authorize(Roles = "Administrador")]
    public class FormulaController : Controller
    {
        private readonly ILogger<FormulaController> _logger;
        private readonly IProductoServices productoServices;
        private readonly IFormulaServices formulaServices;

        public FormulaController(ILogger<FormulaController> logger
        , IProductoServices productoServices
        , IFormulaServices formulaServices)
        {
            _logger = logger;
            this.productoServices = productoServices;
            this.formulaServices = formulaServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            try
            {
                await ObtenerGrupos();
                FormulaDTO model = new();
                return View(model);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task ObtenerGrupos()
        {
            var Grupos = await productoServices.ObtenerProductos();
            ViewBag.ListProductos = Grupos.Select(c => new SelectListItem
            {
                Value = c.IdProducto.ToString(),
                Text = c.Nombre,
            }).ToList();
        }

        [HttpPost("Grabar")]
        public IActionResult Grabar(FormulaDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errores = ModelState
                        .Where(x => x.Value.Errors.Count > 0)
                        .Select(x => new
                        {
                            Campo = x.Key,
                            Mensajes = x.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                        });

                    return BadRequest(new { errores });
                }

                decimal Cantidad = model.Materiales.Sum(x => x.Cantidad);
                model.Cantidad = Cantidad;

                FormulaModel formula = new()
                {
                    IdFormula = model.IdFormula,
                    Nombre = model.Nombre,
                    Cantidad = model.Cantidad,
                    Materiales = model.Materiales
                    .Select(m => new FormulaMaterialesModel
                    {
                        IdFormula = m.IdFormula,
                        IdProducto = m.IdProducto,
                        Nombre = m.Nombre,
                        Cantidad = m.Cantidad
                    }).ToList()

                };
                formulaServices.Grabar(formula);

                return Json(new { success = true });
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost("ValidItem")]
        public ActionResult ValidarItem([FromBody] FormulaMaterialesModel model)
        {
            model ??= new();
            var validator = new FormulaMaterialesModelValidator();
            var result = validator.Validate(model);

            if (!result.IsValid)
            {
                return Json(new { success = false, result.Errors });
            }
            return Json(new { success = true });
        }
    }
}