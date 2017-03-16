namespace WebCreateQR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AttendEvent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AttendEvent",
                c => new
                    {
                        memberId = c.Int(nullable: false, identity: true),
                        EventId = c.Int(nullable: false),
                        email = c.String(),
                        ticketCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.memberId, t.EventId })
                .ForeignKey("dbo.Event", t => t.EventId, cascadeDelete: true)
                .Index(t => t.EventId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AttendEvent", "EventId", "dbo.Event");
            DropIndex("dbo.AttendEvent", new[] { "EventId" });
            DropTable("dbo.AttendEvent");
        }
    }
}
