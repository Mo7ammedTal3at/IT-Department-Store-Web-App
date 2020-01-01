namespace IT_Department_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Daragas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DaragaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Daragas", t => t.DaragaId, cascadeDelete: true)
                .Index(t => t.DaragaId);
            
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeviceId = c.String(),
                        Name = c.String(),
                        TypeId = c.Int(nullable: false),
                        PlaceId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Places", t => t.PlaceId, cascadeDelete: true)
                .ForeignKey("dbo.DeviceStatus", t => t.StatusId, cascadeDelete: true)
                .ForeignKey("dbo.Types", t => t.TypeId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.TypeId)
                .Index(t => t.PlaceId)
                .Index(t => t.StatusId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.MaintenanceOperations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                        StatusId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        DeviceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Devices", t => t.DeviceId, cascadeDelete: true)
                .ForeignKey("dbo.MaintenanceStatus", t => t.StatusId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.StatusId)
                .Index(t => t.UserId)
                .Index(t => t.DeviceId);
            
            CreateTable(
                "dbo.MaintenanceStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DeviceStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Devices", "UserId", "dbo.Users");
            DropForeignKey("dbo.Devices", "TypeId", "dbo.Types");
            DropForeignKey("dbo.Devices", "StatusId", "dbo.DeviceStatus");
            DropForeignKey("dbo.Devices", "PlaceId", "dbo.Places");
            DropForeignKey("dbo.MaintenanceOperations", "UserId", "dbo.Users");
            DropForeignKey("dbo.MaintenanceOperations", "StatusId", "dbo.MaintenanceStatus");
            DropForeignKey("dbo.MaintenanceOperations", "DeviceId", "dbo.Devices");
            DropForeignKey("dbo.Users", "DaragaId", "dbo.Daragas");
            DropIndex("dbo.MaintenanceOperations", new[] { "DeviceId" });
            DropIndex("dbo.MaintenanceOperations", new[] { "UserId" });
            DropIndex("dbo.MaintenanceOperations", new[] { "StatusId" });
            DropIndex("dbo.Devices", new[] { "UserId" });
            DropIndex("dbo.Devices", new[] { "StatusId" });
            DropIndex("dbo.Devices", new[] { "PlaceId" });
            DropIndex("dbo.Devices", new[] { "TypeId" });
            DropIndex("dbo.Users", new[] { "DaragaId" });
            DropTable("dbo.Types");
            DropTable("dbo.DeviceStatus");
            DropTable("dbo.Places");
            DropTable("dbo.MaintenanceStatus");
            DropTable("dbo.MaintenanceOperations");
            DropTable("dbo.Devices");
            DropTable("dbo.Users");
            DropTable("dbo.Daragas");
        }
    }
}
