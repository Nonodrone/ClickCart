using ClickCart.Data.Models;
using ClickCart.Service.Models.Orders;

namespace ClickCart.Service.Orders
{
    public interface IOrderService
    {
        Task<OrderDto> CreateOrder(OrderDto orderDto);

        Task<OrderDto> CreateOrderByUser(ClickCartUser clickCartUser);

        IQueryable<OrderDto> GetAllOrders();

        Task<OrderDto> GetOrderCategoryById(long id);

        IQueryable<OrderDto> GetCartByUser(ClickCartUser clickCartUser);

        Task<OrderDto> UpdateOrder(long id, OrderDto orderDto);

        Task<OrderDto> DeleteOrder(long id);
    }
}
