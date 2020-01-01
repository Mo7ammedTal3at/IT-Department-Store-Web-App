namespace IT_Department_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDeviceMovementsTableAndItsRelations : DbMigration
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
                        NewPlaceId = c.Int(nullable: false),
                        Time = c.DateTime(nullable: false),
                        SoldierId = c.Int(nullable: false),
                        RankerId = c.Int(nullable: false),
                        CommanderId = c.Int(nullable: false)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CommanderId, cascadeDelete: false)
                .ForeignKey("dbo.Devices", t => t.DeviceId, cascadeDelete: false)
                .ForeignKey("dbo.Places", t => t.NewPlaceId, cascadeDelete: false)
                .ForeignKey("dbo.Places", t => t.PreviousPlaceId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.RankerId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.SoldierId, cascadeDelete: false)
                .Index(t => t.DeviceId)
                .Index(t => t.PreviousPlaceId)
                .Index(t => t.NewPlaceId)
                .Index(t => t.SoldierId)
                .Index(t => t.RankerId)
                .Index(t => t.CommanderId);

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DeviceMovements", "SoldierId", "dbo.Users");
            DropForeignKey("dbo.DeviceMovements", "RankerId", "dbo.Users");
            DropForeignKey("dbo.DeviceMovements", "PreviousPlaceId", "dbo.Places");
            DropForeignKey("dbo.DeviceMovements", "NewPlaceId", "dbo.Places");
            DropForeignKey("dbo.DeviceMovements", "DeviceId", "dbo.Devices");
            DropForeignKey("dbo.DeviceMovements", "CommanderId", "dbo.Users");
            DropIndex("dbo.DeviceMovements", new[] { "CommanderId" });
            DropIndex("dbo.DeviceMovements", new[] { "RankerId" });
            DropIndex("dbo.DeviceMovements", new[] { "SoldierId" });
            DropIndex("dbo.DeviceMovements", new[] { "NewPlaceId" });
            DropIndex("dbo.DeviceMovements", new[] { "PreviousPlaceId" });
            DropIndex("dbo.DeviceMovements", new[] { "DeviceId" });
            DropTable("dbo.DeviceMovements");
        }
    }
}
