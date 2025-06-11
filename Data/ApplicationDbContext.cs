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
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<GrupoModel> Grupos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<ProductoModel> Productos { get; set; }
        public DbSet<FormulaModel> Formulas { get; set; }
        public DbSet<FormulaMaterialesModel> FormulaMateriales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Clave compuesta en FormulaMateriales
            modelBuilder.Entity<FormulaMaterialesModel>()
                .HasKey(fm => new { fm.IdFormula, fm.IdProducto });

            // Relación: FormulaMateriales -> Formula
            modelBuilder.Entity<FormulaMaterialesModel>()
                .HasOne(fm => fm.Formula)
                .WithMany(f => f.Materiales)
                .HasForeignKey(fm => fm.IdFormula);

            // Relación: FormulaMateriales -> Producto
            modelBuilder.Entity<FormulaMaterialesModel>()
                .HasOne(fm => fm.Producto)
                .WithMany()
                .HasForeignKey(fm => fm.IdProducto);

            // Relación: Usuario -> Grupo
            modelBuilder.Entity<UsuarioModel>()
                .HasOne(u => u.Grupo)
                .WithMany(g => g.Usuarios)
                .HasForeignKey(u => u.IdGrupo);

            // Relación: Formula -> Producto
            modelBuilder.Entity<FormulaModel>()
                .HasOne(f => f.Producto)
                .WithMany()
                .HasForeignKey(f => f.IdProducto);
        }
    }
}
