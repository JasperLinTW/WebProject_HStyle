namespace H2StyleStore.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Spec_details
    {
        public int Id { get; set; }

        public int Spec_Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Value { get; set; }

        public virtual Spec Spec { get; set; }
    }
}
