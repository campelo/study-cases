using MongoDB.Bson.Serialization.Attributes;

namespace Testcontainer
{
    public class Animal
    {
        [BsonId]
        public string Id { get; set; } = System.Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Type { get; set; }
    }
}