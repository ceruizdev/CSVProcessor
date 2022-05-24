using CSVApplication.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CSVApplication.DataAccess.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly AppContextDB context;
        public Repository(AppContextDB _context)
        {
            context = _context;
        }
        public TEntity Create(TEntity record)
        {
            context.Set<TEntity>().Add(record);
            context.SaveChanges();
            context.Entry(record).State = EntityState.Detached;
            return record;
        }

        public void Delete(TEntity record)
        {
            context.Set<TEntity>().Remove(record);
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public List<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public TEntity? GetByExpression(Expression<Func<TEntity, bool>> expr)
        {
            return context.Set<TEntity>().FirstOrDefault(expr);
        }

        public TEntity GetById(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public TEntity Update(TEntity record)
        {
            context.Set<TEntity>().Update(record);
            context.SaveChanges();
            context.Entry(record).State = EntityState.Detached;
            return record;
        }
    }
}
