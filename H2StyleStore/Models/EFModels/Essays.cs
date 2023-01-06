namespace H2StyleStore.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Essays
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Essays()
        {
            Eassy_Follows = new HashSet<Eassy_Follows>();
            Elikes = new HashSet<Elikes>();
            Essays_Comments = new HashSet<Essays_Comments>();
            Essays_Tags = new HashSet<Essays_Tags>();
            Images = new HashSet<Images>();
        }

        [Key]
        public int Essay_Id { get; set; }

        public int Influencer_Id { get; set; }

        public DateTime UplodTime { get; set; }

        [Required]
        [StringLength(1000)]
        public string ETitle { get; set; }

        [Required]
        [StringLength(1000)]
        public string EContent { get; set; }

		public bool? IsConfirmed { get; set; }

		public DateTime UpLoad { get; set; }

        public DateTime Removed { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Eassy_Follows> Eassy_Follows { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Elikes> Elikes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Essays_Comments> Essays_Comments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Essays_Tags> Essays_Tags { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Images> Images { get; set; }
    }
}
