using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CSVApplication.Core.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        public List<TEntity> GetAll();
        public TEntity GetById(int id);

        public TEntity GetByExpression(Expression<Func<TEntity, bool>> expr);

        public TEntity Create(TEntity record);

        public TEntity Update(TEntity record);

        public void Delete(TEntity record);

    }
}
