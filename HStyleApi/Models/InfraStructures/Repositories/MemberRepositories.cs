using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;
using Microsoft.EntityFrameworkCore;

namespace HStyleApi.Models.InfraStructures.Repositories
{
    public class MemberRepositories
    {
        private readonly AppDbContext _db;
        public MemberRepositories(AppDbContext db)
        {
            _db = db;
        }
        public IEnumerable<MemberDTO> ListMember()  //測試Get
        {
            IEnumerable<Member> data = _db.Members
                                        .Include(Members => Members.Id)
                                        .Include(Members => Members.Name)
                                        .Include(Members => Members.Account)
                                        .Include(Members => Members.Birthday);

            var members = data.OrderBy(x => x.DisplayOrder).Select(x => x.ToDto());

            return products;
        }



    }
}
