using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace H2StyleStore.Models.EFModels
{
	public partial class AppDbContext : DbContext
	{
		public AppDbContext()
			: base("name=AppDbContext")
		{
		}

		public virtual DbSet<Image> Images { get; set; }
		public virtual DbSet<Tag> Tags { get; set; }
		public virtual DbSet<VideoCategory> VideoCategories { get; set; }
		public virtual DbSet<Video> Videos { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Image>()
				.Property(e => e.Path)
				.IsUnicode(false);

			modelBuilder.Entity<Image>()
				.HasMany(e => e.Videos)
				.WithRequired(e => e.Image)
				.HasForeignKey(e => e.ImageId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Tag>()
				.HasMany(e => e.Videos)
				.WithMany(e => e.Tags)
				.Map(m => m.ToTable("Tags_Video").MapLeftKey("TagId").MapRightKey("VideoId"));

			modelBuilder.Entity<VideoCategory>()
				.HasMany(e => e.Videos)
				.WithRequired(e => e.VideoCategory)
				.HasForeignKey(e => e.CategoryId)
				.WillCascadeOnDelete(false);
		}

		public System.Data.Entity.DbSet<H2StyleStore.Models.DTOs.VideoDto> VideoDtoes { get; set; }

		public System.Data.Entity.DbSet<H2StyleStore.Models.ViewModels.VideoVM> VideoVMs { get; set; }

		public System.Data.Entity.DbSet<H2StyleStore.Models.ViewModels.CreateVideoVM> CreateVideoVMs { get; set; }
	}
}
