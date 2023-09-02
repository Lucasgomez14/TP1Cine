using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence.Config;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Command
{
    public class FuncionCommand : IFuncionCommand
    {
        private readonly DBContext _context;

        public FuncionCommand(DBContext DBContext)
        {
            this._context = DBContext;
        }
        public async Task<Funcion> InsertFuncion(Funcion funcion)
        {
            try
            {
                _context.Add(funcion);
                _context.SaveChanges();
                return funcion;
            }
            catch (DbUpdateException)
            {
                throw new ExceptionSintaxError("No se pudo registrar la función");
            }
        }
    }
}
