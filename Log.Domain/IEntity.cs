
using MongoDB.Bson;

namespace Log.Domain
{
    public interface IEntity
    {
        ObjectId Id { get; set; } 
    }
}
