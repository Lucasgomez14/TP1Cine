using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Cine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    GeneroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.GeneroId);
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    SalaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Capacidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.SalaId);
                });

            migrationBuilder.CreateTable(
                name: "Peliculas",
                columns: table => new
                {
                    PeliculaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sinopsis = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Poster = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Trailer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GeneroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.PeliculaId);
                    table.ForeignKey(
                        name: "FK_Peliculas_Generos_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Generos",
                        principalColumn: "GeneroId");
                });

            migrationBuilder.CreateTable(
                name: "Funciones",
                columns: table => new
                {
                    FuncionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeliculaId = table.Column<int>(type: "int", nullable: false),
                    SalaId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Horario = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funciones", x => x.FuncionId);
                    table.ForeignKey(
                        name: "FK_Funciones_Peliculas_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "PeliculaId");
                    table.ForeignKey(
                        name: "FK_Funciones_Salas_SalaId",
                        column: x => x.SalaId,
                        principalTable: "Salas",
                        principalColumn: "SalaId");
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FuncionId = table.Column<int>(type: "int", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Funciones_FuncionId",
                        column: x => x.FuncionId,
                        principalTable: "Funciones",
                        principalColumn: "FuncionId");
                });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "GeneroId", "Nombre" },
                values: new object[,]
                {
                    { 1, "Acción" },
                    { 2, "Aventura" },
                    { 3, "Ciencia" },
                    { 4, "Ficción" },
                    { 5, "Comedia" },
                    { 6, "Documental" },
                    { 7, "Drama" },
                    { 8, "Fantasía" },
                    { 9, "Musical" },
                    { 10, "Suspense" },
                    { 11, "Terror" }
                });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "SalaId", "Capacidad", "Nombre" },
                values: new object[,]
                {
                    { 1, 5, "Sala 1" },
                    { 2, 15, "Sala 2" },
                    { 3, 35, "Sala 3" }
                });

            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "PeliculaId", "GeneroId", "Poster", "Sinopsis", "Titulo", "Trailer" },
                values: new object[,]
                {
                    { 1, 1, "https://i.pinimg.com/1200x/6d/3d/2f/6d3d2f70e70b4582842e0805907a13b4.jpg", "Después de los devastadores eventos ocurridos en Vengadores: Infinity War, el universo está en ruinas debido a las acciones de Thanos, el Titán Loco. Tras la derrota...", "Avengers: End Game", "https://www.youtube.com/watch?v=PyakRSni-c0" },
                    { 2, 1, "https://images.justwatch.com/poster/99741292/s718/los-vengadores-infinity-war.jpg", "Un nuevo peligro acecha procedente de las sombras del cosmos. Thanos, el infame tirano intergaláctico, tiene como objetivo reunir las seis Gemas del Infinito, artefactos de poder inimaginable, y usarlas para imponer su perversa voluntad...", "Avengers: Infinity War", "https://www.youtube.com/watch?v=823iAZOEKt8" },
                    { 3, 2, "https://images-na.ssl-images-amazon.com/images/I/71hnVxkJZnL._AC_UL600_SR600,600_.jpg", "El capitán Jack Sparrow (interpretado por Johnny Depp) se embarca en una trepidante aventura para recuperar su querido barco, el Perla Negra, que ha sido robado por su rival, el capitán Barbossa...", "Piratas del Caribe: La Maldición del Perla Negra", "https://www.youtube.com/watch?v=5Itr2jHuJaw" },
                    { 4, 2, "https://www.cartelera.com.uy/imagenes_espectaculos/moviedetail13/21840.jpg", "El arqueólogo y aventurero Indiana Jones (interpretado por Harrison Ford) es reclutado por el gobierno de los Estados Unidos para encontrar el Arca de la Alianza antes de que los nazis lo hagan...", "Indiana Jones y los Cazadores del Arca Perdida", "https://www.youtube.com/watch?v=ceMf9xtDA6U" },
                    { 5, 3, "https://pics.filmaffinity.com/Interstellar-366875261-large.jpg", "En un futuro donde la Tierra se enfrenta a la escasez de recursos y la decadencia ambiental, un grupo de exploradores espaciales liderados por el piloto Cooper (interpretado por Matthew McConaughey) se embarca en una misión interestelar...", "Interestelar", "https://www.youtube.com/watch?v=LYS2O1nl9iM" },
                    { 6, 3, "https://cloudfront-us-east-1.images.arcpublishing.com/artear/CSTSFCSG35DQNFZVORM4DLQCIU.jpg", "Drama biográfico de corte histórico basado en American Prometheus, la biografía escrita por Kai Bird y Martin J. Sherwin en torno a la figura del científico J. Robert Oppenheimer y su rol en la creación... ", "OppenHeimer", "https://www.youtube.com/watch?v=MVvGSBKV504" },
                    { 7, 4, "https://pics.filmaffinity.com/Origen-652954101-large.jpg", "Dirigida por Christopher Nolan, Origen sigue a Dom Cobb (interpretado por Leonardo DiCaprio), un ladrón habilidoso que se especializa en el robo de secretos a través de la invasión de los sueños de otras personas...", "Origen", "https://www.youtube.com/watch?v=RV9L7ui9Cn8" },
                    { 8, 4, "https://pics.filmaffinity.com/Matrix-155050517-large.jpg", "Dirigida por los hermanos Wachowski, Matrix presenta a Thomas Anderson (interpretado por Keanu Reeves), un programador de software que, bajo el alias de Neo, se une a un grupo de rebeldes que luchan contra...", "Matrix", "https://www.youtube.com/watch?v=sMkNB8v-0uQ" },
                    { 9, 5, "https://www.themoviedb.org/t/p/original/sIE93oVIcCWo0z2thR4PRHwZK8d.jpg", "Kevin McCallister (interpretado por Macaulay Culkin) es un niño de ocho años que es accidentalmente dejado atrás cuando su familia se...", "Mi Pobre Angelito", "https://www.youtube.com/watch?v=KSpCNBIo92A" },
                    { 10, 5, "https://pics.filmaffinity.com/Supersalidos-743461969-large.jpg", "Dos amigos de preparatoria, Seth (interpretado por Jonah Hill) y Evan (Michael Cera), están a punto de graduarse y enfrentan la realidad de que sus caminos podrían separarse...", "Superbad", "https://www.youtube.com/watch?v=au2Zq8D9RaY" },
                    { 11, 6, "https://es.web.img3.acsta.net/medias/nmedia/18/95/26/08/20393348.jpg", "Dirigida por Malik Bendjelloul, Buscando a Sugar Man narra la historia de Sixto Rodríguez, un músico folk estadounidense que, a pesar de no haber tenido éxito comercial en su propio país...", "Buscando a Sugar Man", "https://www.youtube.com/watch?v=sg_hzT0QhPM" },
                    { 12, 6, "https://pics.filmaffinity.com/Nuestro_planeta_Serie_de_TV-955486466-large.jpg", "Esta serie documental de naturaleza, narrada por David Attenborough, explora la asombrosa belleza y diversidad de la vida en la Tierra...", "Nuestro Planeta", "https://www.youtube.com/watch?v=IrER_EpwGjg" },
                    { 13, 7, "https://pics.filmaffinity.com/La_lista_de_Schindler-473662617-large.jpg", " Dirigida por Steven Spielberg, La Lista de Schindler está basada en la historia real de Oskar Schindler (interpretado por Liam Neeson)...", "La Lista de Schindler", "https://www.youtube.com/watch?v=7q-ETFeMxwI" },
                    { 14, 7, "https://es.web.img3.acsta.net/pictures/19/09/04/11/42/1166515.jpg", "Dirigida por Paulina García, Mujer en Llamas sigue a Ema (interpretada por Mariana Di Girolamo), una joven bailarina que está decidida a...", "Mujer en Llamas", "https://www.filmaffinity.com/es/film218131.html" },
                    { 15, 8, "https://static.posters.cz/image/350/posters/el-senor-de-los-anillos-el-retorno-del-rey-i104633.jpg", "Basada en la novela de J.R.R. Tolkien, esta película dirigida por Peter Jackson sigue la...", "El Señor de los Anillos: La Comunidad del Anillo", "https://www.youtube.com/watch?v=3GJp6p_mgPo" },
                    { 16, 8, "https://pics.filmaffinity.com/El_laberinto_del_fauno-902460283-large.jpg", " Dirigida por Guillermo del Toro, El Laberinto del...", "El Laberinto del Fauno", "https://www.youtube.com/watch?v=gpEh4O8Hb5Y" },
                    { 17, 9, "https://es.web.img2.acsta.net/pictures/17/11/06/09/18/1008930.jpg", "Inspirada en la vida de P.T. Barnum, El Gran Showman narra la historia de cómo Barnum (interpretado por Hugh Jackman)...", "El Gran Showman", "https://www.youtube.com/watch?v=uprrVIIT0G8" },
                    { 18, 9, "https://pics.filmaffinity.com/Los_miserables-196100834-large.jpg", "Basada en la novela clásica de Victor Hugo, Los Miserables sigue las vidas entrelazadas de varios personajes en la Francia del siglo XIX...", "Los Miserables", "https://www.youtube.com/watch?v=EZngbEj3W1Y" },
                    { 19, 10, "https://www.themoviedb.org/t/p/original/sQt9N6WIC3Njn81qhrox1gPVAfp.jpg", "Dirigida por Jim Gillespie, esta película sigue a un grupo de amigos que, después de un trágico accidente automovilístico en el que atropellan a un hombre...", "Sé lo que Hicieron el Verano Pasado", "https://www.youtube.com/watch?v=_y6H2ybiEvs" },
                    { 20, 10, "https://es.web.img3.acsta.net/medias/nmedia/18/74/29/15/19757760.jpg", "Basada en la novela de Thomas Harris, esta película dirigida por Jonathan Demme presenta a la joven agente del FBI Clarice Starling (interpretada por Jodie Foster) mientras busca la ayuda del brillante pero psicótico asesino en serie Hannibal Lecter...", "El Silencio de los Corderos", "https://www.youtube.com/watch?v=3VZa6KAxE1I" },
                    { 21, 11, "https://m.media-amazon.com/images/I/510aqSBNaFL._AC_UF894,1000_QL80_.jpg", "Dirigida por William Friedkin, El Exorcista es un clásico del terror que sigue...", "El Exorcista", "https://www.youtube.com/watch?v=gYApro2YXQQ" },
                    { 22, 11, "https://i.pinimg.com/originals/2b/02/0e/2b020e1613e1bfcea2e94451acc0bcd4.jpg", "Dirigida por James Wan, El Conjuro está basada en casos reales de los investigadores paranormales Ed y Lorraine Warren. La película sigue a los Warren (interpretados por Patrick Wilson y Vera Farmiga)...", "El Conjuro", "https://www.youtube.com/watch?v=_zU1gLWGnpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_PeliculaId",
                table: "Funciones",
                column: "PeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_SalaId",
                table: "Funciones",
                column: "SalaId");

            migrationBuilder.CreateIndex(
                name: "IX_Peliculas_GeneroId",
                table: "Peliculas",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FuncionId",
                table: "Tickets",
                column: "FuncionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Funciones");

            migrationBuilder.DropTable(
                name: "Peliculas");

            migrationBuilder.DropTable(
                name: "Salas");

            migrationBuilder.DropTable(
                name: "Generos");
        }
    }
}
