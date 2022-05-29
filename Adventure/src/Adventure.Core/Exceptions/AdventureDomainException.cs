namespace Adventure.Core.Exceptions;

public class AdventureDomainException : Exception
{
  public AdventureDomainException()
  {
  }

  public AdventureDomainException(string message)
    : base(message)
  {
  }

  public AdventureDomainException(string message, Exception innerException)
    : base(message, innerException)
  {
  }
}
