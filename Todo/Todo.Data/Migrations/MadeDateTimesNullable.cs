namespace Todo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeDateTimesNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Todoes", "StartDate", c => c.DateTime());
            AlterColumn("dbo.Todoes", "EndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Todoes", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Todoes", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}
