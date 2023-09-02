using Domain.Entities;
using Infraestructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Config
{
    public class DBContext : DbContext
    {
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Funcion> Funciones { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Genero> Generos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=Cine;Trusted_Connection=True;TrustServerCertificate=True");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Salas
            modelBuilder.Entity<Sala>()
                .HasMany<Funcion>(sala => sala.Funciones)
                .WithOne(fun => fun.Sala)
                .HasForeignKey(fun => fun.SalaId)
                .IsRequired(false);
            modelBuilder.ApplyConfiguration(new SalasData());
            modelBuilder.Entity<Sala>(entity =>
            {
                entity.Property(sala => sala.Nombre)
                .HasMaxLength(50)
                .IsRequired();
            });

            //Generos
            modelBuilder.Entity<Genero>()
                .HasMany<Pelicula>(gen => gen.Peliculas)
                .WithOne(pel => pel.Genero)
                .HasForeignKey(pel => pel.GeneroId)
                .IsRequired(false);
            modelBuilder.ApplyConfiguration(new GenerosData());
            modelBuilder.Entity<Genero>(entity =>
            {
                entity.Property(gen => gen.Nombre)
                .HasMaxLength(50)
                .IsRequired();
            });

            //Funciones 
            modelBuilder.Entity<Funcion>()
                .HasMany<Ticket>(fun => fun.Tickets)
                .WithOne(tick => tick.Funcion)
                .HasForeignKey(tick => tick.FuncionId)
                .IsRequired(false);

            //Pelicula
            modelBuilder.Entity<Pelicula>()
                .HasMany<Funcion>(pel => pel.Funciones)
                .WithOne(fun => fun.Pelicula)
                .HasForeignKey(fun => fun.PeliculaId)
                .IsRequired(false);
            modelBuilder.ApplyConfiguration(new PeliculasData());
            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.Property(pel => pel.Titulo)
                .HasMaxLength(50)
                .IsRequired();
                entity.Property(pel => pel.Sinopsis)
                .HasMaxLength(1000)
                .IsRequired();
                entity.Property(pel => pel.Poster)
                .HasMaxLength(200)
                .IsRequired();
                entity.Property(pel => pel.Trailer)
                .HasMaxLength(200)
                .IsRequired();
            });

            //Ticket
            modelBuilder.Entity<Ticket>(entity =>
              {
                  entity.Property(tick => tick.Usuario)
                  .HasMaxLength(50)
                  .IsRequired();
              });

        }
    }
}