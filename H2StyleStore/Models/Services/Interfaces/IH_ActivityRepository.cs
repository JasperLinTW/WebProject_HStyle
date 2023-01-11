using H2StyleStore.Models.DTOs;
using H2StyleStore.Models.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2StyleStore.Models.Services.Interfaces
{
	public interface IH_ActivityRepository
	{
		IEnumerable<H_ActivityDto> GetHActivity();

		void Create(H_ActivityDto dto);

		H_ActivityDto GetHActivityById(int id);

		void Update(H_ActivityDto dto);

		H_ActivityDto FindActivity(int? id);

		void DeleteActivity(int id);
	}
}
