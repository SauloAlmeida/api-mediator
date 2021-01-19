using Microsoft.AspNetCore.Mvc;

namespace ApiMediator.Core.Base.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
    }
}
