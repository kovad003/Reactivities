using Application.Activities;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ActivitiesController : BaseApiController
{
    [HttpGet] //api/activities
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        return await Mediator.Send(new List.Query());
    }
    // public async Task<ActionResult<List<Activity>>> GetActivities(CancellationToken ct)
    // {
    //     return await Mediator.Send(new List.Query(), ct);
    // }

    [HttpGet("{id}")] //api/activities/guid_of-activity
    public async Task<ActionResult<Activity>> GetActivity(Guid id)
    {
        return await Mediator.Send(new Details.Query { Id = id });
    }

    [HttpPost]
    public async Task<IActionResult> CreateActivity( /*[FromBody]*/ Activity activity)
    {
        // Bc of the [ApiController] attribute inside the BaseApiController class the
        // method will look inside of the body of the request and get the activity argument.
        return Ok(await Mediator.Send(new Create.Command { Activity = activity }));
    }

    [HttpPut("{id}")] //api/activities/guid_of-activity
    public async Task<IActionResult> EditActivity(Guid id, Activity activity)
    {
        activity.Id = id;
        return Ok(await Mediator.Send(new Edit.Command { Activity = activity }));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteActivity(Guid id)
    {
        return Ok(await Mediator.Send(new Delete.Command{Id = id}));
    }

}