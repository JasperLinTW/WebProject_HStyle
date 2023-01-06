namespace H2StyleStore.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [Key]
        public int Order_id { get; set; }

        public int Member_id { get; set; }

        public int Employee_id { get; set; }

        public int Total { get; set; }

        public int Payment { get; set; }

        public DateTime? ShippedDate { get; set; }

        [Required]
        [StringLength(50)]
        public string ShipVia { get; set; }

        public int Freight { get; set; }

        [Required]
        [StringLength(10)]
        public string ShipName { get; set; }

        [Required]
        [StringLength(60)]
        public string ShipAddress { get; set; }

        [Required]
        [StringLength(10)]
        public string ShipPhone { get; set; }

        public DateTime? RequestRefundTime { get; set; }

        public bool RequestRefund { get; set; }

        public DateTime CreatedTime { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }
    }
}
