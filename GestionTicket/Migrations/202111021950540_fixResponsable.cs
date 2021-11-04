namespace GestionTicket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixResponsable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Responsable", "Activo", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Responsable", "Activo", c => c.Boolean());
        }
    }
}
