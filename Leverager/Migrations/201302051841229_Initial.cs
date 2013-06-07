namespace Leverager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128),
                        Root = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CategoryCategories",
                c => new
                    {
                        ParentId = c.Int(nullable: false),
                        ChieldId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ParentId, t.ChieldId })
                .ForeignKey("dbo.Category", t => t.ParentId)
                .ForeignKey("dbo.Category", t => t.ChieldId)
                .Index(t => t.ParentId)
                .Index(t => t.ChieldId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.CategoryCategories", new[] { "ChieldId" });
            DropIndex("dbo.CategoryCategories", new[] { "ParentId" });
            DropForeignKey("dbo.CategoryCategories", "ChieldId", "dbo.Category");
            DropForeignKey("dbo.CategoryCategories", "ParentId", "dbo.Category");
            DropTable("dbo.CategoryCategories");
            DropTable("dbo.Category");
        }
    }
}
