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

		public virtual DbSet<Address> Addresses { get; set; }
		public virtual DbSet<Employee> Employees { get; set; }
		public virtual DbSet<Member> Members { get; set; }
		public virtual DbSet<PermissionsE> PermissionsEs { get; set; }
		public virtual DbSet<PermissionsM> PermissionsMs { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Employee>()
				.Property(e => e.Account)
				.IsUnicode(false);

			modelBuilder.Entity<Employee>()
				.Property(e => e.Password)
				.IsUnicode(false);

			modelBuilder.Entity<Member>()
				.Property(e => e.Account)
				.IsUnicode(false);

			modelBuilder.Entity<Member>()
				.Property(e => e.Password)
				.IsUnicode(false);

			modelBuilder.Entity<PermissionsE>()
				.HasMany(e => e.Employees)
				.WithRequired(e => e.PermissionsE)
				.HasForeignKey(e => e.Permission_id)
				.WillCascadeOnDelete(false);
		}
	}
}
