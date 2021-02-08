using ApiMediator.App.Domain.Product.Handlers.Events._base;
using ApiMediator.App.Infrastructure.Data.EventContext;
using ApiMediator.Core.Base.Controller;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.Json;

namespace ApiMediator.App.Domain.Event.Controller
{
    public class EventController : BaseController
    {
        private readonly IEventContext eventContext;

        public EventController(IEventContext eventContext)
        {
            this.eventContext = eventContext;
        }

        [HttpGet("Product")]
        public IActionResult Get()
        {
            var result = eventContext.GetAll<ProductEvent>()
                                     .Select(s => new
                                     {
                                         Id = s.Id.Increment,
                                         Payload = JsonSerializer.Deserialize<object>(s.Payload)
                                     });

            return Ok(result);
        }
    }
}
