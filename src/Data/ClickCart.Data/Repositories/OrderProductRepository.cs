using ClickCart.Data.Repositories;
using ClickCart.Data.Models;
using Microsoft.AspNetCore.Http;

namespace ClickCart.Data.Repositories
{
    public class OrderProductRepository : BaseRepository<OrderProduct>
    {
        public OrderProductRepository(ClickCartDbContext clickCartDbContext, IHttpContextAccessor httpContextAccessor) : base(clickCartDbContext, httpContextAccessor)
        {
        }
    }
}