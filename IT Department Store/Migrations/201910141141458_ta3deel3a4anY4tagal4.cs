namespace IT_Department_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ta3deel3a4anY4tagal4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DeviceMovements", "CommanderId", "dbo.Users");
            DropForeignKey("dbo.DeviceMovements", "DeviceId", "dbo.Devices");
            DropForeignKey("dbo.DeviceMovements", "Place_Id1", "dbo.Places");
            DropForeignKey("dbo.DeviceMovements", "NewPlaceId", "dbo.Places");
            DropForeignKey("dbo.DeviceMovements", "PreviousPlaceId", "dbo.Places");
            DropForeignKey("dbo.DeviceMovements", "RankerId", "dbo.Users");
            DropForeignKey("dbo.DeviceMovements", "SoldierId", "dbo.Users");
            DropForeignKey("dbo.DeviceMovements", "User_Id1", "dbo.Users");
            DropIndex("dbo.DeviceMovements", new[] { "DeviceId" });
            DropIndex("dbo.DeviceMovements", new[] { "PreviousPlaceId" });
            DropIndex("dbo.DeviceMovements", new[] { "NewPlaceId" });
            DropIndex("dbo.DeviceMovements", new[] { "SoldierId" });
            DropIndex("dbo.DeviceMovements", new[] { "RankerId" });
            DropIndex("dbo.DeviceMovements", new[] { "CommanderId" });
            DropIndex("dbo.DeviceMovements", new[] { "Place_Id1" });
            DropIndex("dbo.DeviceMovements", new[] { "User_Id1" });
            DropTable("dbo.DeviceMovements");
        }
        
        public override void Down()
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
                        CommanderId = c.Int(nullable: false),
                        User_Id = c.Int(),
                        Place_Id = c.Int(),
                        Place_Id1 = c.Int(),
                        User_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.DeviceMovements", "User_Id1");
            CreateIndex("dbo.DeviceMovements", "Place_Id1");
            CreateIndex("dbo.DeviceMovements", "CommanderId");
            CreateIndex("dbo.DeviceMovements", "RankerId");
            CreateIndex("dbo.DeviceMovements", "SoldierId");
            CreateIndex("dbo.DeviceMovements", "NewPlaceId");
            CreateIndex("dbo.DeviceMovements", "PreviousPlaceId");
            CreateIndex("dbo.DeviceMovements", "DeviceId");
            AddForeignKey("dbo.DeviceMovements", "User_Id1", "dbo.Users", "Id");
            AddForeignKey("dbo.DeviceMovements", "SoldierId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DeviceMovements", "RankerId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DeviceMovements", "PreviousPlaceId", "dbo.Places", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DeviceMovements", "NewPlaceId", "dbo.Places", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DeviceMovements", "Place_Id1", "dbo.Places", "Id");
            AddForeignKey("dbo.DeviceMovements", "DeviceId", "dbo.Devices", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DeviceMovements", "CommanderId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
