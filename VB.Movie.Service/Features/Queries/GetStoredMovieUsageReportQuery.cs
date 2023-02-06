using MediatR;
using VB.Movie.Application.Interfaces.Repositories;
using VB.Movie.Application.Wrappers;
using VB.Movie.Domain.Dtos;

namespace VB.Movie.Application.Features.Queries
{
    internal class GetStoredMovieUsageReportQuery : IRequest<ServiceResponse<UserReport>>
    {

        public class GetStoredMovieUsageReportQueryHandler : IRequestHandler<GetStoredMovieUsageReportQuery, ServiceResponse<UserReport>>
        {

            private readonly IMovieRepository _movieRepository;
            public GetStoredMovieUsageReportQueryHandler(IMovieRepository movieRepository)
            {
                _movieRepository = movieRepository;
            }

            public async Task<ServiceResponse<UserReport>> Handle(GetStoredMovieUsageReportQuery request, CancellationToken cancellationToken)
            {

                return new ServiceResponse<UserReport>(new UserReport());
            }

        }
    }
}
