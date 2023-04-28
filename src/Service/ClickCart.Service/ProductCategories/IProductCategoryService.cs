using ClickCart.Service.Models.Categories;

namespace ClickCart.Service.ProductCategories
{
    public interface IProductCategoryService
    {
        Task<ProductCategoryDto> CreateProductCategory(ProductCategoryDto productCategoryDto);

        IQueryable<ProductCategoryDto> GetAllProductCategories();

        Task<ProductCategoryDto> GetProductCategoryById(long id);

        Task<ProductCategoryDto> UpdateProductCategory(long id, ProductCategoryDto productCategoryDto);

        Task<ProductCategoryDto> DeleteProductCategory(long id);
    }
}
