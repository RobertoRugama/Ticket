namespace GestionTicket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cargo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                        Area = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Responsable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombres = c.String(nullable: false, maxLength: 40, unicode: false),
                        Apellidos = c.String(nullable: false, maxLength: 50, unicode: false),
                        Correo = c.String(nullable: false, maxLength: 50, unicode: false),
                        CargoId = c.Int(nullable: false),
                        Activo = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cargo", t => t.CargoId)
                .Index(t => t.CargoId);
            
            CreateTable(
                "dbo.Ticket",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaGeneracion = c.DateTime(nullable: false),
                        Descripcion = c.String(nullable: false, unicode: false),
                        Solucion = c.String(unicode: false),
                        EstadoId = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                        ResponsableId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estado", t => t.EstadoId)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId)
                .ForeignKey("dbo.Responsable", t => t.ResponsableId)
                .Index(t => t.EstadoId)
                .Index(t => t.UsuarioId)
                .Index(t => t.ResponsableId);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 30, unicode: false),
                        Activo = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombres = c.String(nullable: false, maxLength: 50, unicode: false),
                        Apellidos = c.String(nullable: false, maxLength: 50, unicode: false),
                        Telefono = c.String(nullable: false, maxLength: 50, unicode: false),
                        Correo = c.String(nullable: false, maxLength: 50, unicode: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Responsable", "CargoId", "dbo.Cargo");
            DropForeignKey("dbo.Ticket", "ResponsableId", "dbo.Responsable");
            DropForeignKey("dbo.Ticket", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Ticket", "EstadoId", "dbo.Estado");
            DropIndex("dbo.Ticket", new[] { "ResponsableId" });
            DropIndex("dbo.Ticket", new[] { "UsuarioId" });
            DropIndex("dbo.Ticket", new[] { "EstadoId" });
            DropIndex("dbo.Responsable", new[] { "CargoId" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Estado");
            DropTable("dbo.Ticket");
            DropTable("dbo.Responsable");
            DropTable("dbo.Cargo");
        }
    }
}
