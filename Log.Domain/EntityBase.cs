
using MongoDB.Bson;

namespace Log.Domain
{
    public abstract class EntityBase : IEntity
    {
        public ObjectId Id { get; set; }
    }
}
