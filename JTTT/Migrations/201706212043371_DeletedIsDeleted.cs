namespace JTTT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedIsDeleted : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.JtttActions", "IsDeleted");
            DropColumn("dbo.JtttConditions", "IsDeleted");
            DropColumn("dbo.JtttTasks", "IsDeleted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JtttTasks", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.JtttConditions", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.JtttActions", "IsDeleted", c => c.Boolean(nullable: false));
        }
    }
}
