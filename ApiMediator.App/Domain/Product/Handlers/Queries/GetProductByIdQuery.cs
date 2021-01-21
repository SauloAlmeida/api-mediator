using SimpleSoft.Mediator;
using System;

namespace ApiMediator.App.Domain.Product.Handlers.Queries
{
    public class GetProductByIdQuery : Query<Model.Product>
    {
        public GetProductByIdQuery(Guid id)
        {
            ProductId = id;
        }

        public Guid ProductId { get; set; }
    }
}
