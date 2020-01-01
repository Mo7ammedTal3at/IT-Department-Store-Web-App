namespace IT_Department_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDeviceMovementsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeviceMovements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeviceId = c.Int(nullable: false),
                        PreviousPlaceId = c.Int(nullable: false),
                        SoldierId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Devices", t => t.DeviceId, cascadeDelete: false)
                .ForeignKey("dbo.Places", t => t.PreviousPlaceId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.SoldierId, cascadeDelete: false)
                .Index(t => t.DeviceId)
                .Index(t => t.PreviousPlaceId)
                .Index(t => t.SoldierId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DeviceMovements", "SoldierId", "dbo.Users");
            DropForeignKey("dbo.DeviceMovements", "PreviousPlaceId", "dbo.Places");
            DropForeignKey("dbo.DeviceMovements", "DeviceId", "dbo.Devices");
            DropIndex("dbo.DeviceMovements", new[] { "SoldierId" });
            DropIndex("dbo.DeviceMovements", new[] { "PreviousPlaceId" });
            DropIndex("dbo.DeviceMovements", new[] { "DeviceId" });
            DropTable("dbo.DeviceMovements");
        }
    }
}
