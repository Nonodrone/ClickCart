using ClickCart.Data;
using ClickCart.Data.Models;
using ClickCart.Data.Repositories;
using ClickCart.Service.Mapping.OrderProducts;
using ClickCart.Service.Mapping.Orders;
using ClickCart.Service.Models.Orders;
using ClickCart.Service.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace ClickCart.Service.OrderProducts
{
    public class OrderProductService : IOrderProductService
    {
        ClickCartDbContext clickCartDbContext;
        private readonly OrderProductRepository orderProductRepository;
        private readonly OrderRepository orderRepository;

        public OrderProductService(OrderProductRepository orderProductrepository, OrderRepository orderRepository, ClickCartDbContext clickCartDbContext)
        {
            this.orderProductRepository = orderProductrepository;
            this.orderRepository = orderRepository;
            this.clickCartDbContext = clickCartDbContext;
        }

        public async Task<OrderProductDto> CreateOrderProduct(OrderProductDto orderProductDto)
        {
            OrderProduct orderProduct = orderProductDto.ToEntity();

            Order order = await this.orderRepository.RetrieveOrderById(orderProduct.Order.Id).AsNoTracking().FirstOrDefaultAsync();

            if (order == null)
            {
                throw new ArgumentException("Order not found");
            }

            orderProduct.Order = order;

            await orderProductRepository.AddAsync(orderProduct);
            
            return orderProduct.ToDto();
        }

        public async Task<OrderProductDto> DeleteOrderProduct(long id)
        {
            OrderProduct orderProduct = await this.orderProductRepository
                .RetrieveAllTracked()
                .SingleOrDefaultAsync(orderProduct => orderProduct.Id == id);

            if (orderProduct == null)
            {
                throw new ArgumentException("The product does not exist in this order!");
            }

            await this.orderProductRepository.RemoveAsync(orderProduct);

            return orderProduct.ToDto();
        }

        public IQueryable<OrderProductDto> GetAllOrderProducts()
        {
            IQueryable<OrderProduct> orderProduct = this.orderProductRepository.RetrieveAll();

            return orderProduct.Select(orderProduct => orderProduct.ToDto(true, true));
        }

        public async Task<OrderProductDto> GetOrderProductDtoById(long id)
        {
            OrderProduct orderProduct = await this.orderProductRepository
                .RetrieveAllTracked()
                .SingleOrDefaultAsync(orderProduct => orderProduct.Id == id);

            if (orderProduct == null)
            {
                throw new ArgumentException("The product does not exist");
            }

            return orderProduct.ToDto();
        }

        public async Task<OrderProductDto> UpdateOrderProduct(long id, OrderProductDto orderProductDto)
        {
            OrderProduct orderProduct = await this.orderProductRepository
                .RetrieveAllTracked()
                .FirstAsync(orderProduct => orderProduct.Id == id);

            if (orderProduct == null)
            {
                throw new ArgumentException("The order does not exist!");
            }

            orderProduct.ProductCount = orderProductDto.ProductCount;

            await this.orderProductRepository.EditAsync(orderProduct);

            return orderProduct.ToDto(true, true);
        }
    }
}
