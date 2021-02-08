using ApiMediator.App.Infrastructure.AppSettings;
using LiteDB;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace ApiMediator.App.Infrastructure.Data.EventContext
{
    public class EventContext : IEventContext
    {
        private readonly LiteDatabase eventContext;

        public EventContext(IOptions<ConnectionStrings> connStringOptions) => eventContext = new LiteDatabase(@connStringOptions.Value.Event);

        public IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class => eventContext.GetCollection<TEntity>(nameof(TEntity)).FindAll();

        public void Add<TEntity>(TEntity entity) where TEntity : class => eventContext.GetCollection<TEntity>(nameof(TEntity)).Insert(entity);       
    }
}
