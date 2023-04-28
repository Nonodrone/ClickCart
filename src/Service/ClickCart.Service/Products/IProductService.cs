using ClickCart.Service.Models.Products;

namespace ClickCart.Service.Products
{
    public interface IProductService
    {
        Task<ProductDto> CreateProduct(ProductDto productDto);

        IQueryable<ProductDto> GetAllProducts();

        Task<ProductDto> GetProductById(long id);

        Task<ProductDto> UpdateProduct(long id, ProductDto productDto);

        Task<ProductDto> DeleteProduct(long id);
    }
}
