using HojaDeVidaMicroservice.Models;

namespace HojaDeVidaMicroservice.Repositories
{
    public interface IActividadRepository
    {
        Task<List<Actividad>> GetByEstudianteIdAsync(string estudianteId);
        Task AddAsync(Actividad actividad);
    }
}
