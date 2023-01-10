using H2StyleStore.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2StyleStore.Models.Services.Interfaces
{
	public interface IH_Source_DetailRepository
	{
		/// <summary>
		/// 取得所有H幣活動資料
		/// </summary>
		/// <returns></returns>
		IEnumerable<H_Source_DetailDto> GetSource();

		/// <summary>
		/// 取得所有會員打卡資料
		/// </summary>
		/// <returns></returns>
		IEnumerable<H_CheckInDto> GetCheckIn();
	}
}
