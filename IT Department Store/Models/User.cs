using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace IT_Department_Store.Models
{
    public class User
    {
        public int Id { get; set; }
        [DisplayName("الاسم")]
        public string Name { get; set; }
        public bool IsDeleted { get; set; } = false;
        [DisplayName("الدرجة")]
        public int DaragaId { get; set; }
        public virtual Daraga Daraga { get; set; }
        public virtual List<MaintenanceOperation> MaintenanceOperations { get; set; }
        public virtual List<Device> Devices { get; set; }
        public virtual List<DeviceMovement> DeviceMovements { get; set; }
    }
}