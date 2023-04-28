using ClickCart.Data.Models;
using ClickCart.Service.Mapping.Orders;
using ClickCart.Service.Mapping.Products;
using ClickCart.Service.Models.Orders;

namespace ClickCart.Service.Mapping.OrderProducts
{
    public static class OrderProductMappings
    {
        public static OrderProduct ToEntity(this OrderProductDto OrderProductDto)
        {
            return new OrderProduct
            {
                Id = OrderProductDto.Id,
                ProductCount = OrderProductDto.ProductCount,
                Order = OrderProductDto.OrderDto.ToEntity(),
                Product = OrderProductDto.ProductDto.ToEntity()
            };
        }

        public static OrderProductDto ToDto(this OrderProduct Product, bool fetchProduct = true, bool fetchOrder = true)
        {
            return new OrderProductDto
            {
                Id = Product.Id,
                ProductCount = Product.ProductCount,
                ProductDto = fetchProduct ? Product.Product.ToDto() : null,
                OrderDto = fetchOrder ? Product.Order.ToDto() : null
            };
        }
    }
}