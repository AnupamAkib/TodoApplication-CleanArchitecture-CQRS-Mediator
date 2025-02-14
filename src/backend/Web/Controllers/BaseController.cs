#nullable disable
using Microsoft.AspNetCore.Mvc;

namespace TodoApp.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class BaseController : ControllerBase
{
    private IMediator _mediator;

    protected IMediator Mediator => 
        _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}
