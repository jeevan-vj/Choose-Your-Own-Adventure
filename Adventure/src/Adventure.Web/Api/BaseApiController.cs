using Microsoft.AspNetCore.Mvc;

namespace Adventure.Web.Api;

[Route("api/[controller]")]
[ApiController]
public abstract class BaseApiController : Controller
{
  protected int GetUserId()
  {
    return int.Parse(this.User.Claims.First(i => i.Type == "UserId").Value);
  }
}
