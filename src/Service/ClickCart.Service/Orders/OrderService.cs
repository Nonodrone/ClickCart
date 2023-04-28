using ClickCart.Data.Models;
using ClickCart.Data.Repositories;
using ClickCart.Service.Mapping.OrderProducts;
using ClickCart.Service.Mapping.Orders;
using ClickCart.Service.Mapping.ProductCategories;
using ClickCart.Service.Mapping.Users;
using ClickCart.Service.Models.Orders;
using Microsoft.EntityFrameworkCore;

namespace ClickCart.Service.Orders
{
    public class OrderService : IOrderService
    {
        private readonly OrderRepository orderRepository;

        public OrderService(OrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<OrderDto> CreateOrder(OrderDto orderDto)
        {
            Order order = orderDto.ToEntity();

            await orderRepository.AddAsync(order);

            return order.ToDto();
        }

        public async Task<OrderDto> CreateOrderByUser(ClickCartUser clickCartUser)
        {
            OrderDto orderDto = new OrderDto();

            Order order = orderDto.ToEntity();

            order.User = clickCartUser;

            //order.OrderProducts = new List<OrderProduct>();

            await orderRepository.AddAsync(order);

            return order.ToDto();
        }

        public async Task<OrderDto> DeleteOrder(long id)
        {
            Order order = await this.orderRepository
                .RetrieveAllTracked()
                .SingleOrDefaultAsync(order => order.Id == id);

            if (order == null)
            {
                throw new ArgumentException("The product category does not exist!");
            }

            await this.orderRepository.RemoveAsync(order);

            return order.ToDto();
        }

        public IQueryable<OrderDto> GetAllOrders()
        {
            IQueryable<Order> order = this.orderRepository.RetrieveAll();

            return order.Select(order => order.ToDto(true, true));
        }

        public async Task<OrderDto> GetOrderCategoryById(long id)
        {
            Order order = await this.orderRepository
                .RetrieveAllTracked()
                .FirstAsync(order => order.Id == id);

            if (order == null)
            {
                throw new ArgumentException("The order does not exist!");
            }

            return order.ToDto(true, true);
        }

        public IQueryable<OrderDto> GetCartByUser(ClickCartUser clickCartUser)
        {
            IQueryable<Order> orders = this.orderRepository.RetrieveByUser(clickCartUser).AsNoTracking();

            return orders.Select(order => order.ToDto(true, true));
        }

        public async Task<OrderDto> UpdateOrder(long id, OrderDto orderDto)
        {
            Order order = await this.orderRepository
                .RetrieveAllTracked()
                .FirstAsync(order => order.Id == id);

            if (order == null)
            {
                throw new ArgumentException("The order does not exist!");
            }

            order.isCompleted = orderDto.isCompleted;

            await this.orderRepository.EditAsync(order);

            return order.ToDto(true, true);
        }
    }
}
