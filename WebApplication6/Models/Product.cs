using System.ComponentModel.DataAnnotations.Schema;
using WebApplication6.Models.Base;

namespace WebApplication6.Models
{
    public class Product:BaseEntity
    {
        public string Name {  get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public List<ProductImage> Images { get; set; }
        public int CategoryId {  get; set; }
        public Category Category { get; set; }
        public string ImgUrl {  get; set; }


        [NotMapped]

        public IFormFile formFile { get; set; }
    }
}
