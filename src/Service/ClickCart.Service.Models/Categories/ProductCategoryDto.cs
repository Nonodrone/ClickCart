using ClickCart.Service.Models.Products;

namespace ClickCart.Service.Models.Categories
{
    public class ProductCategoryDto : BaseDto
    {
        public String Name { get; set; }

        public List<ProductDto> Products { get; set; }
    }
}
