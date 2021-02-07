using System;

namespace ApiMediator.App.Domain.Product.Handlers.Events
{
    public class CreatedProductEvent : SimpleSoft.Mediator.Event
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
