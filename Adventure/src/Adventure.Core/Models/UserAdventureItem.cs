using Adventure.SharedKernel.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Adventure.Core.Models;

public class UserAdventureItem : IAggregateRoot
{
  public int UserId { get; set; }
  public AdventureItem Adventure { get; set; }

  [BsonId]
  [BsonRepresentation(BsonType.ObjectId)]
  public string? Id { get; set; }
}
