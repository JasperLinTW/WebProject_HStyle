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
        public async Task<IEnumerable<MemberDTO>> GetVideos()
        {
            var data = _videoRepository.GetVideos();
            return await data;
        }

        public async Task<IEnumerable<VideoDTO>> GetVideo(int id)
        {
            var data = _videoRepository.GetVideo(id);
            return await data;
        }



    }
}
