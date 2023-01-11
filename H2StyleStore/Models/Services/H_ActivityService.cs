using H2StyleStore.Models.DTOs;
using H2StyleStore.Models.EFModels;
using H2StyleStore.Models.Infrastructures.Repositories;
using H2StyleStore.Models.Services.Interfaces;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;

namespace H2StyleStore.Models.Services
{

	public class H_ActivityService
	{

		private readonly IH_ActivityRepository _repository;
		private IH_Source_DetailRepository _sourceDetailRepository;
		public H_ActivityService(IH_ActivityRepository repo)
		{
			AppDbContext db = new AppDbContext();
			_repository = repo;
			_sourceDetailRepository = new H_Source_DetailRepository(db);
		}

		public IEnumerable<H_ActivityDto> GetHActivity()
		{
			return _repository.GetHActivity();
		}

		public string CreateNewActivity(H_ActivityDto dto)
		{
			try
			{
				_repository.Create(dto);

				return "新增成功";
			}
			catch (Exception ex) { return ex.Message; }
		}

		public void UpdateActivity(H_ActivityDto dto)
		{
			H_ActivityDto entity = _repository.GetHActivityById(dto.H_Activity_Id);
			if (entity == null) throw new Exception("找不到要修改的紀錄");

			entity.Activity_Name = dto.Activity_Name;
			entity.Activity_Describe = dto.Activity_Describe;
			entity.H_Value = dto.H_Value;

			_repository.Update(entity);
		}

		/// <summary>
		/// 註冊送H幣
		/// </summary>
		/// <param name="id">會員Id</param>
		public void HcoinRegister(int id)
		{
			int activityId_register = 1;

			int difference_H = _repository.FindActivity(activityId_register).H_Value;

			H_Source_DetailDto model = new H_Source_DetailDto
			{
				Member_Id = id,
				Activity_Id = activityId_register,
				Difference_H = difference_H,
				Event_Time = DateTime.Now,
			};
			_sourceDetailRepository.CreateHDetail(model);
		}

		/// <summary>
		/// 購物fullPrice(滿額)送H幣
		/// </summary>
		/// <param name="id">會員Id</param>
		/// <param name="price">訂單總金額</param>
		public string HcoinOrderPrice(int id, int price)
		{
			int activityId_fullPrice = 4;
			int activityId_Hcoin = 5;
			int fullPrice = _repository.FindActivity(activityId_fullPrice).H_Value;
			int hCoin = _repository.FindActivity(activityId_Hcoin).H_Value;

			if (price < fullPrice) return null;

			H_Source_DetailDto model = new H_Source_DetailDto
			{
				Member_Id = id,
				Activity_Id = activityId_Hcoin,
				Difference_H = hCoin,
				Event_Time = DateTime.Now,
			};
			_sourceDetailRepository.CreateHDetail(model);

			return "購物滿額送H幣: " + hCoin.ToString();
		}

		/// <summary>
		/// 當月生日送H幣
		/// </summary>		
		public string HcoinBirthMonth()
		{
			// todo finish it

			int activityId_Birthday = 2;

			DateTime nowDay = DateTime.Today;

			// 當月1號發放 Hcoin
			if (nowDay.Day != 1) return null;

			var inBirth = _sourceDetailRepository.MemberInBirth(nowDay);

			return null;

		}

		/// <summary>
		/// 計算所有 H coin
		/// </summary>
		/// <param name="id"></param>
		public void TotalHcoin(int id)
		{
			// todo 要傳入Member資料表
			var detail = _sourceDetailRepository.GetTotalDetail(id);

			int total = 0;
			foreach (var item in detail)
			{
				total += item.Difference_H;
			}

			// _sourceDetailRepository.AddH_valueInMember(id, total);
		}

	}
}