namespace H2StyleStore.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PComments_Imgs
    {
        [Key]
        public int PComment_img_id { get; set; }

        public int Comment_id { get; set; }

        public virtual Product_Comments Product_Comments { get; set; }
    }
}
