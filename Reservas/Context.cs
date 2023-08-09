using Microsoft.EntityFrameworkCore;
using Reservas.BData.Data.Entity;

namespace Reservas.BData
{
    public class Context : DbContext
    {
        public DbSet<Persona> Personas => Set<Persona>();
        public DbSet<Huespedes> Huesped => Set<Huespedes>();
        public DbSet<Habitacion> Habitaciones => Set<Habitacion>();
        public DbSet<Reserva> Reservas => Set<Reserva>();

        public DbSet<Reserva_Habitaciones> Reservas_Habitacion => Set<Reserva_Habitaciones>();
        public Context(DbContextOptions options) : base(options) 
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Habitacion>(o =>
            {
                o.Property(b => b.Precio).HasColumnType("int");
            });

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Habitacion>(o =>
        //    {
        //        o.HasKey(b => b.Nhab);
        //        o.Property(b => b.Precio).HasColumnType("Decimal(10,2)");
        //        o.Property(b => b.Garantia).HasColumnType("Decimal(10,2)");
        //    });
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Habitacion>().HasData(new Habitacion 
        //    {
        //        Id = 1,
        //        Nhab=1,
        //        Camas=20,
        //        Estado="Reservada",
        //        Precio=200,
        //        Garantia=30
        //    });

        //}

    }
}
