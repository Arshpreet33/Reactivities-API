using Application.Profiles;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  public class ProfilesController : BaseAPIController
  {

    [HttpGet("{username}")]
    public async Task<IActionResult> GetProfile(string username)
    {
      return HandleResult(await Mediator.Send(new Details.Query { Username = username }));
    }

    [HttpPut]
    public async Task<IActionResult> EditProfile(Profile profile)
    {
      return HandleResult(await Mediator.Send(new Edit.Command { Profile = profile }));
    }

    [HttpGet("{username}/activities")]
    public async Task<IActionResult> GetProfileEvents(string username, string predicate)
    {
      return HandleResult(await Mediator.Send(new ListActivities.Query { Predicate = predicate, Username = username }));
    }

  }
}