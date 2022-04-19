namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientEtFacture : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Factures",
                c => new
                    {
                        DateAchat = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ClientId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Prix = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.DateAchat, t.ClientId, t.ProductId })
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        CIN = c.Int(nullable: false, identity: true),
                        DateNaissance = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Mail = c.String(),
                        Nom = c.String(),
                        Prenom = c.String(),
                    })
                .PrimaryKey(t => t.CIN);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Factures", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Factures", "ClientId", "dbo.Clients");
            DropIndex("dbo.Factures", new[] { "ProductId" });
            DropIndex("dbo.Factures", new[] { "ClientId" });
            DropTable("dbo.Clients");
            DropTable("dbo.Factures");
        }
    }
}
