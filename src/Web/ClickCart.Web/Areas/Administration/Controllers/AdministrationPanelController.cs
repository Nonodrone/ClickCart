using ClickCart.Service.ProductCategories;
using ClickCart.Service.Products;
using ClickCart.Web.Models.Administration.AdministrationPanel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ClickCart.Web.Areas.Administration.Controllers
{
    [Route("/Administration/Index")]
    public class AdministrationPanelController : BaseAdministrationController
    {
        private readonly IProductService productService;

        private readonly IProductCategoryService productCategoryService;

        public AdministrationPanelController(IProductService productService, IProductCategoryService productCategoryService)
        {
            this.productService = productService;
            this.productCategoryService = productCategoryService;
        }

        public IActionResult Index()
        {
            return View(new AdministrationPanelModel
            {
                Products = this.productService.GetAllProducts().ToList(),
                ProductCategories = this.productCategoryService.GetAllProductCategories().ToList()
            });
        }
    }
}
