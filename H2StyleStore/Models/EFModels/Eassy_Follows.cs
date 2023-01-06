namespace H2StyleStore.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Eassy_Follows
    {
        [Key]
        public int Member_Id { get; set; }

        public int Eassy_Id { get; set; }

        public DateTime FTime { get; set; }

        public virtual Essays Essays { get; set; }
    }
}
