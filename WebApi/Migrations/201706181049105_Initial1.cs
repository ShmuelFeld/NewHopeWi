namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "numberOfWins", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "numberOfLoses", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "numberOfLoses");
            DropColumn("dbo.Users", "numberOfWins");
        }
    }
}
