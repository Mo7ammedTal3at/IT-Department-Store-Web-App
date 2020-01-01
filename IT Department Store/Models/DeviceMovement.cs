using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IT_Department_Store.Models
{
    public class DeviceMovement
    {
        public int Id { get; set; }
        [DisplayName("اسم الجهاز")]
        public int DeviceId { get; set; }
        [ForeignKey("DeviceId")]
        public virtual Device Device { get; set; }
        [DisplayName("المكان السابق")]
        public int PreviousPlaceId { get; set; }
        [ForeignKey("PreviousPlaceId")]
        public virtual Place PreviousPlace { get; set; }
        [DisplayName("المكان الجديد")]
        public int NewPlaceId { get; set; }
        [ForeignKey("NewPlaceId")]
        public virtual Place NewPlace { get; set; }
        [DisplayName("اسم الجندى")]
        public int SoldierId { get; set; }
        [ForeignKey("SoldierId")]
        public virtual User Soldier { get; set; }
        [DisplayName("ضابط صف")]
        public int RankerId { get; set; }
        [ForeignKey("RankerId")]
        public virtual User Ranker { get; set; }
        [DisplayName("الضابط")]
        public int CommanderId { get; set; }
        [ForeignKey("CommanderId")]
        public virtual User Commander { get; set; }
        [DisplayName("التاريخ")]
        [DataType(DataType.DateTime)]
        public DateTime Time { get; set; }
        [DisplayName("ملاحظات")]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
    }
}