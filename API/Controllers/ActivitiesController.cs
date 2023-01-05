using Application.Activities;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ActivitiesController : BaseApiController
{
    [HttpGet] //api/activities
    public async Task<IActionResult> GetActivities()
    {
        var result = await Mediator.Send(new List.Query());
        return HandleResult(result);
    }

    [HttpGet("{id}")] //api/activities/guid_of-activity
    public async Task<IActionResult> GetActivity(Guid id)
    {
        var result = await Mediator.Send(new Details.Query { Id = id });
        return HandleResult(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateActivity( /*[FromBody]*/ Activity activity)
    {
        // Bc of the [ApiController] attribute inside the BaseApiController class the
        // method will look inside of the body of the request and get the activity argument.
        var result = await Mediator.Send(new Create.Command { Activity = activity });
        return HandleResult(result);
    }

    [HttpPut("{id}")] //api/activities/guid_of-activity
    public async Task<IActionResult> EditActivity(Guid id, Activity activity)
    {
        activity.Id = id;
        var result = await Mediator.Send(new Edit.Command { Activity = activity });
        return HandleResult(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteActivity(Guid id)
    {
        var result = await Mediator.Send(new Delete.Command{Id = id});
        return HandleResult(result);
    }

}