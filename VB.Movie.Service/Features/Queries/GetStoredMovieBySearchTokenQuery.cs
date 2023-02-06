using MediatR;
using VB.Movie.Application.Interfaces.Repositories;
using VB.Movie.Application.Wrappers;

namespace VB.Movie.Application.Features.Queries
{
    public class GetStoredMovieBySearchTokenQuery : IRequest<ServiceResponse<Domain.Entites.Movie>>
    {
        public string? SearchToken { get; set; }
        public class GetStoredMovieBySearchTokenQueryHandler : IRequestHandler<GetStoredMovieBySearchTokenQuery, ServiceResponse<Domain.Entites.Movie>>
        {

            private readonly IMovieRepository _movieRepository;
            public GetStoredMovieBySearchTokenQueryHandler(IMovieRepository movieRepository)
            {
                _movieRepository = movieRepository;
            }

            public async Task<ServiceResponse<Domain.Entites.Movie>> Handle(GetStoredMovieBySearchTokenQuery request, CancellationToken cancellationToken)
            {
                var movies = await _movieRepository.GetOne(i => i.Search_Token.Equals(request.SearchToken));

                return new ServiceResponse<Domain.Entites.Movie>(movies);
            }

        }

    }
}
