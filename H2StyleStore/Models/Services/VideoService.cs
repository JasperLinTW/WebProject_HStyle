using H2StyleStore.Models.DTOs;
using H2StyleStore.Models.EFModels;
using H2StyleStore.Models.Infrastructures.Repositories;
using H2StyleStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;

namespace H2StyleStore.Models.Services
{
    public class VideoService
    {
        private IVideoRepository _repository;
        public VideoService(IVideoRepository repository)
        {
            this._repository = repository;
        }

        public IEnumerable<VideoDto> GetVideos()
        {
            return _repository.GetVideos();
        }

        public void CreateVideo()
        {
            
        }
    }
}