using ApiMediator.App.Infrastructure.Data.Context;
using SimpleSoft.Mediator;
using System.Threading;
using System.Threading.Tasks;

namespace ApiMediator.App.Domain.Product.Handlers.Commands
{
    public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand>
    {
        private readonly DatabaseContext context;

        public DeleteProductCommandHandler(DatabaseContext context) => this.context = context;

        public async Task HandleAsync(DeleteProductCommand cmd, CancellationToken ct)
        {
            context.Remove(await context.Products.FindAsync(cmd.ProductId));

            await context.SaveChangesAsync(ct);
        }
    }
}
