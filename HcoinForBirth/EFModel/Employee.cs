namespace HcoinForBirth.EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        public int Employee_id { get; set; }

        [Required]
        [StringLength(50)]
        public string Account { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        public int? Permission_id { get; set; }

        [StringLength(100)]
        public string EncryptedPassword { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
