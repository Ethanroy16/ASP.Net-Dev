using Microsoft.EntityFrameworkCore;
using MyProject_L00181476.DataAccess;
using RP1.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP1.DataAccess.Repository
{
    public class ShoppingCartRepo : Repository<ShoppingCart>, IShoppingCartRepo
    {
        public ShoppingCart ImplementItem(string userId, int id)
        {
            var ShoppingCartItem = DbContext.ShoppingCarts.Where(p => p.GolfBallId == id && p.ApplicationUserId == userId).FirstOrDefault();

            return ShoppingCartItem;
        }

        public int IncrementQty(ShoppingCart shoppingCart, int qty)
        {
            shoppingCart.Quantity += qty;
            _dbContext.SaveChanges();
            return shoppingCart.Quantity;
        }
    }
}
