namespace DerbyTyres.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class brandname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tyres", "Brand", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tyres", "Brand");
        }
    }
}
