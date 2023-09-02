﻿namespace Domain.Entities
{
    public class Pelicula
    {
        public int PeliculaId { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public string Poster { get; set; }
        public string Trailer { get; set; }
        public int GeneroId { get; set; }
        public Genero Genero { get; set; }
        public ICollection<Funcion> Funciones { get; set; }
    }
}
