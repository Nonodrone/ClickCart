
using ClickCart.Service.Models.Categories;

namespace ClickCart.Service.Models.Products
{
    public class ProductDto : BaseDto
    {
        public String Name { get; set; }

        public float Price { get; set; }

        public String ImageUrl { get; set; }

        public String Description { get; set; }

        public ProductCategoryDto Category { get; set; }
    }
}
