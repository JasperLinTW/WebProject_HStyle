using H2StyleStore.Models.EFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace H2StyleStore.Models.DTOs
{
    public class ImageDto
    {
        public int Image_Id { get; set; }

        public string Path { get; set; }
    }

    public static class ImageExts
    {
        public static ImageDto ToDto(this Image source)
        => new ImageDto
        {
            Image_Id= source.Image_Id,
            Path = source.Path,
        };
    }
}