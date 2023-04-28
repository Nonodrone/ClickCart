using ClickCart.Service.Models.Categories;
using ClickCart.Service.ProductCategories;
using Microsoft.AspNetCore.Mvc;

namespace ClickCart.Web.Areas.Administration.Controllers
{
    [Route("/Administration/Categories")]
    public class ProductCategoriesAdministrationController : BaseAdministrationController
    {
        private readonly IProductCategoryService productCategoryService;

        public ProductCategoriesAdministrationController(IProductCategoryService productCategoryService)
        {
            this.productCategoryService = productCategoryService;
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(ProductCategoryDto productCategoryDto)
        {
            await this.productCategoryService.CreateProductCategory(productCategoryDto);

            return Redirect("/Administration/Index");
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(long id)
        {
            return View(await this.productCategoryService.GetProductCategoryById(id));
        }

        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(long id, ProductCategoryDto productCategoryDto)
        {
            await this.productCategoryService.UpdateProductCategory(id, productCategoryDto);

            return Redirect("/Administration/Index");
        }

        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await this.productCategoryService.DeleteProductCategory(id);

            return Redirect("/Administration/Index");
        }
    }
}
