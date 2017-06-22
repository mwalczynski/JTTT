namespace JTTT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedWillShow : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.JtttActions", "WillShow");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JtttActions", "WillShow", c => c.Boolean());
        }
    }
}
