using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseApiController : ControllerBase
{
    private IMediator _mediator;
    
    // ??=  ...if the _mediator field is null then assign the
    // statement on the right to the Mediator property.
    protected IMediator Mediator => _mediator ??=
        HttpContext.RequestServices.GetService<IMediator>();
}