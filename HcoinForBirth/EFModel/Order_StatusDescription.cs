namespace HcoinForBirth.EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order_StatusDescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Description_id { get; set; }

        public int? Status_id { get; set; }

        [StringLength(100)]
        public string Description { get; set; }
    }
}
