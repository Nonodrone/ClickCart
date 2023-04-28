using ClickCart.Data.Models;
using ClickCart.Service.Models.Categories;
using ClickCart.Service.Models.Orders;
using ClickCart.Service.OrderProducts;
using ClickCart.Service.Products;
using ClickCart.Web.Models.Home;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ClickCart.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService productService;

        private readonly IOrderProductService orderProductService;

        private readonly UserManager<ClickCartUser> clickCartUserManager;

        public HomeController(IProductService productService, IOrderProductService orderProductService, UserManager<ClickCartUser> clickCartUserManager)
        {
            this.productService = productService;
            this.orderProductService = orderProductService;
            this.clickCartUserManager = clickCartUserManager;
        }

        public IActionResult Index()
        {
            return View(new HomeModel
            {
                Products = this.productService.GetAllProducts().ToList()
            });
        }
    }
}