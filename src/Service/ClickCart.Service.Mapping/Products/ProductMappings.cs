using ClickCart.Data.Models;
using ClickCart.Service.Mapping.ProductCategories;
using ClickCart.Service.Models.Products;

namespace ClickCart.Service.Mapping.Products
{
    public static class ProductMappings
    {
        public static Product ToEntity(this ProductDto ProductDto)
        {
            return new Product
            {
                Id = ProductDto.Id,
                Name = ProductDto.Name,
                Price = ProductDto.Price,
                ImageUrl = ProductDto.ImageUrl,
                Description = ProductDto.Description
            };
        }

        public static ProductDto ToDto(this Product Product, bool fetchCategory = true)
        {
            return new ProductDto
            {
                Id = Product.Id,
                Name = Product.Name,
                Price = Product.Price,
                ImageUrl = Product.ImageUrl,
                Description = Product.Description,
                Category = fetchCategory ? Product.Category?.ToDto(fetchProducts: false) : null
            };
        }
    }
}
