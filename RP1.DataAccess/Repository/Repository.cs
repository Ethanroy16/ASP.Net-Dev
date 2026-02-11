using Microsoft.EntityFrameworkCore;
using MyProject_L00181476.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP1.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly GolfDBContext _dbContext;
        internal DbSet<T> dbSet;
        public Repository(GolfDBContext dbContext)
        {
            _dbContext = dbContext;
            this.dbSet = _dbContext.Set<T>();
        }

        public void Add(T obj)
        {
            dbSet.Add(obj);
        }

        public void Update(T obj)
        {
            dbSet.Update(obj);
        }

        public void Delete(T obj)
        {
            dbSet.Remove(obj);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> list = dbSet;
            return list.ToList();
        }

        public T? Get(int id)
        {
            if (id == 0)
                return null;
            else return dbSet.Find(id);
        }
    }
}
