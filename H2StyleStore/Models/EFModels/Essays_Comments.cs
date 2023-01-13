namespace H2StyleStore.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Essays_Comments
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Essays_Comments()
        {
            Members = new HashSet<Member>();
        }

        [Key]
        public int Comment_Id { get; set; }

        public int Member_Id { get; set; }

        public int Essay_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string CComment { get; set; }

        public DateTime CTime { get; set; }

        public virtual Essay Essay { get; set; }

        public virtual Member Member { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Member> Members { get; set; }
    }
}
