using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;
using HStyleApi.Models.InfraStructures.Repositories;

namespace HStyleApi.Models.Services
{
	public class HCoinService
	{
		private HCoinRepository _hCoinRepo;

		public HCoinService(AppDbContext db)
		{
			_hCoinRepo = new HCoinRepository(db);
		}

		public async Task<IEnumerable<HCheckInDTO>> GetHCheckIn(int id)
		{
			return await _hCoinRepo.GetHCheckIn(id);
		}
	}
}
