using ApiMediator.App.Infrastructure.AppSettings;
using LiteDB;
using Microsoft.Extensions.Options;

namespace ApiMediator.App.Infrastructure.Data.EventContext
{
    public class ApiEventContext
    {
        private readonly LiteDatabase eventContext;

        public ApiEventContext(IOptions<ConnectionStrings> connStringOptions)
        {
            eventContext = new LiteDatabase(@connStringOptions.Value.Event);
        }

        public void Add<TEntity>(TEntity entity)
            where TEntity : class
        {
            ILiteCollection<TEntity> collection = eventContext.GetCollection<TEntity>(nameof(TEntity));

            collection.Insert(entity);
        }
    }
}
