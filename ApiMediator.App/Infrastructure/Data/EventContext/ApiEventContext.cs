using ApiMediator.App.Infrastructure.AppSettings;
using LiteDB;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace ApiMediator.App.Infrastructure.Data.EventContext
{
    public class ApiEventContext
    {
        private readonly LiteDatabase eventContext;

        public ApiEventContext(IOptions<ConnectionStrings> connStringOptions) => eventContext = new LiteDatabase(@connStringOptions.Value.Event);

        public void Add<TEntity>(TEntity entity) where TEntity : class => eventContext.GetCollection<TEntity>(nameof(TEntity)).Insert(entity);

        public IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class => eventContext.GetCollection<TEntity>(nameof(TEntity)).FindAll();
    }
}
