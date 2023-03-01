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
            ECommentlikes = new HashSet<ECommentlike>();
            Members = new HashSet<Member>();
        }

        [Key]
        public int Comment_Id { get; set; }

        public int Member_Id { get; set; }

        public int Essay_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string EComment { get; set; }

        public DateTime ETime { get; set; }

        public int Elike { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ECommentlike> ECommentlikes { get; set; }

        public virtual Essay Essay { get; set; }

        public virtual Member Member { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Member> Members { get; set; }
    }
}
