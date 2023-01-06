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
		public virtual DbSet<Elikes> Elikes { get; set; }
		public virtual DbSet<Employees> Employees { get; set; }
		public virtual DbSet<Essays> Essays { get; set; }
		public virtual DbSet<Essays_Comments> Essays_Comments { get; set; }
		public virtual DbSet<Essays_Tags> Essays_Tags { get; set; }
		public virtual DbSet<Images> Images { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Employees>()
				.Property(e => e.Account)
				.IsUnicode(false);

			modelBuilder.Entity<Employees>()
				.Property(e => e.EncryptedPassword)
				.IsUnicode(false);

			modelBuilder.Entity<Essays>()
				.HasMany(e => e.Eassy_Follows)
				.WithRequired(e => e.Essays)
				.HasForeignKey(e => e.Eassy_Id)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Essays>()
				.HasMany(e => e.Elikes)
				.WithRequired(e => e.Essays)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Essays>()
				.HasMany(e => e.Essays_Comments)
				.WithRequired(e => e.Essays)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Essays>()
				.HasMany(e => e.Essays_Tags)
				.WithRequired(e => e.Essays)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Essays>()
				.HasMany(e => e.Images)
				.WithMany(e => e.Essays)
				.Map(m => m.ToTable("Essays_Imgs").MapLeftKey("Essay_Id").MapRightKey("Img_Id"));

			modelBuilder.Entity<Essays_Comments>()
				.HasMany(e => e.EComments_Likes)
				.WithRequired(e => e.Essays_Comments)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Images>()
				.Property(e => e.Path)
				.IsUnicode(false);
		}
	}
}
