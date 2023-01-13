namespace H2StyleStore.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Member
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Member()
        {
            Addresses = new HashSet<Address>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Account { get; set; }

        [Required]
        [StringLength(10)]
        public string Phone_Number { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        public bool Gender { get; set; }

        [Column(TypeName = "datetime")]  //§â2§R±¼¤F
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd HH:mm:ss}",ApplyFormatInEditMode =true)]
        public DateTime Birthday { get; set; }

        public int? Permission_Id { get; set; }

		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
		public DateTime Jointime { get; set; }

        public bool? Mail_verify { get; set; }

        [StringLength(100)]
        public string Mail_code { get; set; }

        public int? Total_H { get; set; }

        [StringLength(100)]
        public string EncryptedPassword { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Address> Addresses { get; set; }

        public virtual PermissionsM PermissionsM { get; set; }
    }
}
