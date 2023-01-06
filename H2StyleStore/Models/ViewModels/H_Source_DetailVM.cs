using H2StyleStore.Models.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace H2StyleStore.Models.ViewModels
{
	public class H_Source_DetailVM
	{
		[Key]
		public int Source_H_Id { get; set; }

		public int Member_Id { get; set; }

		public int Activity_Id { get; set; }

		public int Difference_H { get; set; }

		public DateTime Event_Time { get; set; }
	}
	public static class HSourceDetailExts
	{
		public static H_Source_DetailVM TovM(this H_Source_DetailDto source)
		{
			return new H_Source_DetailVM
			{
				Source_H_Id = source.Source_H_Id,
				Member_Id = source.Member_Id,
				Activity_Id = source.Activity_Id,
				Difference_H = source.Difference_H,
				Event_Time = source.Event_Time
			};
		}
	}
}