using H2StyleStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace H2StyleStore.Models.DTOs
{
	public class CreateEssayDTO
	{
		public int Essay_Id { get; set; }

		public int Influencer_Id { get; set; }

		[Required]
		[StringLength(1000)]
		public string ETitle { get; set; }
		
		[Required]
		[StringLength(1000)]
		public string EContent { get; set; }

		public int CategoryId { get; set; }

		public DateTime UpLoad { get; set; }

		public DateTime Removed { get; set; }

		public string FilePath { get; set; }

		public List<string> Images { get;  set; }

		public List<string> Tags { get;  set; }
	}

}