using ClickCart.Data.Models;
using ClickCart.Data.Repositories;
using ClickCart.Service.Models.Products;
using ClickCart.Service.Mapping.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ClickCart.Service.Mapping.ProductCategories;

namespace ClickCart.Service.Products
{
    public class ProductService : IProductService
    {
        private readonly ProductRepository productRepository;
        private readonly ProductCategoryRepository productCategoryRepository;

        public ProductService(ProductRepository productRepository, ProductCategoryRepository productCategoryRepository)
        {
            this.productRepository = productRepository;
            this.productCategoryRepository = productCategoryRepository;
        }

        public async Task<ProductDto> CreateProduct(ProductDto productDto)
        {
            Product product = productDto.ToEntity();

            var productCategory = await this.productCategoryRepository
                .RetrieveAllTracked()
                .SingleOrDefaultAsync(category => category.Id == productDto.Category.Id);

            if (productCategory == null)
            {
                throw new ArgumentException("The category does not exist");
            }

            product.Category = productCategory;

            await productRepository.AddAsync(product);

            return product.ToDto();
        }

        public async Task<ProductDto> DeleteProduct(long id)
        {
            Product product = await this.productRepository
                .RetrieveAllTracked()
                .SingleOrDefaultAsync(product => product.Id == id);

            if(product == null)
            {
                throw new ArgumentException("The product does not exist!");
            }

            await this.productRepository.RemoveAsync(product);

            return product.ToDto();
        }

        public IQueryable<ProductDto> GetAllProducts()
        {
            IQueryable<Product> product = this.productRepository.RetrieveAll()
                .Include(product => product.Category);

            return product.Select(product => product.ToDto(true));
        }

        public async Task<ProductDto> GetProductById(long id)
        {
            Product product = await this.productRepository
                .RetrieveAllTracked().AsNoTracking()
                .SingleOrDefaultAsync(product => product.Id == id);

            if (product == null)
            {
                throw new ArgumentException("The product does not exist!");
            }

            return product.ToDto();
        }

        public async Task<ProductDto> UpdateProduct(long id, ProductDto productDto)
        {
            Product product = await this.productRepository
                .RetrieveAllTracked()
                .SingleOrDefaultAsync(product => product.Id == id);

            if (product == null)
            {
                throw new ArgumentException("The product does not exist!");
            }

            product.Name = productDto.Name;
            product.Price = productDto.Price;
            product.Description = productDto.Description;
            product.ImageUrl = productDto.ImageUrl;
            product.Category = await this.productCategoryRepository
                .RetrieveAllTracked()
                .SingleOrDefaultAsync(category => category.Id == productDto.Category.Id);

            await this.productRepository.EditAsync(product);

            return product.ToDto();
        }
    }
}