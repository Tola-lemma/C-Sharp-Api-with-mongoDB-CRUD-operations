using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace projectOneWithMongo.Services
{
    public class TodoItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        //changing the default serialization
        [BsonElement("task")]
        public string task { get; set; }
        [BsonElement("completed")]
        public bool completed { get; set; }
        [BsonElement("userID")]
        public string userID { get; set; }
    }
}
