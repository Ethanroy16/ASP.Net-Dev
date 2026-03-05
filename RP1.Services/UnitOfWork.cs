using MyProject_L00181476.DataAccess;
using RP1.DataAccess.Repository;
using RP1.Services;
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
        public IGolfBallRepo GolfBallRepo { get; private set; }

        public IApplicationUserRepo ApplicationUserRepo {  get; private set; }
        public IOrderRepo OrderRepo { get; private set; }
        public IOrderItemRepo OrderItemRepo { get; private set; }
        public IShoppingCartRepo ShoppingCartRepo { get; private set; }

        public UnitOfWork(GolfDBContext dbContext)
        {
            _dbContext = dbContext;
            BrandRepo = new BrandRepo(_dbContext);
            GolfBallRepo = new GolfBallRepo(_dbContext);
            ApplicationUserRepo = new ApplicationUserRepo(_dbContext);
            OrderRepo = new OrderRepo(_dbContext);
            OrderItemRepo = new OrderItemRepo(_dbContext);
            ShoppingCartRepo = new ShoppingCartRepo(_dbContext);
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
