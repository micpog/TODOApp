namespace Todo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seeddata : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TodoEntities", newName: "Todoes");
            AlterColumn("dbo.Todoes", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Todoes", "EndDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Todoes", "EndDate", c => c.String());
            AlterColumn("dbo.Todoes", "StartDate", c => c.String());
            RenameTable(name: "dbo.Todoes", newName: "TodoEntities");
        }
    }
}
