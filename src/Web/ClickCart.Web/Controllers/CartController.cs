using ClickCart.Data.Models;
using ClickCart.Service.Models.Orders;
using ClickCart.Service.Models.Products;
using ClickCart.Service.OrderProducts;
using ClickCart.Service.Orders;
using ClickCart.Service.Products;
using Humanizer.DateTimeHumanizeStrategy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ClickCart.Web.Controllers
{
    [Route("/Cart")]
    public class CartController : Controller
    {
        private readonly UserManager<ClickCartUser> clickCartUserManager;

        private readonly IOrderProductService orderProductService;

        private readonly IOrderService orderService;

        private readonly IProductService productService;

        public CartController(UserManager<ClickCartUser> clickCartUserManager, IOrderProductService oderProductService, IOrderService orderService, IProductService productService)
        {
            this.clickCartUserManager = clickCartUserManager;
            this.orderProductService = oderProductService;
            this.orderService = orderService;
            this.productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(long id)
        {
                ClickCartUser user = await clickCartUserManager.GetUserAsync(User);
                
                if(user == null)
                {
                    throw new NullReferenceException("User is null");
                }

                List<OrderDto> orders = this.orderService.GetCartByUser(user).ToList();
                
                OrderDto cart = null;

                foreach (OrderDto orderDto in orders)
                {
                    if (orderDto.isCompleted == false)
                    {
                        cart = orderDto;
                        break;
                    }
                }

                if (cart == null)
                {
                     cart = await this.orderService.CreateOrderByUser(user);
                }

                OrderProductDto orderProductDto = new OrderProductDto();

                orderProductDto.ProductDto = await this.productService.GetProductById(id);

                orderProductDto.OrderDto = cart;

                orderProductDto.ProductCount++;

                await this.orderProductService.CreateOrderProduct(orderProductDto);

                return Redirect("/");
        }
    }
}
