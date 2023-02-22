using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;
using HStyleApi.Models.InfraStructures.Repositories;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NuGet.Protocol.Core.Types;

namespace HStyleApi.Models.Services
{
    public class HCoinService
    {
        private HCoinRepository _hCoinRepo;

        public HCoinService(AppDbContext db)
        {
            _hCoinRepo = new HCoinRepository(db);
        }

        public async Task<HCheckInDTO> GetHCheckIn(int id, int activityId_checkIn)
        {
            return  _hCoinRepo.GetCheckInByMemberId(id, activityId_checkIn);
        }

        public string PutCheckInById(int memberId)
        {
            // 活動Id和項目
            int activityId_checkIn = 3;
            var activity = _hCoinRepo.FindActivityById(activityId_checkIn);

            // 找出member打卡紀錄
            var memberCheckIn = _hCoinRepo.GetCheckInByMemberId(memberId, activityId_checkIn);

            // 打卡次數加一
            var checkInTimes = memberCheckIn.CheckInTimes + 1;

            // 若打卡次數為七，則增加活動紀錄(Detail)，並將次數改為0
            if (checkInTimes < 0 || checkInTimes > 7)
            {
                return "打卡紀錄有錯誤";
            }
            else if (checkInTimes == 7)
            {
                HSourceDetailDTO model_Detail = new HSourceDetailDTO
                {
                    MemberId = memberId,
                    ActivityId = activityId_checkIn,
                    DifferenceH = activity.HValue,
                    EventTime = DateTime.Now,
                };
                _hCoinRepo.CreateHDetail(model_Detail);

                checkInTimes = 0;
            }

            // 修改打卡紀錄
            _hCoinRepo.EditCheckInById(memberId, checkInTimes);

            return "打卡成功";
        }

    }
}
