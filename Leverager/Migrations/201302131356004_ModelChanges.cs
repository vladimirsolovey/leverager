namespace Leverager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelChanges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SuggestProduct",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        SKU = c.String(maxLength: 128),
                        URL = c.String(maxLength: 128),
                        Comment = c.String(maxLength: 128),
                        StatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.StatusId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.SuggestProduct", new[] { "StatusId" });
            DropForeignKey("dbo.SuggestProduct", "StatusId", "dbo.Status");
            DropTable("dbo.SuggestProduct");
            DropTable("dbo.Status");
        }
    }
}
