using System.ComponentModel;

namespace Adven.Web.ApiModels;

public record LoginDto
{
  [DefaultValue("advenuser")]
  public string UserName { get; init; } = null!;

  [DefaultValue("SuperStrongPassword")]
  public string Password { get; init; }
}
