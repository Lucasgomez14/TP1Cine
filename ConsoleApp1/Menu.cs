using Application.exceptions;
using Application.Exceptions;
using Application.UseCase;
using Domain.Entities;

namespace Cine
{
    public class Menu
    {
        FuncionService _funServ;
        public Menu(FuncionService funServ)
        {
            _funServ = funServ;
        }
        public async void ShowMenu()
        {
            bool CondicionSalida = true;
            while (CondicionSalida)
            {
                Console.Clear();
                Console.WriteLine("¡Bienvenido al menú del cine!\n");
                Console.WriteLine("Para continuar seleccione una de las siguientes opciones:\n");
                Console.WriteLine("Opción 1: Registrar una función");
                Console.WriteLine("Opción 2: Para listar las funciones por titulo o fecha");
                Console.WriteLine("opcion 3: Salir");
                Console.Write("Ingrese una opción: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        try
                        {
                            Console.Clear();
                            Console.WriteLine("Registrar una función");
                            Console.Write("Ingrese el ID de la película: ");
                            string stringIdPeli = Console.ReadLine();
                            if (!int.TryParse(stringIdPeli, out int idPelicula))
                            {
                                throw new ExceptionSintaxError("Formato no válido para un entero, pruebe nuevamente");
                            }
                            Console.Write("Ingrese el ID de la sala: ");
                            string stringIdSala = Console.ReadLine();
                            if (!int.TryParse(stringIdSala, out int salaId))
                            {
                                throw new ExceptionSintaxError("Formato no válido para un entero, pruebe nuevamente");
                            }
                            Console.Write("Ingrese una la fecha de la función (dd/mm/aaa):");
                            string date = Console.ReadLine();
                            Console.Write("Ingrese el horario de la función (hh:mm): ");
                            string time = Console.ReadLine();
                            Funcion newFuncion=await _funServ.RegisterFuncion(idPelicula, salaId, date, time);
                            Console.WriteLine("\n");
                            Console.WriteLine("Función creada correctamente!");
                            showFuncion(newFuncion);
                            Console.WriteLine("Presione una tecla para continuar");

                        }
                        catch (ExceptionSintaxError ex) 
                        {
                            Console.WriteLine(ex);
                        }
                        catch (ExceptionNotFound ex)
                        {
                            Console.WriteLine(ex);
                        }
                        catch (Conflict ex)
                        {
                            Console.WriteLine(ex);
                        }
                        Console.ReadKey(true);
                        break;

                    case "2":
                        try
                        {
                            Console.Clear();
                            Console.WriteLine("Listar funciones");
                            Console.WriteLine("Ingrese un título y/o una fecha");
                            Console.WriteLine("En caso de solo querer buscar por una opción, ya sea título o fecha, deje la otra opción en blanco");
                            Console.Write("Ingrese una fecha 'dd/mm/aaaa' (o dejar en blanco): ");
                            string date = Console.ReadLine();
                            Console.Write("Ingrese un título (o dejar en blanco): ");
                            string title = Console.ReadLine();
                            List<Funcion> listOfFunciones = await _funServ.GetFuncionesByTitleOrDate(date, title);
                            showFunciones(listOfFunciones);
                            Console.WriteLine("Presione una tecla para continuar");
                        }
                        catch (ExceptionSintaxError ex)
                        {
                            Console.WriteLine(ex);
                        }
                        Console.ReadKey(true);

                        break;
                    case "3":
                        CondicionSalida = false;
                        break;
                    default:
                        Console.WriteLine("Opción no encontrada, ingrese del 1 al 3 por favor");
                        break;
                }
            }
        }
        private void showFuncion(Funcion unaFuncion)
        {
            Console.WriteLine("\n");
            Console.WriteLine("Detalles de la función:");
            Console.WriteLine("===================================================================");
            Console.WriteLine("Sala: " + unaFuncion.Sala.Nombre.ToUpper()+"\n");
            Console.WriteLine("Pelicula: "+unaFuncion.Pelicula.Titulo.ToUpper());
            Console.WriteLine("Sinopsis: " + unaFuncion.Pelicula.Sinopsis.ToUpper() + "\n");
            Console.WriteLine("Horario: " + unaFuncion.Horario.ToString().ToUpper());
            Console.WriteLine("Fecha: "+unaFuncion.Fecha.ToString("d").ToUpper());
            
            Console.WriteLine("===================================================================");

        }
        private void showFunciones(List<Funcion>listOfFunciones)
        {
            foreach (Funcion unaFuncion in listOfFunciones)
            {
                showFuncion(unaFuncion);
            }
        }
    }
}
