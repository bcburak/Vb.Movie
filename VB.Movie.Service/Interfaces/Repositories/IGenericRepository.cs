using System.Linq.Expressions;
using VB.Movie.Domain.Common;

namespace VB.Movie.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<Guid> Insert(T entity);
        Task<Guid> Delete(Guid id);
        Task<T> GetOne(Expression<Func<T, bool>> expression);
        Task<List<T>> FilterBy(Expression<Func<T, bool>> expression);
    }
}
