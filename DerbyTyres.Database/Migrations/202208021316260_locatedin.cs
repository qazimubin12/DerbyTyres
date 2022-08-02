namespace DerbyTyres.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class locatedin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tyres", "LocatedIn", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tyres", "LocatedIn");
        }
    }
}
