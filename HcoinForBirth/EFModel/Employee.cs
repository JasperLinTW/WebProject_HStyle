namespace HcoinForBirth.EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employee
    {
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
    }
}
