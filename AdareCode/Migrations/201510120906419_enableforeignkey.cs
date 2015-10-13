namespace AdareCode.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enableforeignkey : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.AdareShow", "EventTypeId", "dbo.EventType", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Client", "FaxShowId", "dbo.AdareShow", "Id");
            AddForeignKey("dbo.Client", "EmailShowId", "dbo.AdareShow", "Id");
            AddForeignKey("dbo.Client", "PrintShowId", "dbo.AdareShow", "Id");
            CreateIndex("dbo.AdareShow", "EventTypeId");
            CreateIndex("dbo.Client", "FaxShowId");
            CreateIndex("dbo.Client", "EmailShowId");
            CreateIndex("dbo.Client", "PrintShowId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Client", new[] { "PrintShowId" });
            DropIndex("dbo.Client", new[] { "EmailShowId" });
            DropIndex("dbo.Client", new[] { "FaxShowId" });
            DropIndex("dbo.AdareShow", new[] { "EventTypeId" });
            DropForeignKey("dbo.Client", "PrintShowId", "dbo.AdareShow");
            DropForeignKey("dbo.Client", "EmailShowId", "dbo.AdareShow");
            DropForeignKey("dbo.Client", "FaxShowId", "dbo.AdareShow");
            DropForeignKey("dbo.AdareShow", "EventTypeId", "dbo.EventType");
        }
    }
}
