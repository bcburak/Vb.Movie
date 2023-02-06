using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Moq;
using VB.Movie.Application.Features.Queries;
using VB.Movie.Application.Interfaces.Repositories;
using VB.Movie.Application.Utils;
using VB.Movie.Application.Wrappers;
using VB.Movie.Test.Mocks;
using static VB.Movie.Application.Features.Queries.GetAllMoviesByImdbIdQuery;

namespace VB.Movie.Test.Features.Queries
{
    public class GetAllMoviesQueryRequestHandlerTests
    {
        private readonly HttpClient _client;
        private readonly IOptions<AppSettingsModel> _configurationService;
        private readonly IMock<IMovieRepository> _mockRepo;
        private readonly IHttpContextAccessor _contextAccessor;

        public GetAllMoviesQueryRequestHandlerTests()
        {
            _mockRepo = MockIMovieRepository.GetMock();
            _client = new HttpClient();
        }


        [Fact]
        public async Task GetMovieList()
        {
            var accessor = new Mock<HttpClientWrapper>(_client, _configurationService, _contextAccessor);
            var handler = new GetAllMoviesByImdbIdQueryHandler(_mockRepo.Object, accessor.Object);

            var result = await handler.Handle(new GetAllMoviesByImdbIdQuery() { ImdbId = "tt3896198" }, CancellationToken.None);
            Assert.NotNull(result);
        }
    }
}
