using RP1.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP1.Services
{
    public interface IUnitOfWork :IDisposable
    {
        IBrandRepo BrandRepo { get; }
        void Save();

        IGolfBallRepo GolfBallRepo { get; }

        IOrderRepo OrderRepo { get; }
        IOrderItemRepo OrderItemRepo { get; }
        IApplicationUserRepo ApplicationUserRepo { get; }
        IShoppingCartRepo ShoppingCartRepo { get; }
    }

}
