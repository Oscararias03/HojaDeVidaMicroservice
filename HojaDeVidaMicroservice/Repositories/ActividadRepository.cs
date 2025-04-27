using HojaDeVidaMicroservice.Data;
using HojaDeVidaMicroservice.Models;
using Microsoft.EntityFrameworkCore;

namespace HojaDeVidaMicroservice.Repositories
{
    public class ActividadRepository : IActividadRepository
    {
        private readonly HojaDeVidaContext _context;

        public ActividadRepository(HojaDeVidaContext context)
        {
            _context = context;
        }

        public async Task<List<Actividad>> GetByEstudianteIdAsync(string estudianteId)
        {
            return await _context.Actividades
                .Where(a => a.EstudianteId == estudianteId)
                .OrderByDescending(a => a.Fecha)
                .ToListAsync();
        }

        public async Task AddAsync(Actividad actividad)
        {
            _context.Actividades.Add(actividad);
            await _context.SaveChangesAsync();
        }
    }
}