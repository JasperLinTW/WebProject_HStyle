namespace H2StyleStore.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product_Comments
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product_Comments()
        {
            PComments_Imgs = new HashSet<PComments_Imgs>();
        }

        [Key]
        public int Comment_id { get; set; }

        public int Order_id { get; set; }

        [Required]
        [StringLength(1000)]
        public string Comment_content { get; set; }

        public int Score { get; set; }

        public DateTime CreatedTime { get; set; }

        public virtual Order Order { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PComments_Imgs> PComments_Imgs { get; set; }
    }
}
