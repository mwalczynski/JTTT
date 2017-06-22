namespace JTTT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WillShow : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JtttActions", "WillShow", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JtttActions", "WillShow");
        }
    }
}
