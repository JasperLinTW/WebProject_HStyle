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

		public virtual DbSet<Order_Details> Order_Details { get; set; }
		public virtual DbSet<Order> Orders { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Order_Details>()
				.Property(e => e.UnitPrice)
				.HasPrecision(18, 0);

			modelBuilder.Entity<Order_Details>()
				.Property(e => e.SubTotal)
				.HasPrecision(18, 0);

			modelBuilder.Entity<Order_Details>()
				.Property(e => e.Discount)
				.HasPrecision(18, 0);
		}
	}
}
