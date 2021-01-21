using ApiMediator.App.Infrastructure.Data.Context;
using SimpleSoft.Mediator;
using System.Threading;
using System.Threading.Tasks;

namespace ApiMediator.App.Domain.Product.Handlers.Commands
{
    public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, Model.Product>
    {
        private readonly ApiDbContext context;

        public UpdateProductCommandHandler(ApiDbContext context)
        {
            this.context = context;
        }

        public async Task<Model.Product> HandleAsync(UpdateProductCommand cmd, CancellationToken ct)
        {
            var product = await context.Products.FindAsync(cmd.Id);

            product.Name = cmd.Name;
            
            product.Price = cmd.Price;

            context.Update(product);

            await context.SaveChangesAsync(ct);

            return product;
        }
    }
}
