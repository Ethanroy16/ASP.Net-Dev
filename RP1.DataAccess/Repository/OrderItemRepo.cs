using MyProject_L00181476.DataAccess;
using RP1.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP1.DataAccess.Repository
{
    public class OrderItemRepo : Repository<OrderItem>, IOrderItemRepo
    {
        private readonly GolfDBContext _dbContext;

        public OrderItemRepo(GolfDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
    
}
