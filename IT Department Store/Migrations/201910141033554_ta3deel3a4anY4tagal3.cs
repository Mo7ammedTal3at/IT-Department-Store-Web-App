namespace IT_Department_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ta3deel3a4anY4tagal3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DeviceMovements", "User_Id", "dbo.Users");
            DropForeignKey("dbo.DeviceMovements", "Place_Id", "dbo.Places");
            DropIndex("dbo.DeviceMovements", new[] { "Place_Id" });
            DropIndex("dbo.DeviceMovements", new[] { "User_Id" });
            AddColumn("dbo.DeviceMovements", "Place_Id", c => c.Int());
            AddColumn("dbo.DeviceMovements", "User_Id", c => c.Int());
           
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DeviceMovements", "Place_Id", "dbo.Places");
            DropForeignKey("dbo.DeviceMovements", "User_Id", "dbo.Users");
            DropIndex("dbo.DeviceMovements", new[] { "User_Id1" });
            DropIndex("dbo.DeviceMovements", new[] { "Place_Id1" });
            DropColumn("dbo.DeviceMovements", "User_Id1");
            DropColumn("dbo.DeviceMovements", "Place_Id1");
            
        }
    }
}
