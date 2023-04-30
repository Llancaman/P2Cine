using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P2Cine.Models;

namespace P2Cine.Data
{
    public class CineContext : DbContext
    {
        public CineContext (DbContextOptions<CineContext> options)
            : base(options)
        {
        }

        public DbSet<P2Cine.Models.Cine> Cines { get; set; } = default!;
        public DbSet<P2Cine.Models.Actor> Actors { get; set; } = default!;
        public DbSet<P2Cine.Models.Empleado> Empleados { get; set; }
        public DbSet<P2Cine.Models.Pelicula> Peliculas { get; set; } = default!;
        public DbSet<P2Cine.Models.Personaje> Personajes { get; set; } = default!;
        public DbSet<P2Cine.Models.PeliculasActores> PeliculasActores { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PeliculasActores>().HasKey(x => new { x.PeliculaId, x.ActorId });

            modelBuilder.Entity<PeliculasActores>()
            .HasOne(pp => pp.Actor)
            .WithMany(p => p.PeliculasActores)
            .HasForeignKey(pp => pp.ActorId);

            modelBuilder.Entity<PeliculasActores>()
            .HasOne(pp => pp.Pelicula)
            .WithMany(p => p.PeliculasActores)
            .HasForeignKey(pp => pp.PeliculaId);

            modelBuilder.Entity<Cine>()
            .HasMany(pp => pp.Empleados)
            .WithOne(p => p.Cine)
            .HasForeignKey(pp => pp.CineId);

            modelBuilder.Entity<Actor>()
            .HasOne(pp => pp.Personaje)
            .WithOne(p => p.Actor)
            .HasForeignKey<Personaje>(pp => pp.ActorId);

        }
        

    }

}
