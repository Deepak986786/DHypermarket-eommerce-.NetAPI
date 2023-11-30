using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
public class Product
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
    public string Thumbnail { get; set; }
    public string Brand { get; set; }
    public int Stock { get; set; }
    public decimal Rating { get; set; }
    public List<string> Images { get; set; }


}