using SimpleSoft.Mediator;
using System;

namespace ApiMediator.App.Domain.Product.Handlers.Commands
{
    public class UpdateProductCommand : Command<Model.Product>
    {
        public UpdateProductCommand(Guid id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
