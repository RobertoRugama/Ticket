namespace GestionTicket.Migrations
{
    using GestionTicket.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GestionTicket.Models.TicketsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GestionTicket.Models.TicketsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var cargos = new List<Cargo>
            {
                new Cargo { Nombre="Ofical de Soporte Aplicaciones", Area ="Departamento Informatica"},
                new Cargo { Nombre="Oficial de Operaciones", Area="Operaciones y Servicios"},
                new Cargo { Nombre="Ofical de Cumplimiento", Area ="Cumplimiento"},
                new Cargo { Nombre= "Soporte Callcenter", Area ="Servicio Atencion a Clientes"}
            };
            cargos.ForEach(c => context.Cargos.AddOrUpdate(a => a.Nombre, c));
            context.SaveChanges();

            var estados = new List<Estado>
            {
                new Estado { Id=1, Nombre="Abierto", Activo =true},
                new Estado { Id=2, Nombre="Pendiente", Activo=true},
                new Estado { Id=3, Nombre="En Proceso", Activo = true},
                new Estado { Id=4, Nombre="Resuelto", Activo = true},
                new Estado { Id=5, Nombre= "Cerrado", Activo =true},
                new Estado { Id=6, Nombre= "Cancelado", Activo =true},
                new Estado { Id=7, Nombre= "Reabrierto", Activo =true}
            };
            estados.ForEach(c => context.Estados.AddOrUpdate(a => a.Nombre, c));
            context.SaveChanges();

            var responsables = new List<Responsable>
            {
                new Responsable { Nombres="Roberto Jesus", Apellidos="Rugama Hernandez", CargoId=1, Correo="roberto.rugama@cashpak.com", Activo =true},
                new Responsable { Nombres="Alberto Martin", Apellidos="Centeno Cruz", CargoId=2, Correo="Alberto.Centeno@cashpak.com", Activo =true},
                new Responsable { Nombres="Jorge", Apellidos="Chavez", CargoId=3, Correo="Jorge.chavez@cashpak.com", Activo =true},
                new Responsable { Nombres="Osman", Apellidos="Obando", CargoId=4, Correo="osman.obando@cashpak.com", Activo =true},
                new Responsable { Nombres="Gabriela", Apellidos="Membreño", CargoId=1, Correo="gabrieal.membreno@cashpak.com", Activo =true},

            };
            responsables.ForEach(c => context.Responsables.AddOrUpdate(a => a.Nombres, c));
            context.SaveChanges();

            var usuarios = new List<Usuario>
            {
                new Usuario { Nombres="Darwind", Apellidos="Mendez", Correo="darwind.mendez@cashpak.com",Telefono="+50558764317", Activo =true },
                new Usuario { Nombres="Jose Medardo", Apellidos="Reyes Blandon", Correo="medardo.reyers@cashpak.com",Telefono="+50556567896", Activo =true },
                new Usuario { Nombres="Dania Maria", Apellidos="Cordero Balle", Correo="Dania.Cordero@cashpak.com",Telefono="+50554567896", Activo =true },
                new Usuario { Nombres="Masiel Yesenia", Apellidos="Cruz Ramirez", Correo="yesenia.cruz@cashpak.com",Telefono="+50545634578", Activo =true },
                new Usuario { Nombres="Modesto", Apellidos="Corea", Correo="Modesto.corea@cashpak.com",Telefono="+50545634867", Activo =true },
            };
            usuarios.ForEach(c => context.Usuarios.AddOrUpdate(a => a.Nombres, c));
            context.SaveChanges();

            var tickets = new List<Ticket>
            {
                new Ticket { FechaGeneracion=DateTime.Now, Descripcion="Creacion de Ususarios", UsuarioId=2,ResponsableId=3,EstadoId=1},
                new Ticket { FechaGeneracion=DateTime.Now, Descripcion="Alta de usuario", UsuarioId=3,ResponsableId=2,EstadoId=4},
                new Ticket { FechaGeneracion=DateTime.Now, Descripcion="Actualizar Datos Clientes", UsuarioId=4,ResponsableId=1,EstadoId=5},
                new Ticket { FechaGeneracion=DateTime.Now, Descripcion="Solicitud Reportes data...", UsuarioId=5,ResponsableId=2,EstadoId=4},
                new Ticket { FechaGeneracion=DateTime.Now, Descripcion="Validar Tranaccion", UsuarioId=2,ResponsableId=3,EstadoId=4,Solucion="Se procedió con la autorizacion"},
                new Ticket { FechaGeneracion=DateTime.Now, Descripcion="Solicitud Data transacccional", UsuarioId=2,ResponsableId=3,EstadoId=4, Solucion="Se envió reporte por correo a las personas correspondientes"},
            };
            tickets.ForEach(c => context.Tickets.AddOrUpdate(a => a.Descripcion, c));
            context.SaveChanges();

        }
    }
}
