
namespace Log.Domain
{
    public class SimpleAggregate 
    {
        public AggregateId Id { get; set; }
    
        public int Count { get; set; }
    }

    public class AggregateId
    {
        public string GroupItem { get; set; }
    }
}
