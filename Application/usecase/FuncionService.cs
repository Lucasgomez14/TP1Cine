using Application.exceptions;
using Application.Exceptions;
using Application.interfaces;
using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCase
{
    public class FuncionService : IFuncionService
    {
        private readonly IFuncionQuery _query;
        private readonly IFuncionCommand _command;
        private readonly IPeliculaService _peliculaService;
        private readonly ISalaService _salaService;

        public FuncionService(IFuncionCommand funcionCommand, IFuncionQuery funcionQuery, IPeliculaService peliculaService, ISalaService salaService)
        {
            _command = funcionCommand;
            _query = funcionQuery;
            _peliculaService = peliculaService;
            _salaService = salaService;
        }

        public async Task<Funcion> RegisterFuncion(int peliculaId, int salaId, string fecha, string horario)
        {
            try
            {
                if (!await _peliculaService.ExistPelicula(peliculaId)) { throw new ExceptionNotFound("No existe la película"); }
                if (!await _salaService.ExistSala(salaId)) { throw new ExceptionNotFound("No existe la sala"); }
                if (!DateTime.TryParse(fecha, out DateTime date)) { throw new ExceptionSintaxError("Formato érroneo para la fecha"); }
                if (!TimeSpan.TryParse(horario, out TimeSpan tiempo) || tiempo.TotalHours > 24) { throw new ExceptionSintaxError("Formato érroneo para el horario, , ingrese desde las 00:00 a 24:00Hs"); }
                if (!await VerifyIfSalaisEmpty(date, tiempo, salaId)) { throw new Conflict("La sala ya está ocupada en esa fecha y horario!"); }
                date = DateTime.Parse(fecha);
                var newFuncion = new Funcion
                {
                    PeliculaId = peliculaId,
                    SalaId = salaId,
                    Fecha = date,
                    Horario = tiempo,
                    Tickets = new List<Ticket>()
                };
                newFuncion = await _command.InsertFuncion(newFuncion);
                return newFuncion;

            }
            catch (ExceptionSintaxError ex)
            {
                throw new ExceptionSintaxError("Error: " + ex.Message);
            }
            catch (ExceptionNotFound ex)
            {
                throw new ExceptionNotFound("Error: " + ex.Message);
            }
            catch (Conflict ex)
            {
                throw new Conflict("Error: " + ex.Message);
            }
        }

        public async Task<List<Funcion>> GetFuncionesByTitleOrDate(string fecha, string title)
        {
            try
            {
                DateTime date;
                List<Funcion> funcionesByDate = new List<Funcion>();
                List<Funcion> funcionesByTitle = new List<Funcion>();
                List<Funcion> listFunciones = new List<Funcion>();

                if (title == "" && fecha == "")
                {
                    listFunciones = await _query.GetAllFunciones();
                }
                if (fecha != "")
                {
                    if (!DateTime.TryParse(fecha, out date)) { throw new ExceptionSintaxError("Formato érroneo para la fecha"); }
                    listFunciones = await _query.GetFuncionesByDate(date);

                    if (listFunciones.Count() == 0 && title != "")
                    { return listFunciones; }
                }
                if (title != "")
                {
                    funcionesByTitle = await _query.GetFuncionesByTitle(title);
                    if (listFunciones.Count() > 0)
                    { listFunciones = GroupData(listFunciones, funcionesByTitle); }
                    else
                    { listFunciones = funcionesByTitle; }
                }

                return listFunciones;
            }
            catch (ExceptionSintaxError ex)
            {
                throw new ExceptionSintaxError("Error en la sintaxis ingresada para la fecha: " + ex.Message);
            }
        }

        private List<Funcion> GroupData(List<Funcion> principalList, List<Funcion> secundaryList)
        {
            List<Funcion> unitedList = new();
            foreach (Funcion unaFuncion in secundaryList)
            {
                if (principalList.Any(f => f.FuncionId == unaFuncion.FuncionId && f.Fecha.Date == unaFuncion.Fecha.Date))
                { unitedList.Add(unaFuncion); }
            }
            return unitedList;
        }
        private async Task<bool> VerifyIfSalaisEmpty(DateTime fecha, TimeSpan horario, int salaId)
        {
            List<Funcion> listFunciones = await _query.GetAllFunciones();
            if (listFunciones.Any(f => f.SalaId == salaId && f.Fecha == fecha && f.Horario == horario))
            { return false; }
            else
            { return true; }

        }
    }
}
