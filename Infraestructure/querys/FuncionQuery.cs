using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence.Config;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Querys
{
    public class FuncionQuery : IFuncionQuery
    {
        private readonly DBContext _context;

        public FuncionQuery(DBContext DBContext)
        {
            this._context = DBContext;
        }
        public async Task<List<Funcion>> GetFuncionesByDate(DateTime fecha)
        {
            try
            {
                //podria traer info de la sala también
                List<Funcion> FuncionesPorFecha = _context.Funciones
                .Include(fun => fun.Pelicula)
                .Include(fun => fun.Sala)
                .Where(fun => fun.Fecha.Date == fecha.Date)
                .ToList();
                return FuncionesPorFecha;
            }
            catch (DbUpdateException)
            {
                throw new ExceptionSintaxError("No hay ninguna función para esta fecha");
            }

        }

        public async Task<List<Funcion>> GetFuncionesByTitle(string title)
        {
            try
            {
                List<Funcion> FuncionesPorTitulo = _context.Funciones
               .Include(pel => pel.Pelicula)
               .Include(fun => fun.Sala)
               .Where(pel => pel.Pelicula.Titulo.Contains(title))
               .ToList();
                return FuncionesPorTitulo;
            }
            catch (DbUpdateException)
            {
                throw new ExceptionSintaxError("No hay ninguna función para esta película");
            }
        }
        public async Task<List<Funcion>> GetAllFunciones()
        {
            try
            {
                List<Funcion> todasLasFunciones = _context.Funciones
                .Include(fun => fun.Sala)
                .Include(fun => fun.Pelicula)
                .ToList();

                return todasLasFunciones;
            }
            catch (DbUpdateException)
            {
                throw new ExceptionSintaxError("No existen funciones disponibles");
            }
        }
    }
}
