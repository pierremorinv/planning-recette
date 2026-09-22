using Microsoft.EntityFrameworkCore;
using planningRecette.Domain.Base;
using planningRecette.Infrastructure.Database;
using System.Linq.Expressions;

namespace planningRecette.Infrastructure.Base
{
    public class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
         where TEntity : BaseEntity
         where TContext : PlanningRecetteDbContext
    {
        protected readonly TContext _dbContext;

        public BaseRepository(TContext context)
        {
            _dbContext = context;
        }

        public async Task<TEntity> GetById(int id)
        {
            try
            {
                return await _dbContext.Set<TEntity>().FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Impossible de récupérer l'entité: {ex.Message}");
            }
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Impossible de récupérer les entités: {ex.Message}");
            }
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> where)
        {
            try
            {
                return await _dbContext.Set<TEntity>().Where(where).AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Impossible de récupérer les entités: {ex.Message}");
            }
        }
    }
}