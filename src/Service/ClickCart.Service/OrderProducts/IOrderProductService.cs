using ClickCart.Service.Models.Orders;

namespace ClickCart.Service.OrderProducts
{
    public interface IOrderProductService
    {
        Task<OrderProductDto> CreateOrderProduct(OrderProductDto orderProductDto);

        IQueryable<OrderProductDto> GetAllOrderProducts();

        Task<OrderProductDto> GetOrderProductDtoById(long id);

        Task<OrderProductDto> UpdateOrderProduct(long id, OrderProductDto orderProductDto);

        Task<OrderProductDto> DeleteOrderProduct(long id);
    }
}
