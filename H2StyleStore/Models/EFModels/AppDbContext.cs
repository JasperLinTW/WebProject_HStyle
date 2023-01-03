using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace H2StyleStore.Models.EFModels
{
	public partial class AppDbContext : DbContext
	{
		public AppDbContext()
			: base("name=AppDbContext4")
		{
		}

		public virtual DbSet<Image> Images { get; set; }
		public virtual DbSet<PCategory> PCategories { get; set; }
		public virtual DbSet<Product> Products { get; set; }
		public virtual DbSet<Spec> Specs { get; set; }
		public virtual DbSet<Tag> Tags { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Image>()
				.Property(e => e.Path)
				.IsUnicode(false);

			modelBuilder.Entity<Image>()
				.HasMany(e => e.Products)
				.WithMany(e => e.Images)
				.Map(m => m.ToTable("Imgs_Products").MapLeftKey("Img_Id").MapRightKey("Product_Id"));

			modelBuilder.Entity<PCategory>()
				.HasMany(e => e.Products)
				.WithRequired(e => e.PCategory)
				.HasForeignKey(e => e.Category_Id)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Product>()
				.HasMany(e => e.Specs)
				.WithRequired(e => e.Product)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Product>()
				.HasMany(e => e.Tags)
				.WithMany(e => e.Products)
				.Map(m => m.ToTable("Tags_Products").MapLeftKey("Product_Id"));
		}
	}
}
