using MediatR;
using VB.Movie.Application.Interfaces.Repositories;
using VB.Movie.Application.Interfaces.Wrappers;
using VB.Movie.Application.Wrappers;

namespace VB.Movie.Application.Features.Commands
{
    public class DeleteMovieByIdCommand : Domain.Entites.Movie, IRequest<ServiceResponse<Guid>>
    {
        public Guid MovieId { get; set; }

        public class DeleteMovieByIdCommandHandler : IRequestHandler<DeleteMovieByIdCommand, ServiceResponse<Guid>>
        {
            private readonly IMovieRepository _movieRepository;
            private readonly IHttpClientWrapper _httpClientWrapper;
            public DeleteMovieByIdCommandHandler(IMovieRepository movieRepository, IHttpClientWrapper httpClientWrapper)
            {
                _movieRepository = movieRepository;
                _httpClientWrapper = httpClientWrapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(DeleteMovieByIdCommand request, CancellationToken cancellationToken)
            {
                //request.Title

                await _movieRepository.Delete(request.MovieId);
                return new ServiceResponse<Guid>(request.MovieId);
            }
        }
    }
}
