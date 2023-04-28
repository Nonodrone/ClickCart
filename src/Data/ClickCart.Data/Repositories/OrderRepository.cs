using ClickCart.Data.Repositories;
using ClickCart.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ClickCart.Data.Repositories
{
    public class OrderRepository : BaseRepository<Order>
    {
        public OrderRepository(ClickCartDbContext clickCartDbContext, IHttpContextAccessor httpContextAccessor) : base(clickCartDbContext, httpContextAccessor)
        {

        }

        public IQueryable<Order> RetrieveByUser(ClickCartUser clickCartUser)
        {
            return clickCartDbContext.Orders.Include(o => o.User).Where(p => p.User == clickCartUser).AsNoTracking();
        }

        public IQueryable<Order> RetrieveOrderById(long id)
        {
            return clickCartDbContext.Orders.Where(p => p.Id == id).AsNoTracking();
        }
        /*public async Task<Order> RetrieveOrderById(long id)
        {
            return await clickCartDbContext.Orders.AsNoTracking().SingleOrDefaultAsync(p => p.Id == id);
        }*/
    }
}