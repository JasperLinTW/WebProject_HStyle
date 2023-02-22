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

        public HActivityDTO FindActivityById(int? activityId)
        {
            if (activityId == null) throw new Exception("找不到此活動紀錄");

            var activity = _db.HActivities.SingleOrDefault(a => a.HActivityId == activityId);
            if (activity == null) { throw new Exception("找不到此活動紀錄"); }

            return activity.ToDTO();
        }

        public HCheckInDTO GetCheckInByMemberId(int memberId, int activityId_checkIn)
        {
            HCheckIn? checkIn = _db.HCheckIns.SingleOrDefault(c => c.MemberId == memberId);

            // 若沒有此會員的打卡紀錄，就新增一筆次數為0的打卡紀錄
            if (checkIn == null)
            {
                checkIn = new HCheckIn
                {
                    MemberId = memberId,
                    ActivityId = activityId_checkIn,
                    CheckInTimes = 0,
                    LastTime = DateTime.UtcNow,
                };
                _db.HCheckIns.Add(checkIn);
                _db.SaveChanges();
            }

            return checkIn.ToHCheckInDTO();
        }

        public void CreateHDetail(HSourceDetailDTO dto)
        {
            // 找出會員總Hcoin
            Member? member = _db.Members.SingleOrDefault(m => m.Id == dto.MemberId);
            if (member == null) throw new Exception("找不到此會員的紀錄");
            // 將活動的Coin加入會員的Total_H裡
            member.TotalH += dto.DifferenceH;
            _db.SaveChanges();

            HSourceDetail detail = new HSourceDetail
            {
                MemberId = dto.MemberId,
                ActivityId = dto.ActivityId,
                DifferenceH = dto.DifferenceH,
                EventTime = dto.EventTime,
                TotalHSoFar = member.TotalH + dto.DifferenceH,
            };
            _db.HSourceDetails.Add(detail);
            _db.SaveChanges();
        }

        public void EditCheckInById(int memberId, int checkInTimes)
        {
            // 找出原先紀錄
            HCheckIn? oldData = _db.HCheckIns.SingleOrDefault(c => c.MemberId == memberId);

            //// 移除舊紀錄
            //oldData = new HCheckIn
            //{
            //    CheckInTimes = checkInTimes,
            //    LastTime = DateTime.Now,
            //};
            //_db.HCheckIns.Remove(oldData);
            //_db.SaveChanges();

            // 新增最新一筆紀錄
            oldData = new HCheckIn
            {
                CheckInTimes = checkInTimes,
                LastTime = DateTime.Now,
            };
            _db.SaveChanges();
        }

    }
}
