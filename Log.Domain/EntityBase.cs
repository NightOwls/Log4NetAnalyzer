
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Log.Domain
{
    public abstract class EntityBase : IEntity
    {
        public virtual ObjectId Id { get; set; }
    }
}
