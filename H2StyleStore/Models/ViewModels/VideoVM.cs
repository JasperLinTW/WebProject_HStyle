using H2StyleStore.Models.DTOs;
using H2StyleStore.Models.EFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace H2StyleStore.Models.ViewModels
{
    public class VideoVM
    {
        public int Id { get; set; }

        public virtual Image Image { get; set; }

        [Display(Name ="影片名稱")]
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Display(Name = "影片說明")]
        [StringLength(200)]
        public string Description { get; set; }

        //[Required]
        //[StringLength(100)]
        //public string FilePath { get; set; }

        //public int CategoryId { get; set; }

        public int ImageId { get; set; }

        public DateTime? OnShelffTime { get; set; }

        public DateTime? OffShelffTime { get; set; }

        public IEnumerable<TagVM> tags { get; set; }

        public virtual VideoCategory VideoCategory { get; set; }

        public string images { get; set; }
    }

    public static class VideoExts
    {
        public static VideoVM ToVM(this VideoDto source)
        {
            return new VideoVM
            {
                Id = source.Id,
                Title = source.Title,
                Description = source.Description,
                ImageId = source.ImageId,
                OnShelffTime = source.OnShelffTime,
                OffShelffTime = source.OffShelffTime,
                images = source.Image.Path,
                tags = source.tags.Select(v => v.ToVM()),
                //VideoCategory= source.videoCategory,
            };
        }
    }
}