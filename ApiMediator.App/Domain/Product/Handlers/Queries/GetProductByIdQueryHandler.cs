using ApiMediator.App.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using SimpleSoft.Mediator;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiMediator.App.Domain.Product.Handlers.Queries
{
    public class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, Model.Product>
    {
        private readonly IQueryable<Model.Product> products;

        public GetProductByIdQueryHandler(ApiDbContext context)
        {
            products = context.Products;
        }

        public async Task<Model.Product> HandleAsync(GetProductByIdQuery query, CancellationToken ct)
        {
            var product = await products.AsNoTracking().FirstOrDefaultAsync(w => w.Id == query.ProductId);

            // todo - Notify

            return product;
        }
    }
}
