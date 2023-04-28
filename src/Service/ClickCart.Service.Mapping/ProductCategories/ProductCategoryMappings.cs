using ClickCart.Data.Models;
using ClickCart.Service.Mapping.Products;
using ClickCart.Service.Models.Categories;

namespace ClickCart.Service.Mapping.ProductCategories
{
    public static class ProductCategoryMappings
    {
        public static ProductCategory ToEntity(this ProductCategoryDto ProductCategoryDto)
        {
            return new ProductCategory
            {
                Id = ProductCategoryDto.Id,
                Name = ProductCategoryDto.Name,
            };
        }

        public static ProductCategoryDto ToDto(this ProductCategory ProductCategory, bool fetchProducts = true)
        {
            return new ProductCategoryDto
            {
                Id = ProductCategory.Id,
                Name = ProductCategory.Name,
                Products = fetchProducts ? ProductCategory.Products?.Select(product => product.ToDto()).ToList() : null
            };
        }
    }
}
