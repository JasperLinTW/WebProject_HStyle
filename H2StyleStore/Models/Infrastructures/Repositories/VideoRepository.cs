using H2StyleStore.Models.DTOs;
using H2StyleStore.Models.EFModels;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace H2StyleStore.Models.Infrastructures.Repositories
{
    public class VideoRepository : IVideoRepository
    {
       private readonly AppDbContext _db;

        public VideoRepository(AppDbContext db)
        {
            _db=db;
        }
        public IEnumerable<VideoDto> GetVideos()
        {
            IEnumerable<Video> query = _db.Videos;
            return query.Select(v => v.ToDto());
        }
    }
}