namespace Todo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialTodoModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TodoEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Description = c.String(),
                        StartDate = c.String(),
                        EndDate = c.String(),
                        IsCompleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TodoEntities");
        }
    }
}
