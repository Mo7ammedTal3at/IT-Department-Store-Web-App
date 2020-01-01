using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IT_Department_Store.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext():base("DefaultConnection")
        {
            
        }
        public DbSet<Place> Places { get; set; }
        public DbSet<Daraga> Daragat { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<MaintenanceStatus> MaintenanceStatuses { get; set; }
        public DbSet<DeviceStatus> DeviceStatuses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<MaintenanceOperation> MaintenanceOperations { get; set; }

        public System.Data.Entity.DbSet<IT_Department_Store.Models.DeviceMovement> DeviceMovements { get; set; }
    }
}