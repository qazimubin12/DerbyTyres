namespace DerbyTyres.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stocksold : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tyres", "Sold", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tyres", "Sold");
        }
    }
}
