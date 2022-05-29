using Adventure.SharedKernel.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Adventure.Core.Models;

public class AdventureItem : IAggregateRoot
{
  public string Name { get; set; } = string.Empty;
  public string Title { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public Choice Choice { get; set; }

  [BsonId]
  [BsonRepresentation(BsonType.ObjectId)]
  public string? Id { get; set; }
}

public class Choice
{
  public Choice(string title, string? id = null)
  {
    Title = title;
    Id = id ?? ObjectId.GenerateNewId().ToString();
  }

  [BsonId]
  [BsonRepresentation(BsonType.ObjectId)]
  public string? Id { get; set; }

  public string? SelectedOptionId { get; set; }
  public string Title { get; set; } = string.Empty;

  public List<Option>? Options { get; set; }
}

public class Option
{
  public Option(string title, Choice next, string? id = null)
  {
    Title = title;
    Next = next;
    Id = id ?? ObjectId.GenerateNewId().ToString();
  }

  [BsonId]
  [BsonRepresentation(BsonType.ObjectId)]
  public string? Id { get; set; }

  public string Title { get; set; }
  public Choice? Next { get; set; }
}
