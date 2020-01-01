using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IT_Department_Store.Models
{
    public class Device
    {
        public int Id { get; set; }
        [DisplayName("الجهاز ID")]
        public string DeviceId { get; set; }
        [DisplayName("اسم الجهاز")]
        public string Name { get; set; }
        [DisplayName("نوع الجهاز")]
        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public virtual Type Type { get; set; }
        [DisplayName("مكان الجهاز")]
        public int PlaceId { get; set; }
        [ForeignKey("PlaceId")]
        public virtual Place Place { get; set; }
        [DisplayName("حالة الجهاز")]
        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public virtual DeviceStatus Status { get; set; }
        [DisplayName("المستلم")]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public bool IsDeleted { get; set; }
        public virtual List<MaintenanceOperation> MaintenanceOperations { get; set; }
        public virtual List<DeviceMovement> DeviceMovements { get; set; }
    }
}