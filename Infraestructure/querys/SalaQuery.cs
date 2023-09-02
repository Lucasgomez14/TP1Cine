using Application.interfaces;
using Domain.Entities;
using Infraestructure.Persistence.Config;

namespace Infraestructure.querys
{
    public class SalaQuery : ISalaQuery
    {
        private readonly DBContext _context;

        public SalaQuery(DBContext DBContext)
        {
            this._context = DBContext;
        }
        public async Task<Sala> GetSalaById(int salaId)
        {
            return _context.Salas.SingleOrDefault(s => s.SalaId.Equals(salaId));
        }
    }
}
