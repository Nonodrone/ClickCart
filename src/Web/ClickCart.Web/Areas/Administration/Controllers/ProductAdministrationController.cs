using ClickCart.Service.Models.Products;
using ClickCart.Service.ProductCategories;
using ClickCart.Service.Products;
using Microsoft.AspNetCore.Mvc;

namespace ClickCart.Web.Areas.Administration.Controllers
{
    [Route("/Administration/Product")]
    public class ProductAdministrationController : BaseAdministrationController
    {
        private readonly IProductService productService;
        private readonly IProductCategoryService productCategoryService;

        public ProductAdministrationController(IProductService productService, IProductCategoryService productCategoryService)
        {
            this.productService = productService;
            this.productCategoryService = productCategoryService;
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            this.ViewData["Categories"] = this.productCategoryService.GetAllProductCategories().ToList();
            
            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            await this.productService.CreateProduct(productDto);

            return Redirect("/Administration/Index");
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(long id)
        {
            this.ViewData["Categories"] = this.productCategoryService.GetAllProductCategories().ToList();

            return View(await this.productService.GetProductById(id));
        }

        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(long id, ProductDto productDto)
        {
            await this.productService.UpdateProduct(id, productDto);

            return Redirect("/Administration/Index");
        }

        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await this.productService.DeleteProduct(id);

            return Redirect("/Administration/Index");
        }
    }
}
