using RP1.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP1.DataAccess.Repository
{
    public interface IShoppingCartRepo : IRepository<ShoppingCart>
    {
            ShoppingCart IncrementItem(string userId, int id);

        int IncrementQty(ShoppingCart shoppingCart, int qty);

        IEnumerable<ShoppingCart> GetShoppingCartProduct(string userId);

        void RemoveAll(IEnumerable<ShoppingCart> items);

        int DecrementQty(ShoppingCart shoppingCart, int qty);
    }
}
