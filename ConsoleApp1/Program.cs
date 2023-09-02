// See https://aka.ms/new-console-template for more information
using Application.usecase;
using Application.UseCase;
using Cine;
using Domain.Entities;
using Infraestructure.Command;
using Infraestructure.Persistence.Config;
using Infraestructure.querys;
using Infraestructure.Querys;

DBContext Cine = new DBContext();

FuncionQuery funQue = new FuncionQuery(Cine);
FuncionCommand funCom = new FuncionCommand(Cine);
SalaQuery salQuery = new SalaQuery(Cine);
SalaService salaServ = new SalaService(salQuery);
PeliculaQuery pelQuery = new PeliculaQuery(Cine);
PeliculaService pelServ = new PeliculaService(pelQuery);
FuncionService funServ = new FuncionService(funCom, funQue, pelServ, salaServ);


Pelicula prueba = new Pelicula
{
    Poster = "prueba",
    Titulo = "pruena",
    Sinopsis = "prueba",

};
Menu elMenu = new Menu(funServ);
elMenu.ShowMenu();
