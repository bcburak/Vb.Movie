using MongoDB.Driver;
using System.Linq.Expressions;
using VB.Movie.Application.Interfaces.Repositories;
using VB.Movie.Persistence.Context;

namespace VB.Movie.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : VB.Movie.Domain.Common.BaseEntity
    {
        private readonly ApplicationDbContext _dbContext;
        protected IMongoCollection<T> _dbCollection;
        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbCollection = _dbContext.GetCollection<T>(typeof(T).Name);
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _dbCollection.FindOneAndDeleteAsync(x => x.Id == id);
            return id;
        }

        public async Task<T> GetById(Guid id)
        {
            return await _dbCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbCollection.AsQueryable().ToListAsync();
        }

        public async Task<Guid> Insert(T entity)
        {
            await _dbCollection.InsertOneAsync(entity);
            return entity.Id;
        }

        public async Task<List<T>> FilterBy(Expression<Func<T, bool>> expression)
        {
            return await _dbCollection.Find(expression).ToListAsync();
        }


        public async Task<T> GetOne(Expression<Func<T, bool>> expression)
        {
            return await _dbCollection.Find(expression).FirstOrDefaultAsync();
        }



    }
}
