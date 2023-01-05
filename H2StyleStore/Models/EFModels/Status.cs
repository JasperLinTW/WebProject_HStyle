using H2StyleStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace H2StyleStore.Models.EFModels
{
	public class Status
	{
		public Status()
		{
		    Orders = new HashSet<Order>();
		}
		public int Id { get; set; }
		public string status { get; set; }

		public virtual ICollection<Order> Orders { get; set; }

	}
}