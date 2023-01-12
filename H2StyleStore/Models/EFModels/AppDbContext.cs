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

		public virtual DbSet<Eassy_Follows> Eassy_Follows { get; set; }
		public virtual DbSet<EComments_Likes> EComments_Likes { get; set; }
		public virtual DbSet<Elike> Elikes { get; set; }
		public virtual DbSet<Employee> Employees { get; set; }
		public virtual DbSet<Essay> Essays { get; set; }
		public virtual DbSet<Essays_Comments> Essays_Comments { get; set; }
		public virtual DbSet<Image> Images { get; set; }
		public virtual DbSet<Tag> Tags { get; set; }
		public virtual DbSet<VideoCategory> VideoCategories { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Employee>()
				.Property(e => e.Account)
				.IsUnicode(false);

			modelBuilder.Entity<Employee>()
				.Property(e => e.EncryptedPassword)
				.IsUnicode(false);

			modelBuilder.Entity<Employee>()
				.HasMany(e => e.Essays)
				.WithRequired(e => e.Employee)
				.HasForeignKey(e => e.Influencer_Id)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Essay>()
				.HasMany(e => e.Eassy_Follows)
				.WithRequired(e => e.Essay)
				.HasForeignKey(e => e.Eassy_Id)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Essay>()
				.HasMany(e => e.Elikes)
				.WithRequired(e => e.Essay)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Essay>()
				.HasMany(e => e.Essays_Comments)
				.WithRequired(e => e.Essay)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Essay>()
				.HasMany(e => e.Images)
				.WithMany(e => e.Essays)
				.Map(m => m.ToTable("Essays_Imgs").MapLeftKey("Essay_Id").MapRightKey("Img_Id"));

			modelBuilder.Entity<Essay>()
				.HasMany(e => e.Tags)
				.WithMany(e => e.Essays)
				.Map(m => m.ToTable("Essays_Tags").MapLeftKey("Essay_Id"));

			modelBuilder.Entity<Essays_Comments>()
				.HasMany(e => e.EComments_Likes)
				.WithRequired(e => e.Essays_Comments)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Image>()
				.Property(e => e.Path)
				.IsUnicode(false);

			modelBuilder.Entity<VideoCategory>()
				.HasMany(e => e.Essays)
				.WithRequired(e => e.VideoCategory)
				.HasForeignKey(e => e.CategoryId)
				.WillCascadeOnDelete(false);
		}
	}
}
