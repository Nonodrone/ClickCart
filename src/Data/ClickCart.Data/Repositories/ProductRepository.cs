using ClickCart.Data.Repositories;
using ClickCart.Data.Models;
using Microsoft.AspNetCore.Http;

namespace ClickCart.Data.Repositories
{
    public class ProductRepository : BaseRepository<Product>
    {
        public ProductRepository(ClickCartDbContext clickCartDbContext, IHttpContextAccessor httpContextAccessor) : base(clickCartDbContext, httpContextAccessor)
        {
        }
    }
}