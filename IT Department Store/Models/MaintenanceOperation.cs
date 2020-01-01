using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IT_Department_Store.Models
{
    public class MaintenanceOperation
    {
        public int Id { get; set; }
        [DisplayName("وقت الاستلام")]
        public DateTime ReceiveTime { get; set; }
        [DisplayName("الحالة")]
        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public virtual MaintenanceStatus Status { get; set; }
        [DisplayName("المستلم")]
        public int RecevierId { get; set; }
        [ForeignKey("RecevierId")]
        public virtual User Recevier { get; set; }
        [DisplayName("الجهاز")]
        public int DeviceId { get; set; }
        [ForeignKey("DeviceId")]
        public virtual Device Device { get; set; }
        [DisplayName("ملاحظات")]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
        [DisplayName("العطل")]
        [DataType(DataType.MultilineText)]
        public string Problem { get; set; }
        [DisplayName("الإجراء")]
        [DataType(DataType.MultilineText)]
        public string Solution { get; set; }
        [DisplayName("المٌسَلِمّ")]
        public int? ExporterId { get; set; }
        [ForeignKey("ExporterId")]
        public virtual User Exporter { get; set; }
        [DisplayName("وقت الانتهاء")]
        public DateTime? EndTime { get; set; }
    }
}