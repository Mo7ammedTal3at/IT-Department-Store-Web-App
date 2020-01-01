using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace IT_Department_Store.Models
{
    public class MaintenanceStatus
    {
        public int Id { get; set; }
        [DisplayName("الحالة")]
        public string Text { get; set; }
        public virtual List<MaintenanceOperation> MaintenanceOperations { get; set; }

    }
}