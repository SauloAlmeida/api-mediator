using ApiMediator.App.Domain.Product.Handlers.Events;
using ApiMediator.App.Infrastructure.Data.Context;
using SimpleSoft.Mediator;
using System.Threading;
using System.Threading.Tasks;

namespace ApiMediator.App.Domain.Product.Handlers.Commands
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        private readonly ApiDbContext context;
        private readonly IMediator mediator;

        public CreateProductCommandHandler(ApiDbContext context, IMediator mediator)
        {
            this.context = context;
            this.mediator = mediator;
        }

        public async Task<CreateProductResult> HandleAsync(CreateProductCommand cmd, CancellationToken ct)
        {
            var product = new Model.Product(cmd.Name, cmd.Price);

            await context.Products.AddAsync(product, ct);

            var evt = new CreatedProductEvent()
            {
                ProductId = product.Id,
                Name = product.Name,
                Price = product.Price
            };

            await mediator.BroadcastAsync(evt, ct);

            await context.SaveChangesAsync(ct);

            return new CreateProductResult()
            {
                Id = product.Id
            };
        }
    }
}
