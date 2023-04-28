using ClickCart.Data.Models;
using ClickCart.Service.Mapping.OrderProducts;
using ClickCart.Service.Mapping.Users;
using ClickCart.Service.Models.Orders;

namespace ClickCart.Service.Mapping.Orders
{
    public static class OrderMappings
    {
        public static Order ToEntity(this OrderDto OrderDto)
        {
            return new Order
            {
                Id = OrderDto.Id,
                isCompleted = OrderDto.isCompleted,
                //OrderProducts = OrderDto.Products.Select(p => p.ToEntity()).ToList(),
                User = OrderDto.User.ToEntity(),
            };
        }


        public static OrderDto ToDto(this Order Order, bool fetchUser = true, bool fetchProducts = true)
        {
            return new OrderDto
            {
                Id = Order.Id,
                User = Order.User.ToDto(),
                //Products = Order.OrderProducts.Select(p => p.ToDto()).ToList()
            };
        }
    }
}
