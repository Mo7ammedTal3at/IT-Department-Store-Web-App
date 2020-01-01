using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace IT_Department_Store.Models
{
    public class DeviceStatus
    {
        public int Id { get; set; }
        [DisplayName("الحالة")]
        public string Text { get; set; }
        public virtual List<Device> Devices { get; set; }

    }
}