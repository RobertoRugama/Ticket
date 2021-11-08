namespace GestionTicket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class login_usuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "Password", c => c.String(nullable: false, maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuario", "Password");
        }
    }
}
