using RP1.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP1.DataAccess.Repository
{
    public interface IOrderRepo : IRepository<Order>
    {
            public void Update(Order order);
    }
}
