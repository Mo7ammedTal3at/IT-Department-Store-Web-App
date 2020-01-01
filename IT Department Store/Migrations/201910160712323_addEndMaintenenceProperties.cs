namespace IT_Department_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEndMaintenenceProperties : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MaintenanceOperations", "UserId", "dbo.Users");
            DropIndex("dbo.MaintenanceOperations", new[] { "UserId" });
            RenameColumn(table: "dbo.MaintenanceOperations", name: "UserId", newName: "RecevierId");
            //AddColumn("dbo.MaintenanceOperations", "ReceiveTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.MaintenanceOperations", "User_Id", c => c.Int(nullable: true));
            AddColumn("dbo.MaintenanceOperations", "Solution", c => c.String());
            AddColumn("dbo.MaintenanceOperations", "ExporterId", c => c.Int());
            AddColumn("dbo.MaintenanceOperations", "EndTime", c => c.DateTime(nullable: true));
            AlterColumn("dbo.MaintenanceOperations", "RecevierId", c => c.Int());
            CreateIndex("dbo.MaintenanceOperations", "RecevierId");
            CreateIndex("dbo.MaintenanceOperations", "ExporterId");
            CreateIndex("dbo.MaintenanceOperations", "User_Id");
            AddForeignKey("dbo.MaintenanceOperations", "ExporterId", "dbo.Users", "Id");
            AddForeignKey("dbo.MaintenanceOperations", "RecevierId", "dbo.Users", "Id", cascadeDelete: false);
            AddForeignKey("dbo.MaintenanceOperations", "User_Id", "dbo.Users", "Id");
            //DropColumn("dbo.MaintenanceOperations", "Time");
            RenameColumn(table: "dbo.MaintenanceOperations", name: "Time", newName: "ReceiveTime");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.MaintenanceOperations", name: "ReceiveTime", newName: "Time");
            //AddColumn("dbo.MaintenanceOperations", "Time", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.MaintenanceOperations", "User_Id", "dbo.Users");
            DropForeignKey("dbo.MaintenanceOperations", "RecevierId", "dbo.Users");
            DropForeignKey("dbo.MaintenanceOperations", "ExporterId", "dbo.Users");
            DropIndex("dbo.MaintenanceOperations", new[] { "User_Id" });
            DropIndex("dbo.MaintenanceOperations", new[] { "ExporterId" });
            DropIndex("dbo.MaintenanceOperations", new[] { "RecevierId" });
            AlterColumn("dbo.MaintenanceOperations", "User_Id", c => c.Int(nullable: false));
            DropColumn("dbo.MaintenanceOperations", "EndTime");
            DropColumn("dbo.MaintenanceOperations", "ExporterId");
            DropColumn("dbo.MaintenanceOperations", "Solution");
            DropColumn("dbo.MaintenanceOperations", "RecevierId");
            DropColumn("dbo.MaintenanceOperations", "ReceiveTime");
            RenameColumn(table: "dbo.MaintenanceOperations", name: "User_Id", newName: "UserId");
            CreateIndex("dbo.MaintenanceOperations", "UserId");
            AddForeignKey("dbo.MaintenanceOperations", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
