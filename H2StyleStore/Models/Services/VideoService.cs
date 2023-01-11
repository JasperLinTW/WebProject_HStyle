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

        public (bool IsSuccess,string ErrorMessage) CreateVideo(CreateVideoDto dto)
        {
			if (_repository.IsExist(dto.Image,dto.FilePath))
			{
				return (false, "這部影片已經上傳過了");
			}

			_repository.CreateVideo(dto);
            return (true, null);
        }

		public void UpdateVideo(UpdateVideoDto request)
		{
            VideoDto entity = _repository.GetVideoById(request.Id);
            if (entity == null)
            {
                throw new Exception("找不到此影片");
            }

            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.CategoryId = request.CategoryId;
            entity.FilePath = request.FilePath;
            entity.OffShelffTime = request.OffShelffTime;
            entity.OnShelffTime = request.OnShelffTime;
            entity.CreatedTime = request.CreatedTime;
            //entity.Tags = request.Tags;
            //entity.Image = request.Image;

            _repository.Update(entity);
		}
	}
}