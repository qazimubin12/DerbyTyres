namespace DerbyTyres.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newusedstock : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tyres", "UsedStock", c => c.Single(nullable: false));
            AddColumn("dbo.Tyres", "NewStock", c => c.Single(nullable: false));
            AddColumn("dbo.Tyres", "UsedSold", c => c.Single(nullable: false));
            AddColumn("dbo.Tyres", "NewSold", c => c.Single(nullable: false));
            DropColumn("dbo.Tyres", "Stock");
            DropColumn("dbo.Tyres", "Sold");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tyres", "Sold", c => c.Single(nullable: false));
            AddColumn("dbo.Tyres", "Stock", c => c.Single(nullable: false));
            DropColumn("dbo.Tyres", "NewSold");
            DropColumn("dbo.Tyres", "UsedSold");
            DropColumn("dbo.Tyres", "NewStock");
            DropColumn("dbo.Tyres", "UsedStock");
        }
    }
}
