﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace HStyleApi.Models.EFModels
{
    public partial class Product
    {
        public Product()
        {
            ProductComments = new HashSet<ProductComment>();
            ProductLikes = new HashSet<ProductLike>();
            Specs = new HashSet<Spec>();
            Imgs = new HashSet<Image>();
            Tags = new HashSet<Tag>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
        public bool Discontinued { get; set; }
        public int DisplayOrder { get; set; }
        public int CategoryId { get; set; }

        public virtual Pcategory Category { get; set; }
        public virtual ICollection<ProductComment> ProductComments { get; set; }
        public virtual ICollection<ProductLike> ProductLikes { get; set; }
        public virtual ICollection<Spec> Specs { get; set; }

        public virtual ICollection<Image> Imgs { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}