namespace HcoinForBirth.EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order_Status
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Status_id { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }
    }
}
