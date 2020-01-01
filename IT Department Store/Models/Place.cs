using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace IT_Department_Store.Models
{
    public class Place
    {
        public int Id { get; set; }
        [DisplayName("المكان")]
        public string Text { get; set; }
        public virtual List<Device> Devices { get; set; }
        public virtual List<DeviceMovement> DeviceMovements { get; set; }
    }
}