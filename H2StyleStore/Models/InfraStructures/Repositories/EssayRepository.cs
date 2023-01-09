using H2StyleStore.Models.DTOs;
using H2StyleStore.Models.EFModels;
using H2StyleStore.Models.Services.Interfaces;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace H2StyleStore.Models.Infrastructures.Repositories
{
	public class EssayRepository : IEssayRepository
	{
		private AppDbContext db = new AppDbContext();
		public void Create(EssayDTO dto)
		{
			Essays essays = new Essays
			{
				Essay_Id = dto.Essay_Id,
				Influencer_Id = dto.Influencer_Id,
				UplodTime = dto.UplodTime,
				ETitle = dto.ETitle,
				EContent = dto.EContent,
				UpLoad = dto.UpLoad,
				IsConfirmed = false, //預設是未確認的會員
				Removed = dto.Removed,
			};

			db.Essays.Add(essays);
			db.SaveChanges();
		}
		private readonly AppDbContext _db;
		public EssayRepository(AppDbContext db)
		{
			_db = db;
		}

		public IEnumerable<EssayDTO> GetEssays()
		{
			IEnumerable<Essays> query = _db.Essays;
			//.Include("PCategory");

			query = query.OrderBy(x => x.Essay_Id);

			return query.Select(x => x.ToDto());
		}
		public bool IsExist(string etitle)
		{
			var entity = db.Essays.SingleOrDefault(x => x.ETitle == etitle);

			return (entity != null);
		}
		public void ActiveRegister(int Id)
		{
			var member = db.Essays.Find(Id);
			member.IsConfirmed = true;
			member.ConfirmCode = null;
			db.SaveChanges();
		}

		/// <summary>
		/// 更新記錄,本method不會更新密碼
		/// </summary>
		/// <param name="entity"></param>
		public void Update(EssayDTO entity)
		{
			Essays essays = db.Essays.Find(entity.Essay_Id);

			essays.Essay_Id = entity.Essay_Id;
			essays.Influencer_Id = entity.Influencer_Id;
			essays.UplodTime = entity.UplodTime;
			// 在忘記密碼時, 使用者請求重設密碼, 會叫用本method,所以以下二個屬性也要更新
			essays.ETitle = entity.ETitle;
			essays.EContent = entity.EContent;
			essays.UpLoad = entity.UpLoad;
			essays.Removed = entity.Removed; 

		

			db.SaveChanges();
		}

		public void UpdatePassword(int Id, string newEncryptedPassword)
		{
			var member = db.Essays.Find(Id);
		    
			db.SaveChanges();
		}
	}
}