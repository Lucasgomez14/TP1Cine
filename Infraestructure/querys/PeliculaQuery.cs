using Application.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence.Config;

namespace Infraestructure.Querys
{
    public class PeliculaQuery : IPeliculaQuery
    {
        private readonly DBContext _context;

        public PeliculaQuery(DBContext DBContext)
        {
            this._context = DBContext;
        }
        public async Task<Pelicula> GetPeliculaById(int peliculaId)
        {
            return _context.Peliculas.SingleOrDefault(p => p.PeliculaId == peliculaId);
        }
    }
}
