using planningRecette.Domain.Base;
using System.Linq.Expressions;

namespace planningRecette.Applications.Base
{
    public interface IBaseService<T> where T : BaseEntity
    {
        Task<T> GetById(int id);

        Task<List<T>> GetAllAsync();

        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> where);
    }
}