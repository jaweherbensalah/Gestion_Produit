namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnableAnnotation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Category_CategoryId" });
            RenameColumn(table: "dbo.Products", name: "Category_CategoryId", newName: "CategoryId");
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Providers", "Email", c => c.String(nullable: false));
            CreateIndex("dbo.Products", "CategoryId");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
            DropColumn("dbo.Providers", "ConfirmPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Providers", "ConfirmPassword", c => c.String());
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            AlterColumn("dbo.Providers", "Email", c => c.String());
            AlterColumn("dbo.Products", "CategoryId", c => c.Int());
            AlterColumn("dbo.Products", "Name", c => c.String());
            RenameColumn(table: "dbo.Products", name: "CategoryId", newName: "Category_CategoryId");
            CreateIndex("dbo.Products", "Category_CategoryId");
            AddForeignKey("dbo.Products", "Category_CategoryId", "dbo.Categories", "CategoryId");
        }
    }
}
