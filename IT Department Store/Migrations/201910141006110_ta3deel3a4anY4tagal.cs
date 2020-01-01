namespace IT_Department_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ta3deel3a4anY4tagal : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DeviceMovements", "User_Id","dbo.Users");
            DropForeignKey("dbo.DeviceMovements", "Place_Id", "dbo.Places");
        }
        
        public override void Down()
        {
            
            
        }
    }
}
