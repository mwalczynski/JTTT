namespace JTTT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTask : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JtttActions", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.JtttConditions", "City", c => c.String());
            AddColumn("dbo.JtttConditions", "Temperature", c => c.String());
            AddColumn("dbo.JtttConditions", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JtttConditions", "Discriminator");
            DropColumn("dbo.JtttConditions", "Temperature");
            DropColumn("dbo.JtttConditions", "City");
            DropColumn("dbo.JtttActions", "Discriminator");
        }
    }
}
