using H2StyleStore.Models.DTOs;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace H2StyleStore.Models.ViewModels
{
	public class H_ActivityVM
	{
		[Key]
		public int H_Activity_Id { get; set; }

		[Required]
		[StringLength(50)]
		public string Activity_Name { get; set; }

		[Required]
		public string Activity_Describe { get; set; }

		public int H_Value { get; set; }
	}

	public static class H_ActiviyDtoExts
	{
		public static H_ActivityVM ToVM(this H_ActivityDto dto)
		{
			return new H_ActivityVM
			{
				H_Activity_Id = dto.H_Activity_Id,
				Activity_Name = dto.Activity_Name,
				Activity_Describe = dto.Activity_Describe,
				H_Value = dto.H_Value
			};
		}
	}
}