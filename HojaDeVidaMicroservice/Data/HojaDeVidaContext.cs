using Microsoft.EntityFrameworkCore;
using HojaDeVidaMicroservice.Models;

namespace HojaDeVidaMicroservice.Data
{
    public class HojaDeVidaContext : DbContext
    {
        public HojaDeVidaContext(DbContextOptions<HojaDeVidaContext> options) : base(options) { }

        public DbSet<Actividad> Actividades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actividad>().HasIndex(a => a.EstudianteId); // Índice para búsquedas
        }
    }
}