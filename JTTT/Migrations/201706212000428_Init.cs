namespace JTTT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JtttActions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JtttConditions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JtttTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Title = c.String(),
                        ActionId = c.Int(nullable: false),
                        ConditionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JtttActions", t => t.ActionId, cascadeDelete: true)
                .ForeignKey("dbo.JtttConditions", t => t.ConditionId, cascadeDelete: true)
                .Index(t => t.ActionId)
                .Index(t => t.ConditionId);
            
            CreateTable(
                "dbo.JtttActionEmail",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JtttActions", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.JtttConditionImgAlt",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Url = c.String(),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JtttConditions", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JtttConditionImgAlt", "Id", "dbo.JtttConditions");
            DropForeignKey("dbo.JtttActionEmail", "Id", "dbo.JtttActions");
            DropForeignKey("dbo.JtttTasks", "ConditionId", "dbo.JtttConditions");
            DropForeignKey("dbo.JtttTasks", "ActionId", "dbo.JtttActions");
            DropIndex("dbo.JtttConditionImgAlt", new[] { "Id" });
            DropIndex("dbo.JtttActionEmail", new[] { "Id" });
            DropIndex("dbo.JtttTasks", new[] { "ConditionId" });
            DropIndex("dbo.JtttTasks", new[] { "ActionId" });
            DropTable("dbo.JtttConditionImgAlt");
            DropTable("dbo.JtttActionEmail");
            DropTable("dbo.JtttTasks");
            DropTable("dbo.JtttConditions");
            DropTable("dbo.JtttActions");
        }
    }
}
