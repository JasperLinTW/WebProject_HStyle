using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;
using HStyleApi.Models.InfraStructures.Repositories;

namespace HStyleApi.Models.Services
{
    public class MemberServices
    {
        private  MemberRepositories _MemberRepositories;
        public MemberServices(AppDbContext db)
        {
            _MemberRepositories = new MemberRepositories(db);
        }
        public async Task<IEnumerable<MemberDTO>> GetMember()
        {
            var data = _MemberRepositories.GetMember();
            return await data;
        }

        public async Task<IEnumerable<MemberDTO>> GetMember(int id)
        {
            var data = _MemberRepositories.GetMember(id);
            return await data;
        }



    }
}
