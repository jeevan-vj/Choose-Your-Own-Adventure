using Adventure.Web.Commands;
using Adventure.Web.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Adventure.Web.Api;

public class AdventureController : BaseApiController
{
  private readonly IMediator _mediator;

  public AdventureController(IMediator mediator)
  {
    _mediator = mediator;
  }

  [HttpGet]
  [Route("{adventureId}")]
  public async Task<IActionResult> Get(string adventureId)
  {
    var query = new GetAdventureByIdQuery(adventureId);
    var result = await _mediator.Send(query);

    return Ok(result);
  }

  [HttpGet]
  [Route("list-all")]
  //[Authorize]
  public async Task<IActionResult> List()
  {
    var query = new GetAllAdventuresQuery();
    var result = await _mediator.Send(query);

    return Ok(result);
  }

  [HttpPost]
  [Route("create-adventure")]
  public async Task<IActionResult> Post([FromBody] CreateAdventureCommand request)
  {
    var commandResult = await _mediator.Send(request);
    return Ok(commandResult);
  }

  [HttpPut]
  [Route("update-adventure")]
  public async Task<IActionResult> Put([FromBody] UpdateAdventureCommand request)
  {
    var commandResult = await _mediator.Send(request);
    return Ok(commandResult);
  }

  [HttpPost]
  [Route("take-adventure")]
  [Authorize]
  public async Task<IActionResult> Post([FromBody] CreateUserAdventureCommand request)
  {
    request.UserId = GetUserId();
    var commandResult = await _mediator.Send(request);
    return Ok(commandResult);
  }

  [HttpGet]
  [Route("my-adventures")]
  [Authorize]
  public async Task<IActionResult> Get()
  {
    var query = new GetMyAdventuresQuery(1);
    var result = await _mediator.Send(query);

    return Ok(result);
  }

  [HttpGet]
  [Route("my-adventure/{adventureId}")]
  [Authorize]
  public async Task<IActionResult> GetMyAdventureById(string adventureId)
  {
    var query = new GetMyAdventureByIdQuery(adventureId);
    var result = await _mediator.Send(query);

    return Ok(result);
  }
}
