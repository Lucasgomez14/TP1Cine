using Domain.Entities;

namespace Application.Interfaces
{
    public interface IFuncionService
    {
        Task<Funcion> RegisterFuncion(int peliculaId, int salaId, string fecha, string horario);
        Task<List<Funcion>> GetFuncionesByTitleOrDate(string date, string title);

    }
}
