﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace HStyleApi.Models.EFModels
{
    public partial class Image
    {
        public Image()
        {
            Videos = new HashSet<Video>();
            Essays = new HashSet<Essay>();
            Products = new HashSet<Product>();
        }

        public int ImageId { get; set; }
        public string Path { get; set; }

        public virtual ICollection<Video> Videos { get; set; }

        public virtual ICollection<Essay> Essays { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}