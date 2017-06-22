namespace JTTT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTask2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.JtttConditions", "Temperature", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.JtttConditions", "Temperature", c => c.String());
        }
    }
}
