using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace H2StyleStore.Models.EFModels
{
	public partial class AppDbContext : DbContext
	{
		public AppDbContext()
			: base("name=AppDbConn")
		{
		}

		public virtual DbSet<H_Activities> H_Activities { get; set; }
		public virtual DbSet<H_CheckIns> H_CheckIns { get; set; }
		public virtual DbSet<H_Source_Details> H_Source_Details { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<H_Activities>()
				.HasOptional(e => e.H_CheckIns)
				.WithRequired(e => e.H_Activities);

			modelBuilder.Entity<H_Activities>()
				.HasMany(e => e.H_Source_Details)
				.WithRequired(e => e.H_Activities)
				.HasForeignKey(e => e.Activity_Id)
				.WillCascadeOnDelete(false);
		}

        public System.Data.Entity.DbSet<H2StyleStore.Models.ViewModels.H_Source_DetailVM> H_Source_DetailVM { get; set; }
    }
}
