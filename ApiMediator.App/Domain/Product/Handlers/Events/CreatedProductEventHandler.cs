using ApiMediator.App.Domain.Product.Handlers.Events._base;
using ApiMediator.App.Infrastructure.Data.EventContext;
using SimpleSoft.Mediator;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ApiMediator.App.Domain.Product.Handlers.Events
{
    public class CreatedProductEventHandler : IEventHandler<CreatedProductEvent>
    {
        private readonly ApiEventContext eventContext;

        public CreatedProductEventHandler(ApiEventContext eventContext) => this.eventContext = eventContext;

        public async Task HandleAsync(CreatedProductEvent evt, CancellationToken ct)
        {
            var productEvent = new ProductEvent()
            {
                ProdutId = evt.ProductId,
                Name = nameof(CreatedProductEvent),
                Payload = JsonSerializer.Serialize(evt),
                CreatedOn = evt.CreatedOn,
                CreatedBy = evt.CreatedBy
            };

            await Task.Run(() => eventContext.Add(productEvent), ct);
        }
    }
}
