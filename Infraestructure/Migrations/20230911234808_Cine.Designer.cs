﻿// <auto-generated />
using System;
using Infraestructure.Persistence.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructure.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20230911234808_Cine")]
    partial class Cine
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Funcion", b =>
                {
                    b.Property<int>("FuncionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FuncionId"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("Horario")
                        .HasColumnType("time");

                    b.Property<int>("PeliculaId")
                        .HasColumnType("int");

                    b.Property<int>("SalaId")
                        .HasColumnType("int");

                    b.HasKey("FuncionId");

                    b.HasIndex("PeliculaId");

                    b.HasIndex("SalaId");

                    b.ToTable("Funciones");
                });

            modelBuilder.Entity("Domain.Entities.Genero", b =>
                {
                    b.Property<int>("GeneroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GeneroId"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("GeneroId");

                    b.ToTable("Generos");

                    b.HasData(
                        new
                        {
                            GeneroId = 1,
                            Nombre = "Acción"
                        },
                        new
                        {
                            GeneroId = 2,
                            Nombre = "Aventura"
                        },
                        new
                        {
                            GeneroId = 3,
                            Nombre = "Ciencia"
                        },
                        new
                        {
                            GeneroId = 4,
                            Nombre = "Ficción"
                        },
                        new
                        {
                            GeneroId = 5,
                            Nombre = "Comedia"
                        },
                        new
                        {
                            GeneroId = 6,
                            Nombre = "Documental"
                        },
                        new
                        {
                            GeneroId = 7,
                            Nombre = "Drama"
                        },
                        new
                        {
                            GeneroId = 8,
                            Nombre = "Fantasía"
                        },
                        new
                        {
                            GeneroId = 9,
                            Nombre = "Musical"
                        },
                        new
                        {
                            GeneroId = 10,
                            Nombre = "Suspense"
                        },
                        new
                        {
                            GeneroId = 11,
                            Nombre = "Terror"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Pelicula", b =>
                {
                    b.Property<int>("PeliculaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PeliculaId"));

                    b.Property<int>("GeneroId")
                        .HasColumnType("int");

                    b.Property<string>("Poster")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Sinopsis")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Trailer")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("PeliculaId");

                    b.HasIndex("GeneroId");

                    b.ToTable("Peliculas");

                    b.HasData(
                        new
                        {
                            PeliculaId = 1,
                            GeneroId = 1,
                            Poster = "https://i.pinimg.com/1200x/6d/3d/2f/6d3d2f70e70b4582842e0805907a13b4.jpg",
                            Sinopsis = "Después de los devastadores eventos ocurridos en Vengadores: Infinity War, el universo está en ruinas debido a las acciones de Thanos, el Titán Loco. Tras la derrota...",
                            Titulo = "Avengers: End Game",
                            Trailer = "https://www.youtube.com/watch?v=PyakRSni-c0"
                        },
                        new
                        {
                            PeliculaId = 2,
                            GeneroId = 1,
                            Poster = "https://images.justwatch.com/poster/99741292/s718/los-vengadores-infinity-war.jpg",
                            Sinopsis = "Un nuevo peligro acecha procedente de las sombras del cosmos. Thanos, el infame tirano intergaláctico, tiene como objetivo reunir las seis Gemas del Infinito, artefactos de poder inimaginable, y usarlas para imponer su perversa voluntad...",
                            Titulo = "Avengers: Infinity War",
                            Trailer = "https://www.youtube.com/watch?v=823iAZOEKt8"
                        },
                        new
                        {
                            PeliculaId = 3,
                            GeneroId = 2,
                            Poster = "https://images-na.ssl-images-amazon.com/images/I/71hnVxkJZnL._AC_UL600_SR600,600_.jpg",
                            Sinopsis = "El capitán Jack Sparrow (interpretado por Johnny Depp) se embarca en una trepidante aventura para recuperar su querido barco, el Perla Negra, que ha sido robado por su rival, el capitán Barbossa...",
                            Titulo = "Piratas del Caribe: La Maldición del Perla Negra",
                            Trailer = "https://www.youtube.com/watch?v=5Itr2jHuJaw"
                        },
                        new
                        {
                            PeliculaId = 4,
                            GeneroId = 2,
                            Poster = "https://www.cartelera.com.uy/imagenes_espectaculos/moviedetail13/21840.jpg",
                            Sinopsis = "El arqueólogo y aventurero Indiana Jones (interpretado por Harrison Ford) es reclutado por el gobierno de los Estados Unidos para encontrar el Arca de la Alianza antes de que los nazis lo hagan...",
                            Titulo = "Indiana Jones y los Cazadores del Arca Perdida",
                            Trailer = "https://www.youtube.com/watch?v=ceMf9xtDA6U"
                        },
                        new
                        {
                            PeliculaId = 5,
                            GeneroId = 3,
                            Poster = "https://pics.filmaffinity.com/Interstellar-366875261-large.jpg",
                            Sinopsis = "En un futuro donde la Tierra se enfrenta a la escasez de recursos y la decadencia ambiental, un grupo de exploradores espaciales liderados por el piloto Cooper (interpretado por Matthew McConaughey) se embarca en una misión interestelar...",
                            Titulo = "Interestelar",
                            Trailer = "https://www.youtube.com/watch?v=LYS2O1nl9iM"
                        },
                        new
                        {
                            PeliculaId = 6,
                            GeneroId = 3,
                            Poster = "https://cloudfront-us-east-1.images.arcpublishing.com/artear/CSTSFCSG35DQNFZVORM4DLQCIU.jpg",
                            Sinopsis = "Drama biográfico de corte histórico basado en American Prometheus, la biografía escrita por Kai Bird y Martin J. Sherwin en torno a la figura del científico J. Robert Oppenheimer y su rol en la creación... ",
                            Titulo = "OppenHeimer",
                            Trailer = "https://www.youtube.com/watch?v=MVvGSBKV504"
                        },
                        new
                        {
                            PeliculaId = 7,
                            GeneroId = 4,
                            Poster = "https://pics.filmaffinity.com/Origen-652954101-large.jpg",
                            Sinopsis = "Dirigida por Christopher Nolan, Origen sigue a Dom Cobb (interpretado por Leonardo DiCaprio), un ladrón habilidoso que se especializa en el robo de secretos a través de la invasión de los sueños de otras personas...",
                            Titulo = "Origen",
                            Trailer = "https://www.youtube.com/watch?v=RV9L7ui9Cn8"
                        },
                        new
                        {
                            PeliculaId = 8,
                            GeneroId = 4,
                            Poster = "https://pics.filmaffinity.com/Matrix-155050517-large.jpg",
                            Sinopsis = "Dirigida por los hermanos Wachowski, Matrix presenta a Thomas Anderson (interpretado por Keanu Reeves), un programador de software que, bajo el alias de Neo, se une a un grupo de rebeldes que luchan contra...",
                            Titulo = "Matrix",
                            Trailer = "https://www.youtube.com/watch?v=sMkNB8v-0uQ"
                        },
                        new
                        {
                            PeliculaId = 9,
                            GeneroId = 5,
                            Poster = "https://www.themoviedb.org/t/p/original/sIE93oVIcCWo0z2thR4PRHwZK8d.jpg",
                            Sinopsis = "Kevin McCallister (interpretado por Macaulay Culkin) es un niño de ocho años que es accidentalmente dejado atrás cuando su familia se...",
                            Titulo = "Mi Pobre Angelito",
                            Trailer = "https://www.youtube.com/watch?v=KSpCNBIo92A"
                        },
                        new
                        {
                            PeliculaId = 10,
                            GeneroId = 5,
                            Poster = "https://pics.filmaffinity.com/Supersalidos-743461969-large.jpg",
                            Sinopsis = "Dos amigos de preparatoria, Seth (interpretado por Jonah Hill) y Evan (Michael Cera), están a punto de graduarse y enfrentan la realidad de que sus caminos podrían separarse...",
                            Titulo = "Superbad",
                            Trailer = "https://www.youtube.com/watch?v=au2Zq8D9RaY"
                        },
                        new
                        {
                            PeliculaId = 11,
                            GeneroId = 6,
                            Poster = "https://es.web.img3.acsta.net/medias/nmedia/18/95/26/08/20393348.jpg",
                            Sinopsis = "Dirigida por Malik Bendjelloul, Buscando a Sugar Man narra la historia de Sixto Rodríguez, un músico folk estadounidense que, a pesar de no haber tenido éxito comercial en su propio país...",
                            Titulo = "Buscando a Sugar Man",
                            Trailer = "https://www.youtube.com/watch?v=sg_hzT0QhPM"
                        },
                        new
                        {
                            PeliculaId = 12,
                            GeneroId = 6,
                            Poster = "https://pics.filmaffinity.com/Nuestro_planeta_Serie_de_TV-955486466-large.jpg",
                            Sinopsis = "Esta serie documental de naturaleza, narrada por David Attenborough, explora la asombrosa belleza y diversidad de la vida en la Tierra...",
                            Titulo = "Nuestro Planeta",
                            Trailer = "https://www.youtube.com/watch?v=IrER_EpwGjg"
                        },
                        new
                        {
                            PeliculaId = 13,
                            GeneroId = 7,
                            Poster = "https://pics.filmaffinity.com/La_lista_de_Schindler-473662617-large.jpg",
                            Sinopsis = " Dirigida por Steven Spielberg, La Lista de Schindler está basada en la historia real de Oskar Schindler (interpretado por Liam Neeson)...",
                            Titulo = "La Lista de Schindler",
                            Trailer = "https://www.youtube.com/watch?v=7q-ETFeMxwI"
                        },
                        new
                        {
                            PeliculaId = 14,
                            GeneroId = 7,
                            Poster = "https://es.web.img3.acsta.net/pictures/19/09/04/11/42/1166515.jpg",
                            Sinopsis = "Dirigida por Paulina García, Mujer en Llamas sigue a Ema (interpretada por Mariana Di Girolamo), una joven bailarina que está decidida a...",
                            Titulo = "Mujer en Llamas",
                            Trailer = "https://www.filmaffinity.com/es/film218131.html"
                        },
                        new
                        {
                            PeliculaId = 15,
                            GeneroId = 8,
                            Poster = "https://static.posters.cz/image/350/posters/el-senor-de-los-anillos-el-retorno-del-rey-i104633.jpg",
                            Sinopsis = "Basada en la novela de J.R.R. Tolkien, esta película dirigida por Peter Jackson sigue la...",
                            Titulo = "El Señor de los Anillos: La Comunidad del Anillo",
                            Trailer = "https://www.youtube.com/watch?v=3GJp6p_mgPo"
                        },
                        new
                        {
                            PeliculaId = 16,
                            GeneroId = 8,
                            Poster = "https://pics.filmaffinity.com/El_laberinto_del_fauno-902460283-large.jpg",
                            Sinopsis = " Dirigida por Guillermo del Toro, El Laberinto del...",
                            Titulo = "El Laberinto del Fauno",
                            Trailer = "https://www.youtube.com/watch?v=gpEh4O8Hb5Y"
                        },
                        new
                        {
                            PeliculaId = 17,
                            GeneroId = 9,
                            Poster = "https://es.web.img2.acsta.net/pictures/17/11/06/09/18/1008930.jpg",
                            Sinopsis = "Inspirada en la vida de P.T. Barnum, El Gran Showman narra la historia de cómo Barnum (interpretado por Hugh Jackman)...",
                            Titulo = "El Gran Showman",
                            Trailer = "https://www.youtube.com/watch?v=uprrVIIT0G8"
                        },
                        new
                        {
                            PeliculaId = 18,
                            GeneroId = 9,
                            Poster = "https://pics.filmaffinity.com/Los_miserables-196100834-large.jpg",
                            Sinopsis = "Basada en la novela clásica de Victor Hugo, Los Miserables sigue las vidas entrelazadas de varios personajes en la Francia del siglo XIX...",
                            Titulo = "Los Miserables",
                            Trailer = "https://www.youtube.com/watch?v=EZngbEj3W1Y"
                        },
                        new
                        {
                            PeliculaId = 19,
                            GeneroId = 10,
                            Poster = "https://www.themoviedb.org/t/p/original/sQt9N6WIC3Njn81qhrox1gPVAfp.jpg",
                            Sinopsis = "Dirigida por Jim Gillespie, esta película sigue a un grupo de amigos que, después de un trágico accidente automovilístico en el que atropellan a un hombre...",
                            Titulo = "Sé lo que Hicieron el Verano Pasado",
                            Trailer = "https://www.youtube.com/watch?v=_y6H2ybiEvs"
                        },
                        new
                        {
                            PeliculaId = 20,
                            GeneroId = 10,
                            Poster = "https://es.web.img3.acsta.net/medias/nmedia/18/74/29/15/19757760.jpg",
                            Sinopsis = "Basada en la novela de Thomas Harris, esta película dirigida por Jonathan Demme presenta a la joven agente del FBI Clarice Starling (interpretada por Jodie Foster) mientras busca la ayuda del brillante pero psicótico asesino en serie Hannibal Lecter...",
                            Titulo = "El Silencio de los Corderos",
                            Trailer = "https://www.youtube.com/watch?v=3VZa6KAxE1I"
                        },
                        new
                        {
                            PeliculaId = 21,
                            GeneroId = 11,
                            Poster = "https://m.media-amazon.com/images/I/510aqSBNaFL._AC_UF894,1000_QL80_.jpg",
                            Sinopsis = "Dirigida por William Friedkin, El Exorcista es un clásico del terror que sigue...",
                            Titulo = "El Exorcista",
                            Trailer = "https://www.youtube.com/watch?v=gYApro2YXQQ"
                        },
                        new
                        {
                            PeliculaId = 22,
                            GeneroId = 11,
                            Poster = "https://i.pinimg.com/originals/2b/02/0e/2b020e1613e1bfcea2e94451acc0bcd4.jpg",
                            Sinopsis = "Dirigida por James Wan, El Conjuro está basada en casos reales de los investigadores paranormales Ed y Lorraine Warren. La película sigue a los Warren (interpretados por Patrick Wilson y Vera Farmiga)...",
                            Titulo = "El Conjuro",
                            Trailer = "https://www.youtube.com/watch?v=_zU1gLWGnpg"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Sala", b =>
                {
                    b.Property<int>("SalaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SalaId"));

                    b.Property<int>("Capacidad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SalaId");

                    b.ToTable("Salas");

                    b.HasData(
                        new
                        {
                            SalaId = 1,
                            Capacidad = 5,
                            Nombre = "Sala 1"
                        },
                        new
                        {
                            SalaId = 2,
                            Capacidad = 15,
                            Nombre = "Sala 2"
                        },
                        new
                        {
                            SalaId = 3,
                            Capacidad = 35,
                            Nombre = "Sala 3"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Ticket", b =>
                {
                    b.Property<Guid>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("FuncionId")
                        .HasColumnType("int");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TicketId");

                    b.HasIndex("FuncionId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Domain.Entities.Funcion", b =>
                {
                    b.HasOne("Domain.Entities.Pelicula", "Pelicula")
                        .WithMany("Funciones")
                        .HasForeignKey("PeliculaId");

                    b.HasOne("Domain.Entities.Sala", "Sala")
                        .WithMany("Funciones")
                        .HasForeignKey("SalaId");

                    b.Navigation("Pelicula");

                    b.Navigation("Sala");
                });

            modelBuilder.Entity("Domain.Entities.Pelicula", b =>
                {
                    b.HasOne("Domain.Entities.Genero", "Genero")
                        .WithMany("Peliculas")
                        .HasForeignKey("GeneroId");

                    b.Navigation("Genero");
                });

            modelBuilder.Entity("Domain.Entities.Ticket", b =>
                {
                    b.HasOne("Domain.Entities.Funcion", "Funcion")
                        .WithMany("Tickets")
                        .HasForeignKey("FuncionId");

                    b.Navigation("Funcion");
                });

            modelBuilder.Entity("Domain.Entities.Funcion", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Domain.Entities.Genero", b =>
                {
                    b.Navigation("Peliculas");
                });

            modelBuilder.Entity("Domain.Entities.Pelicula", b =>
                {
                    b.Navigation("Funciones");
                });

            modelBuilder.Entity("Domain.Entities.Sala", b =>
                {
                    b.Navigation("Funciones");
                });
#pragma warning restore 612, 618
        }
    }
}
