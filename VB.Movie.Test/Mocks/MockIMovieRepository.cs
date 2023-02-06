using Moq;
using VB.Movie.Application.Interfaces.Repositories;

namespace VB.Movie.Test.Mocks
{
    public static class MockIMovieRepository
    {

        public static Mock<IMovieRepository> GetMock()
        {

            var movies = new List<VB.Movie.Domain.Entites.Movie>
            {
                new VB.Movie.Domain.Entites.Movie
                {
                    Id= new Guid(),
                    IP_Address ="10.10.10.1",
                    Processing_Time_Ms = 123569,
                    CreateDate = DateTime.UtcNow
                },
                new VB.Movie.Domain.Entites.Movie
                {
                    Id= new Guid(),
                    IP_Address ="10.10.10.2",
                    Processing_Time_Ms = 223569,
                    CreateDate = DateTime.UtcNow
                }
            };

            var mock = new Mock<IMovieRepository>();

            mock.Setup(m => m.GetAll()).ReturnsAsync(movies);

            return mock;
        }


    }
}
