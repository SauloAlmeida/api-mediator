using ApiMediator.Core.Base.Handlers;
using System;

namespace ApiMediator.App.Domain.Product.Handlers.Commands
{
    public class DeleteProductCommand : Command
    {
        public DeleteProductCommand(Guid productId)
        {
            ProductId = productId;
        }

        public Guid ProductId { get; set; }
    }
}
