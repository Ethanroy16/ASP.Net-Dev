using MyProject_L00181476.DataAccess;
using RP1.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP1.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GolfDBContext _dbContext;
        
        public IBrandRepo BrandRepo { get; private set;  }
        
        public UnitOfWork(GolfDBContext dbContext)
        {
            _dbContext = dbContext;
            BrandRepo = new BrandRepo(_dbContext);
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
