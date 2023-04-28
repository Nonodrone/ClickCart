using ClickCart.Data.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace ClickCart.Data.Repositories
{
    public class BaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ClickCartDbContext clickCartDbContext;

        private readonly IHttpContextAccessor _httpContextAccessor;

        private ClickCartUser cachedUser;

        public BaseRepository(ClickCartDbContext clickCartDbContext, IHttpContextAccessor httpContextAccessor)
        {
            this.clickCartDbContext = clickCartDbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await this.clickCartDbContext.AddAsync(entity);
            await this.clickCartDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> AddManyAsync(IEnumerable<TEntity> entities)
        {
            var currentUser = await this.GetCurrentUserAsync();

            await this.clickCartDbContext.AddRangeAsync(entities.Select(entity =>
            {
                return entity;
            }).ToList());

            await this.clickCartDbContext.SaveChangesAsync();
            return entities;
        }

        public IQueryable<TEntity> RetrieveAll()
        {
            return this.RetrieveAllTracked().AsNoTracking();
        }

        public IQueryable<TEntity> RetrieveAllTracked()
        {
            return this.clickCartDbContext.Set<TEntity>();
        }
        
        public async Task<TEntity> EditAsync(TEntity entity)
        {
            this.clickCartDbContext.Update(entity);
            await this.clickCartDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> EditWithoutMetadataAsync(TEntity entity)
        {
            this.clickCartDbContext.Update(entity);
            await this.clickCartDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> RemoveAsync(TEntity entity)
        {
            this.clickCartDbContext.Remove(entity);
            await this.clickCartDbContext.SaveChangesAsync();
            return entity;
        }

        protected async Task<ClickCartUser> GetCurrentUserAsync()
        {
            if (this.cachedUser == null)
            {
                string userId = this._httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

                this.cachedUser = await this.clickCartDbContext.Users
                    .SingleOrDefaultAsync(user => user.Id == userId);
            }

            return this.cachedUser;
        }
    }
}
