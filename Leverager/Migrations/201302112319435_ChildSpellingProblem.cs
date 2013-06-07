namespace Leverager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChildSpellingProblem : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CategoryCategories", name: "ChieldId", newName: "ChildId");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.CategoryCategories", name: "ChildId", newName: "ChieldId");
        }
    }
}
