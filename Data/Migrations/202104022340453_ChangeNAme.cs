namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeNAme : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Categories", newName: "MyCategories");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.MyCategories", newName: "Categories");
        }
    }
}
