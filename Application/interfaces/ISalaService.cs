using Domain.Entities;

namespace Application.interfaces
{
    public interface ISalaService
    {
        public Task<bool> ExistSala(int salaId);
        public Task<Sala> GetSalaById(int salaId);
    }
}
