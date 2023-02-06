using MediatR;
using VB.Movie.Application.Interfaces.Repositories;
using VB.Movie.Application.Wrappers;

namespace VB.Movie.Application.Features.Queries
{
    public class GetStoredMovieByOnDatePeriodQuery : IRequest<ServiceResponse<List<Domain.Entites.Movie>>>
    {
        public class GetStoredMovieByOnDatePeriodQueryHandler : IRequestHandler<GetStoredMovieByOnDatePeriodQuery, ServiceResponse<List<Domain.Entites.Movie>>>
        {

            private readonly IMovieRepository _movieRepository;
            public GetStoredMovieByOnDatePeriodQueryHandler(IMovieRepository movieRepository)
            {
                _movieRepository = movieRepository;
            }

            public async Task<ServiceResponse<List<Domain.Entites.Movie>>> Handle(GetStoredMovieByOnDatePeriodQuery request, CancellationToken cancellationToken)
            {
                var movies = await _movieRepository.FilterBy(i => i.Timestamp >= DateTime.Now && i.Timestamp <= DateTime.Now);

                return new ServiceResponse<List<Domain.Entites.Movie>>(movies);
            }

        }
    }
}
