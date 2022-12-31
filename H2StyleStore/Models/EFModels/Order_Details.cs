namespace H2StyleStore.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order_Details
    {
        [Key]
        public int Order_id { get; set; }

        public int Product_id { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal SubTotal { get; set; }

        public int Quantity { get; set; }

        public decimal? Discount { get; set; }
    }
}
