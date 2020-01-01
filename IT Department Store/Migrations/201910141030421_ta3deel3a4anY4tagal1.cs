namespace IT_Department_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ta3deel3a4anY4tagal1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.DeviceMovements", "User_Id", "dbo.Users");
            DropIndex("dbo.DeviceMovements", "Place_Id", "dbo.Places");
        }
        
        public override void Down()
        {
        }
    }
}
