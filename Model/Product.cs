using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
public class Product
{   
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public string Category { get; set; }
}