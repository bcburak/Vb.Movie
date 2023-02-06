using MediatR;
using System.Diagnostics;
using VB.Movie.Application.Interfaces.Repositories;
using VB.Movie.Application.Interfaces.Wrappers;
using VB.Movie.Application.Wrappers;
using VB.Movie.Domain.Dtos;

namespace VB.Movie.Application.Features.Queries
{
    public class GetAllMoviesByImdbIdQuery : IRequest<ServiceResponse<MovieDto>>
    {

        public string? ImdbId { get; set; }
        public class GetAllMoviesByImdbIdQueryHandler : IRequestHandler<GetAllMoviesByImdbIdQuery, ServiceResponse<MovieDto>>
        {
            private readonly IMovieRepository _movieRepository;
            private readonly IHttpClientWrapper _httpClientWrapper;
            public GetAllMoviesByImdbIdQueryHandler(IMovieRepository movieRepository, IHttpClientWrapper httpClientWrapper)
            {
                _movieRepository = movieRepository;
                _httpClientWrapper = httpClientWrapper;
            }

            public async Task<ServiceResponse<MovieDto>> Handle(GetAllMoviesByImdbIdQuery request, CancellationToken cancellationToken)
            {
                var products = await _movieRepository.GetAll();
                var startWatch = Stopwatch.StartNew();
                var imdbData = await _httpClientWrapper.GetAsync<MovieDto>(request.ImdbId);

                if (!products.Select(i => i.Search_Token).Equals(imdbData.Title))
                {

                    var movieEntity = new VB.Movie.Domain.Entites.Movie()
                    {
                        Id = new Guid(),
                        ImdbID = imdbData.ImdbID,
                        IP_Address = _httpClientWrapper.GetIPAddress(),
                        Timestamp = DateTime.UtcNow,
                        Search_Token = imdbData.Title,
                        Processing_Time_Ms = startWatch.Elapsed.TotalMilliseconds
                    };

                    await _movieRepository.Insert(movieEntity);
                }

                return new ServiceResponse<MovieDto>(imdbData);
            }
        }
    }
}
