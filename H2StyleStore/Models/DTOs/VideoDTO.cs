﻿using H2StyleStore.Models.EFModels;
using H2StyleStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace H2StyleStore.Models.DTOs
{
    public class VideoDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string FilePath { get; set; }

        public int CategoryId { get; set; }

        public int ImageId { get; set; }

        public DateTime? OnShelffTime { get; set; }

        public DateTime? OffShelffTime { get; set; }

        public ImageDto Image { get; set; }

        public IEnumerable<TagDto> tags { get; set; }

        //public virtual VideoCategory VideoCategory { get; set; }
    }

    public static class VideoExts
    {
        public static VideoDto ToDto( this Video source)
        {
            return new VideoDto
            {
                Id= source.Id,
                Title= source.Title,
                Description= source.Description,
                CategoryId=source.VideoCategory.Id,
                ImageId=source.ImageId,
                OnShelffTime=source.OnShelffTime,
                OffShelffTime=source.OffShelffTime,
                Image = source.Image.ToDto(),
                tags = source.Tags.Select(x => x.ToDto()),
            };
        }
    }

    
}