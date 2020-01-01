namespace IT_Department_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeEndTimeColumnToNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MaintenanceOperations", "EndTime", c => c.DateTime(nullable:true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MaintenanceOperations", "EndTime", c => c.DateTime());
        }
    }
}
