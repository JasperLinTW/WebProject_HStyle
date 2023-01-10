using H2StyleStore.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace H2StyleStore.Models.Services.Interfaces
{
	public interface IEssayRepository
	{
		IEnumerable<EssayDTO> GetEssays();

		bool IsExist(string ETiltle);
		void Create(EssayDTO essay);
		void Create(CreateEssayDTO essay);
		IEnumerable<SelectListItem> GetCategories();

		//EssayDTO Load(int memberId);
		//EssayDTO GetByAccount(string account);
		//void ActiveRegister(int memberId);

		//void Update(EssayDTO entity);

		//void UpdatePassword(int memberId, string newEncryptedPassword);
	}
}
