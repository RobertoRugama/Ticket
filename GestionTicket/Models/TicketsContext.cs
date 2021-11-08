namespace GestionTicket.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TicketsContext : DbContext
    {
        public TicketsContext()
            : base("name=TicketsContext")
        {
        }

        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<Responsable> Responsables { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Cargo> Cargos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estado>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Estado>()
                .HasMany(e => e.Ticket)
                .WithRequired(e => e.Estado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Responsable>()
                .Property(e => e.Nombres)
                .IsUnicode(false);

            modelBuilder.Entity<Responsable>()
                .Property(e => e.Apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<Responsable>()
                .Property(e => e.Correo)
                .IsUnicode(false);

            modelBuilder.Entity<Cargo>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Cargo>()
                .HasMany(e => e.Responsables)
                .WithRequired(e => e.Cargo)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<Responsable>()
                .HasMany(e => e.Ticket)
                .WithRequired(e => e.Responsable)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ticket>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Ticket>()
                .Property(e => e.Solucion)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nombres)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Correo)
                .IsUnicode(false); 

            modelBuilder.Entity<Usuario>()
            .Property(e => e.Password)
            .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Ticket)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);
        }
    }
}
