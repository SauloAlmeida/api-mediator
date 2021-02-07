using ApiMediator.App.Domain.Product.Handlers.Events._base;
using ApiMediator.App.Infrastructure.Data.EventContext;
using ApiMediator.Core.Base.Controller;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ApiMediator.App.Domain.Event.Controller
{
    public class EventController : BaseController
    {
        private readonly ApiEventContext eventContext;

        public EventController(ApiEventContext eventContext)
        {
            this.eventContext = eventContext;
        }

        [HttpGet("Product")]
        public IActionResult Get()
        {
            var response = eventContext.GetAll<ProductEvent>();

            var result = response.Select(s => new
            {
                Id = s.Id.Increment,
                Payload = System.Text.Json.JsonSerializer.Deserialize<object>(s.Payload),
                s.CreatedOn,
                s.CreatedBy
            });

            return Ok(result);
        }
    }
}
