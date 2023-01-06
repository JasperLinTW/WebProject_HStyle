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
		/// 取得所有資料
		/// </summary>
		/// <returns></returns>
		IEnumerable<H_Source_DetailDto> GetSource();
	}
}
