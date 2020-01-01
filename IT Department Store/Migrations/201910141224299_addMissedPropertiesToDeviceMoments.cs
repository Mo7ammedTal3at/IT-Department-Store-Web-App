namespace IT_Department_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMissedPropertiesToDeviceMoments : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DeviceMovements", "SoldierId", "dbo.Users");
            AddColumn("dbo.DeviceMovements", "RankerId", c => c.Int(nullable: false));
            AddColumn("dbo.DeviceMovements", "CommanderId", c => c.Int(nullable: false));
            AddColumn("dbo.DeviceMovements", "Time", c => c.DateTime(nullable: false));
            AddColumn("dbo.DeviceMovements", "Notes", c => c.String());
            AddColumn("dbo.DeviceMovements", "User_Id", c => c.Int());
            CreateIndex("dbo.DeviceMovements", "RankerId");
            CreateIndex("dbo.DeviceMovements", "CommanderId");
            CreateIndex("dbo.DeviceMovements", "User_Id");
            AddForeignKey("dbo.DeviceMovements", "CommanderId", "dbo.Users", "Id", cascadeDelete: false);
            AddForeignKey("dbo.DeviceMovements", "RankerId", "dbo.Users", "Id", cascadeDelete: false);
            AddForeignKey("dbo.DeviceMovements", "User_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DeviceMovements", "User_Id", "dbo.Users");
            DropForeignKey("dbo.DeviceMovements", "RankerId", "dbo.Users");
            DropForeignKey("dbo.DeviceMovements", "CommanderId", "dbo.Users");
            DropIndex("dbo.DeviceMovements", new[] { "User_Id" });
            DropIndex("dbo.DeviceMovements", new[] { "CommanderId" });
            DropIndex("dbo.DeviceMovements", new[] { "RankerId" });
            DropColumn("dbo.DeviceMovements", "User_Id");
            DropColumn("dbo.DeviceMovements", "Notes");
            DropColumn("dbo.DeviceMovements", "Time");
            DropColumn("dbo.DeviceMovements", "CommanderId");
            DropColumn("dbo.DeviceMovements", "RankerId");
            AddForeignKey("dbo.DeviceMovements", "SoldierId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
