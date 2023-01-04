namespace H2StyleStore.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Member
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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
        [StringLength(50)]
        public string Password { get; set; }

        public int Phone_Number { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        public bool Gender { get; set; }

        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }

        public int? Permission_Id { get; set; }

        public DateTime Jointime { get; set; }

        public bool? Mail_verify { get; set; }

        [StringLength(100)]
        public string Mail_code { get; set; }

        public int Total_H { get; set; }
    }
}
