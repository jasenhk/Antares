using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Antares.Data
{
    public abstract class GenericRepository<TEntity> where TEntity : class
    {
        protected UsersContext Context;

        public GenericRepository(IUnitOfWork unitOfWork)
        {
            this.Context = unitOfWork.Context;
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();
            return query;
        }

        public virtual IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>().Where(predicate);
            return query;
        }

        public virtual TEntity Add(TEntity entity)
        {
            return Context.Set<TEntity>().Add(entity);
        }
    }
}
