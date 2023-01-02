namespace H2StyleStore.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Photo")]
    public partial class Photo
    {
        [Key]
        public int Photo_Id { get; set; }

        [Required]
        [StringLength(1000)]
        public string Source { get; set; }

        [Required]
        [StringLength(50)]
        public string PName { get; set; }
    }
}
