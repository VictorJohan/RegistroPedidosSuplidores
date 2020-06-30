using Microsoft.EntityFrameworkCore;
using RegistroPedidosSuplidor.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroPedidosSuplidor.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Ordenes> Ordenes { get; set; }
        public DbSet<Suplidores> Suplidores { get; set; }
        public DbSet<Productos> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= DATA\OrdenesSuplidores.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Registro suplidores
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores { SuplidoreId = 1, Nombres = "Victor" });
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores { SuplidoreId = 2, Nombres = "Johan" });
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores { SuplidoreId = 3, Nombres = "Palma" });
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores { SuplidoreId = 4, Nombres = "Rodríguez" });

            //Registro Productos
            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 1,
                Costo = 1500.50,
                Descripcion = "Es un producto 1",
                Invetario = 10
            });

            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 2,
                Costo = 5000,
                Descripcion = "Es un producto 2",
                Invetario = 10
            });

            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 3,
                Costo = 3000,
                Descripcion = "Es un producto 3",
                Invetario = 10
            });

            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 4,
                Costo = 120,
                Descripcion = "Es un producto 4",
                Invetario = 10
            });

            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 5,
                Costo = 4560,
                Descripcion = "Es un producto 5",
                Invetario = 10
            });

            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 6,
                Costo = 2000,
                Descripcion = "Es un producto 6",
                Invetario = 10
            });

            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 7,
                Costo = 1000,
                Descripcion = "Es un producto 7",
                Invetario = 10
            });
        }
    }
}
