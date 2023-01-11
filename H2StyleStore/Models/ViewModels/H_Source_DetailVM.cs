using H2StyleStore.Models.DTOs;
using H2StyleStore.Models.EFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace H2StyleStore.Models.ViewModels
{
	public class H_Source_DetailVM
	{
		[Key]
		public int Source_H_Id { get; set; }

		[DisplayName("會員")]
		public string Member_Name { get; set; }

		[DisplayName("活動名稱")]
		public string H_Activity_Name { get; set; }

		[DisplayName("H幣值")]
		public int Difference_H { get; set; }

		[DisplayName("取得時間")]
		public DateTime Event_Time { get; set; }		

	}
	public static class HSourceDetailExts
	{
		public static H_Source_DetailVM ToVM(this H_Source_DetailDto source)
		{
			return new H_Source_DetailVM
			{
				Source_H_Id = source.Source_H_Id,
				Member_Name = source.Member_Name,
				//Member_Id = source.Member_Id,
				//Activity_Id = source.Activity_Id,
				H_Activity_Name = source.H_Activity_Name,
				Difference_H = source.Difference_H,
				Event_Time = source.Event_Time,

			};
		}
	}
}