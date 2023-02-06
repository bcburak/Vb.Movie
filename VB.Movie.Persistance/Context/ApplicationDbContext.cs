using Microsoft.Extensions.Options;
using MongoDB.Driver;
using VB.Movie.Application.Utils;

namespace VB.Movie.Persistence.Context
{
    public class ApplicationDbContext
    {
        private IMongoDatabase _db { get; set; }
        private MongoClient _mongoClient { get; set; }
        //public IClientSessionHandle Session { get; set; }

        public ApplicationDbContext(IOptions<AppSettingsModel> configuration)
        {
            _mongoClient = new MongoClient(configuration.Value.ConnectionString);
            _db = _mongoClient.GetDatabase(configuration.Value.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _db.GetCollection<T>(name);
        }
    }
}
