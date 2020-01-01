namespace IT_Department_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNotesColumnToMaintenanceOperationsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MaintenanceOperations", "Notes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MaintenanceOperations", "Notes");
        }
    }
}
