using HojaDeVidaMicroservice.Models;
using HojaDeVidaMicroservice.Repositories;

namespace HojaDeVidaMicroservice.Services
{
    public class ActividadService : IActividadService
    {
        private readonly IActividadRepository _repository;

        // Inyectamos el repositorio por constructor (Dependency Injection)
        public ActividadService(IActividadRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Actividad>> GetByEstudianteIdAsync(string estudianteId)
        {
            // Validación adicional (ej: ID no vacío)
            if (string.IsNullOrEmpty(estudianteId))
                throw new ArgumentException("El ID del estudiante no puede estar vacío.");

            return await _repository.GetByEstudianteIdAsync(estudianteId);
        }

        public async Task<Actividad> CreateAsync(Actividad actividad)
        {
            // Validaciones de negocio
            if (actividad.Fecha > DateTime.Now)
                throw new ArgumentException("La fecha no puede ser futura.");

            if (string.IsNullOrEmpty(actividad.Titulo))
                throw new ArgumentException("El título es obligatorio.");

            await _repository.AddAsync(actividad);
            return actividad;
        }
    }
}
