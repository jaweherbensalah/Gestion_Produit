namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Chemical : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "address_StreetAddress", c => c.String());
            AddColumn("dbo.Products", "address_City", c => c.String());
            DropColumn("dbo.Products", "City");
            DropColumn("dbo.Products", "StreetAddress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "StreetAddress", c => c.String());
            AddColumn("dbo.Products", "City", c => c.String());
            DropColumn("dbo.Products", "address_City");
            DropColumn("dbo.Products", "address_StreetAddress");
        }
    }
}
