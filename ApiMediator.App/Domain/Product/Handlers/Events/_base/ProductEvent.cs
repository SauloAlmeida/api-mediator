using LiteDB;
using System;

namespace ApiMediator.App.Domain.Product.Handlers.Events._base
{
    public class ProductEvent
    {
        [BsonId]
        public ObjectId Id { get; set; } = ObjectId.NewObjectId();
        public Guid ProdutId { get; set; }
        public string Name { get; set; }
        public string Payload { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}
