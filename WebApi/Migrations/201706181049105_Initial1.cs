namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "NumberOfWins", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "NumberOfLoses", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Date", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "NumberOfLoses");
            DropColumn("dbo.Users", "NumberOfWins");
            DropColumn("dbo.Users", "Date");
        }
    }
}
