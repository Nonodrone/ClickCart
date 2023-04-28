using ClickCart.Service.Models.Users;

namespace ClickCart.Service.Models.Orders
{
    public class OrderDto : BaseDto
    {
        public bool isCompleted { get; set; }

        public ClickCartUserDto User { get; set; }

        public List<OrderProductDto> Products { get; set; }
    }
}
