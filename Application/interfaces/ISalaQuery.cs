using Domain.Entities;

namespace Application.interfaces
{
    public interface ISalaQuery
    {
        public Task<Sala> GetSalaById(int salaId);
    }
}
