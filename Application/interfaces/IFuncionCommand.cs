using Domain.Entities;

namespace Application.Interfaces
{
    public interface IFuncionCommand
    {
        Task<Funcion> InsertFuncion(Funcion funcion);
    }
}
