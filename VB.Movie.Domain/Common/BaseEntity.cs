using MongoDB.Bson.Serialization.Attributes;

namespace VB.Movie.Domain.Common
{
    public abstract class BaseEntity
    {
        [BsonId]
        public Guid Id { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
