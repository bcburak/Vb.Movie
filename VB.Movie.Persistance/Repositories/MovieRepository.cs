using VB.Movie.Application.Interfaces.Repositories;
using VB.Movie.Persistence.Context;

namespace VB.Movie.Persistence.Repositories
{
    public class MovieRepository : GenericRepository<VB.Movie.Domain.Entites.Movie>, IMovieRepository
    {
        public MovieRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
