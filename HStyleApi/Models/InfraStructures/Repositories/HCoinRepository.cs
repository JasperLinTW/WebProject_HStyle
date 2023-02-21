using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;
using Microsoft.EntityFrameworkCore;

namespace HStyleApi.Models.InfraStructures.Repositories
{
	public class HCoinRepository
	{
		private AppDbContext _db;
		public HCoinRepository(AppDbContext db) { _db = db; }

		public async Task<IEnumerable<HCheckInDTO>> GetHCheckIn(int id)
		{
			var data = await _db.HCheckIns.Where(c => c.MemberId == id)
				.Select(c => c.ToHCheckInDTO()).ToListAsync();

			if (data == null)
			{
				throw new Exception();
			}

			return data;
		}
	}
}
