using ClickCart.Data.Repositories;
using ClickCart.Data.Models;
using Microsoft.AspNetCore.Http;

namespace ClickCart.Data.Repositories
{
    public class ProductCategoryRepository : BaseRepository<ProductCategory>
    {
        public ProductCategoryRepository(ClickCartDbContext clickCartDbContext, IHttpContextAccessor httpContextAccessor) : base(clickCartDbContext, httpContextAccessor)
        {
        }
    }
}