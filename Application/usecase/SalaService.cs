using Application.interfaces;
using Domain.Entities;

namespace Application.usecase
{
    public class SalaService : ISalaService
    {
        private readonly ISalaQuery _query;

        public SalaService(ISalaQuery salaQuery)
        {
            _query = salaQuery;
        }
        public async Task<bool> ExistSala(int salaId)
        {

            if (await GetSalaById(salaId) == null)
            { return false; }
            else
            { return true; }
        }
        public async Task<Sala> GetSalaById(int salaId)
        {
            return await _query.GetSalaById(salaId);
        }
    }
}
