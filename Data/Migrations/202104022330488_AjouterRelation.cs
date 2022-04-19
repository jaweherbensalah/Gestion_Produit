namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjouterRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            CreateTable(
                "dbo.Providings",
                c => new
                    {
                        ProductKey = c.Int(nullable: false),
                        ProviderKey = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductKey, t.ProviderKey })
                .ForeignKey("dbo.Products", t => t.ProductKey, cascadeDelete: true)
                .ForeignKey("dbo.Providers", t => t.ProviderKey, cascadeDelete: true)
                .Index(t => t.ProductKey)
                .Index(t => t.ProviderKey);
            
            AddColumn("dbo.Products", "IsBiological", c => c.Int());
            AddColumn("dbo.Products", "IsChemical", c => c.Int());
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Products", "Description", c => c.String(maxLength: 50));
            AlterColumn("dbo.Products", "address_StreetAddress", c => c.String(maxLength: 50));
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "CategoryId");
            DropColumn("dbo.Products", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Providings", "ProviderKey", "dbo.Providers");
            DropForeignKey("dbo.Providings", "ProductKey", "dbo.Products");
            DropIndex("dbo.Providings", new[] { "ProviderKey" });
            DropIndex("dbo.Providings", new[] { "ProductKey" });
            AlterColumn("dbo.Products", "address_StreetAddress", c => c.String());
            AlterColumn("dbo.Products", "Description", c => c.String());
            AlterColumn("dbo.Categories", "Name", c => c.String());
            DropColumn("dbo.Products", "IsChemical");
            DropColumn("dbo.Products", "IsBiological");
            DropTable("dbo.Providings");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
        }
    }
}
