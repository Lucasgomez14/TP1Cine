﻿using Domain.Entities;

namespace Application.Interfaces
{
    public interface IFuncionQuery
    {
        Task<List<Funcion>> GetFuncionesByTitle(string title);
        Task<List<Funcion>> GetFuncionesByDate(DateTime fecha);
        Task<List<Funcion>> GetAllFunciones();
    }
}
