using Application.Interfaces;
using Domain.Entities;

namespace Application.usecase
{
    public class PeliculaService : IPeliculaService
    {
        private readonly IPeliculaQuery _query;

        public PeliculaService(IPeliculaQuery peliculaQuery)
        {
            _query = peliculaQuery;
        }
        public async Task<bool> ExistPelicula(int peliculaId)
        {
            Pelicula unaPelicula = await _query.GetPeliculaById(peliculaId);
            if (unaPelicula == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
