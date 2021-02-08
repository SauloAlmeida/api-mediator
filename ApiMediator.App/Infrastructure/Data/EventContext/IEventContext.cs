using System.Collections.Generic;

namespace ApiMediator.App.Infrastructure.Data.EventContext
{
    public interface IEventContext
    {
        IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class;

        void Add<TEntity>(TEntity entity) where TEntity : class;
    }
}
