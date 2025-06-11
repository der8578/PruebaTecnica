using Data.Models.Formula;
using Data.Models.FormulaMateriales;
using Data.Models.Grupo;
using Data.Models.Producto;
using Data.Models.Usuarios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<GrupoModel> Grupos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<ProductoModel> Productos { get; set; }
        public DbSet<FormulaModel> Formulas { get; set; }
        public DbSet<FormulaMaterialesModel> FormulaMateriales { get; set; }
    }
}
