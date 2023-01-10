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
		public virtual DbSet<Employee> Employees { get; set; }
		public virtual DbSet<Essay> Essays { get; set; }
		public virtual DbSet<Essays_Comments> Essays_Comments { get; set; }
		public virtual DbSet<Image> Images { get; set; }
		public virtual DbSet<Member> Members { get; set; }
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
				.HasMany(e => e.Essays_Comments)
				.WithRequired(e => e.Essay)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Essay>()
				.HasMany(e => e.Members)
				.WithMany(e => e.Essays)
				.Map(m => m.ToTable("Elikes").MapLeftKey("Essay_Id"));

			modelBuilder.Entity<Essay>()
				.HasMany(e => e.Images)
				.WithMany(e => e.Essays)
				.Map(m => m.ToTable("Essays_Imgs").MapLeftKey("Essay_Id").MapRightKey("Img_Id"));

			modelBuilder.Entity<Essay>()
				.HasMany(e => e.Tags)
				.WithMany(e => e.Essays)
				.Map(m => m.ToTable("Essays_Tags").MapLeftKey("Essay_Id"));

			modelBuilder.Entity<Essays_Comments>()
				.HasMany(e => e.Members)
				.WithMany(e => e.Essays_Comments1)
				.Map(m => m.ToTable("EComments_Likes").MapLeftKey("Comment_Id"));

			modelBuilder.Entity<Image>()
				.Property(e => e.Path)
				.IsUnicode(false);

			modelBuilder.Entity<Member>()
				.Property(e => e.Account)
				.IsUnicode(false);

			modelBuilder.Entity<Member>()
				.Property(e => e.Phone_Number)
				.IsUnicode(false);

			modelBuilder.Entity<Member>()
				.Property(e => e.EncryptedPassword)
				.IsUnicode(false);

			modelBuilder.Entity<Member>()
				.HasOptional(e => e.Eassy_Follows)
				.WithRequired(e => e.Member);

			modelBuilder.Entity<Member>()
				.HasMany(e => e.Essays_Comments)
				.WithRequired(e => e.Member)
				.HasForeignKey(e => e.Member_Id)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<VideoCategory>()
				.HasMany(e => e.Essays)
				.WithRequired(e => e.VideoCategory)
				.HasForeignKey(e => e.CategoryId)
				.WillCascadeOnDelete(false);
		}

		public System.Data.Entity.DbSet<H2StyleStore.Models.ViewModels.EssayVM> EssayVMs { get; set; }

        public System.Data.Entity.DbSet<H2StyleStore.Models.ViewModels.CreateEssayVM> CreateEssayVMs { get; set; }
    }
}
