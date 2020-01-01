using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace IT_Department_Store.Models
{
    public class Daraga
    {
        public int Id { get; set; }
        [DisplayName("الدرجة")]
        public string Name { get; set; }
        public virtual List<User> Users { get; set; }
    }
}