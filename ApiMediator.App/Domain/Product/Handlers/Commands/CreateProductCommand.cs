using SimpleSoft.Mediator;
using System;

namespace ApiMediator.App.Domain.Product.Handlers.Commands
{
    public class CreateProductCommand : Command<CreateProductResult>
    {
        public CreateProductCommand(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class CreateProductResult
    {
        public Guid Id { get; set; }
    }
}
