namespace IT_Department_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNewPlaceColumnToDeviceMovementsTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DeviceMovements", "PreviousPlaceId", "dbo.Places");
            AddColumn("dbo.DeviceMovements", "NewPlaceId", c => c.Int(nullable: false));
            AddColumn("dbo.DeviceMovements", "Place_Id", c => c.Int());
            CreateIndex("dbo.DeviceMovements", "NewPlaceId");
            CreateIndex("dbo.DeviceMovements", "Place_Id");
            AddForeignKey("dbo.DeviceMovements", "NewPlaceId", "dbo.Places", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DeviceMovements", "Place_Id", "dbo.Places", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DeviceMovements", "Place_Id", "dbo.Places");
            DropForeignKey("dbo.DeviceMovements", "NewPlaceId", "dbo.Places");
            DropIndex("dbo.DeviceMovements", new[] { "Place_Id" });
            DropIndex("dbo.DeviceMovements", new[] { "NewPlaceId" });
            DropColumn("dbo.DeviceMovements", "Place_Id");
            DropColumn("dbo.DeviceMovements", "NewPlaceId");
            AddForeignKey("dbo.DeviceMovements", "PreviousPlaceId", "dbo.Places", "Id", cascadeDelete: true);
        }
    }
}
