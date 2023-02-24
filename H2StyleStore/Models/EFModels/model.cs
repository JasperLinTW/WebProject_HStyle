using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace H2StyleStore.Models.EFModels
{
	public partial class model : DbContext
	{
		public model()
			: base("name=model")
		{
		}

		public virtual DbSet<VCommentLike> VCommentLikes { get; set; }
		public virtual DbSet<VideoComment> VideoComments { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<VideoComment>()
				.HasMany(e => e.VCommentLikes)
				.WithRequired(e => e.VideoComment)
				.HasForeignKey(e => e.CommentId)
				.WillCascadeOnDelete(false);
		}
	}
}
