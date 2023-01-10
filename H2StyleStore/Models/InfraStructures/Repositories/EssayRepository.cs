using H2StyleStore.Models.DTOs;
using H2StyleStore.Models.EFModels;
using H2StyleStore.Models.Services.Interfaces;
using H2StyleStore.Models.ViewModels;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace H2StyleStore.Models.Infrastructures.Repositories
{
	public class EssayRepository : IEssayRepository
	{
		private readonly AppDbContext _db;
		public EssayRepository(AppDbContext db)
		{
			_db = db;
		}

		public IEnumerable<EssayDTO> GetEssays()
		{
			IEnumerable<Essay> query = _db.Essays;
			//.Include("PCategory");

			query = query.OrderBy(x => x.Essay_Id);

			return query.Select(x => x.ToDto());
		}

		public IEnumerable<SelectListItem> GetCategories()
		{
			var data = _db.VideoCategories;


			foreach (var item in data)
			{
				yield return new SelectListItem { Value = item.Id.ToString(), Text = item.CategoryName };

			}

		}
		public bool IsExist(string etitle)
		{
			var essays = _db.Essays.SingleOrDefault(x => x.ETitle == etitle);
			return (essays != null);
		}

		private AppDbContext db = new AppDbContext();
		public void Create(EssayDTO dto)
		{
			int.TryParse(dto.VideoCategory, out int catgoryId);
			Essay essays = new Essay
			{
				Essay_Id = dto.Essay_Id,
				Influencer_Id = dto.Influencer_Id,
				UplodTime = dto.UplodTime,
				ETitle = dto.ETitle,
				EContent = dto.EContent,
				UpLoad = dto.UpLoad,
				Removed = dto.Removed,
				CategoryId = catgoryId,
			};

			_db.Essays.Add(essays);
			db.SaveChanges();
		}

		public void Create(CreateEssayDTO dto)
		{
			Essay essays = new Essay
			{
				Essay_Id = dto.Essay_Id,
				Influencer_Id = dto.Influencer_Id,
				UplodTime = dto.UplodTime,
				ETitle = dto.ETitle,
				EContent = dto.EContent,
				UpLoad = dto.UpLoad,
				Removed = dto.Removed,
				CategoryId = catgoryId,
			};
			_db.Essays.Add(essays);

			foreach (string tag in dto.tags)
			{
				var tags = _db.Tags.Select(x => x.TagName).ToList();
				if (tags.Contains(tag) == false)
				{
					Tag newTag = new Tag { TagName = tag };
					essays.Tags.Add(newTag);
				}
				else
				{
					Tag oldTag = _db.Tags.Where(x => x.TagName == tag).FirstOrDefault();
					essays.Tags.Add(oldTag);
				}
			}

			foreach (string path in dto.images)
			{
				Image image = new Image { Path = path, };
				essays.Images.Add(image);
			}

			_db.SaveChanges();
		}
	}
}