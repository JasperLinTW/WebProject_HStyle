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

		public virtual DbSet<PCategory> PCategories { get; set; }
		public virtual DbSet<Photo> Photos { get; set; }
		public virtual DbSet<Product> Products { get; set; }
		public virtual DbSet<Spec> Specs { get; set; }
		public virtual DbSet<Spec_details> Spec_details { get; set; }
		public virtual DbSet<Tag> Tags { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
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

			modelBuilder.Entity<Spec>()
				.HasMany(e => e.Spec_details)
				.WithRequired(e => e.Spec)
				.HasForeignKey(e => e.Spec_Id)
				.WillCascadeOnDelete(false);
		}
	}
}
