using Domain.Entities;

namespace Application.Interfaces
{
    public interface IPeliculaQuery
    {
        public Task<Pelicula> GetPeliculaById(int peliculaId);
    }
}
