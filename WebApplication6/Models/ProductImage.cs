using WebApplication6.Models.Base;

namespace WebApplication6.Models
{
    public class ProductImage:BaseEntity
    {
        public string ImgUrl { get; set; }
        public bool IsPrime { get; set; }
    }
}
