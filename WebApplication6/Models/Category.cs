﻿using System.ComponentModel.DataAnnotations.Schema;
using WebApplication6.Models.Base;

namespace WebApplication6.Models
{
    public class Category:BaseEntity
    {
        public string Name {  get; set; }
        public List<Product> Products { get; set; }
        


        [NotMapped]

        public IFormFile formFile { get; set; }
    }
}
