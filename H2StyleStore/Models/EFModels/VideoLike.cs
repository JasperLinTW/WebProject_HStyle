namespace H2StyleStore.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VideoLike
    {
        public int Id { get; set; }

        public int VideoId { get; set; }

        public int MemberId { get; set; }

        public DateTime CreatedTime { get; set; }

        public virtual Video Video { get; set; }
    }
}
