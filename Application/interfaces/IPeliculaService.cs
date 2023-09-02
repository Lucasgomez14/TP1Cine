namespace Application.Interfaces
{
    public interface IPeliculaService
    {
        public Task<bool> ExistPelicula(int peliculaId);
    }
}
