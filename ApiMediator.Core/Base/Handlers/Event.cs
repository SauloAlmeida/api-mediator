using System;

namespace ApiMediator.Core.Base.Handlers
{
    public abstract class Event<T> : SimpleSoft.Mediator.Event
        where T : class
    {
        public string Name { get; set; }
        public Guid EntityId { get; set; }
        public string Payload { get; set; }
    }
}
