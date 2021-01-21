using ApiMediator.App.Infrastructure.Data.Context;
using SimpleSoft.Mediator;
using System.Threading;
using System.Threading.Tasks;

namespace ApiMediator.App.Domain.Product.Handlers.Commands
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        private readonly ApiDbContext context;

        public CreateProductCommandHandler(ApiDbContext context)
        {
            this.context = context;
        }

        public async Task<CreateProductResult> HandleAsync(CreateProductCommand cmd, CancellationToken ct)
        {
            var product = new Model.Product(cmd.Name, cmd.Price);

            await context.Products.AddAsync(product, ct);

            await context.SaveChangesAsync(ct);

            return new CreateProductResult()
            {
                Id = product.Id
            };
        }
    }
}
