using MediatR;
using VB.Movie.Application.Interfaces.Repositories;
using VB.Movie.Application.Wrappers;

namespace VB.Movie.Application.Features.Queries
{
    public class GetAllStoredMoviesQuery : IRequest<ServiceResponse<List<Domain.Entites.Movie>>>
    {

        public class GetAllStoredMoviesQueryHandler : IRequestHandler<GetAllStoredMoviesQuery, ServiceResponse<List<Domain.Entites.Movie>>>
        {
            private readonly IMovieRepository _movieRepository;
            public GetAllStoredMoviesQueryHandler(IMovieRepository movieRepository)
            {
                _movieRepository = movieRepository;
            }

            public async Task<ServiceResponse<List<Domain.Entites.Movie>>> Handle(GetAllStoredMoviesQuery request, CancellationToken cancellationToken)
            {
                var allMovies = await _movieRepository.GetAll();
                return new ServiceResponse<List<Domain.Entites.Movie>>(allMovies);
            }
        }


    }
}
