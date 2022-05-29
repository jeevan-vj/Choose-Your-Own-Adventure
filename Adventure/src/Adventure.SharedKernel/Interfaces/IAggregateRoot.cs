using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Adventure.SharedKernel.Interfaces;

public interface IAggregateRoot
{
  [BsonId]
  [BsonRepresentation(BsonType.ObjectId)]
  public string? Id { get; set; }
}
