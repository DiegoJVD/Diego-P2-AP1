using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Diego_P2_AP1.Entidades;

namespace Diego_P2_AP1.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Proyectos> Proyectos { get; set; }

        public DbSet<ProyectosDetalle> ProyectosDetalle { get; set; }

        public DbSet<TiposTarea> TiposTarea { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(@"Data Source = Data/Parcial.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TiposTarea>().HasData(new List<TiposTarea>()
                { 
                    new TiposTarea(1, "Analisis"),
                    new TiposTarea(2, "Programacion"),
                    new TiposTarea(3, "Redes"),
                    
                }
            );
        }
        
    }
}