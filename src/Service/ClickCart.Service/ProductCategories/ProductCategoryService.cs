using ClickCart.Data.Models;
using ClickCart.Data.Repositories;
using ClickCart.Service.Models.Products;
using ClickCart.Service.Mapping.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ClickCart.Service.Models.Categories;
using ClickCart.Service.Mapping.ProductCategories;

namespace ClickCart.Service.ProductCategories
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly ProductCategoryRepository productCategoryRepository;
        private readonly ProductRepository productRepository;

        public ProductCategoryService(ProductCategoryRepository productCategoryRepository, ProductRepository productRepository)
        {
            this.productRepository = productRepository;
            this.productCategoryRepository = productCategoryRepository;
        }

        public async Task<ProductCategoryDto> CreateProductCategory(ProductCategoryDto productCategoryDto)
        {
            ProductCategory productCategory = productCategoryDto.ToEntity();

            await productCategoryRepository.AddAsync(productCategory);

            return productCategory.ToDto();
        }

        public async Task<ProductCategoryDto> DeleteProductCategory(long id)
        {
            ProductCategory productCategory = await this.productCategoryRepository
                .RetrieveAllTracked()
                .SingleOrDefaultAsync(category => category.Id == id);

            if (productCategory == null)
            {
                throw new ArgumentException("The product category does not exist!");
            }

            await this.productCategoryRepository.RemoveAsync(productCategory);

            return productCategory.ToDto();
        }

        public IQueryable<ProductCategoryDto> GetAllProductCategories()
        {
            IQueryable<ProductCategory> productCategory = this.productCategoryRepository.RetrieveAll();

            return productCategory.Select(category => category.ToDto(true));
        }

        public async Task<ProductCategoryDto> GetProductCategoryById(long id)
        {
            ProductCategory productCategory = await this.productCategoryRepository
                .RetrieveAllTracked()
                .SingleOrDefaultAsync(category => category.Id == id);

            if (productCategory == null) {
                throw new ArgumentException("The product category does not exist!");
            }

            return productCategory.ToDto(true);
        }

        public async Task<ProductCategoryDto> UpdateProductCategory(long id, ProductCategoryDto productCategoryDto)
        {
            ProductCategory productCategory = await this.productCategoryRepository
                .RetrieveAllTracked()
                .SingleOrDefaultAsync(category => category.Id == id);

            if (productCategory == null)
            {
                throw new ArgumentException("The product category does not exist!");
            }

            productCategory.Name = productCategoryDto.Name;

            await this.productCategoryRepository.EditAsync(productCategory);

            return productCategory.ToDto();
        }
    }
}
