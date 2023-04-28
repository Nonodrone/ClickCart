using ClickCart.Service.Models.Products;

namespace ClickCart.Service.Models.Orders
{
    public class OrderProductDto : BaseDto
    {
        public ProductDto ProductDto { get; set; }

        public OrderDto OrderDto { get; set; }

        public int ProductCount { get; set; }
    }
}
