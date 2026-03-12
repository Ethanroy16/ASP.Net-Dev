using Microsoft.EntityFrameworkCore;
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
        private readonly GolfDBContext _dbContext; 

        public ShoppingCartRepo(GolfDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public ShoppingCart IncrementItem(string userId, int id)
        {
            var ShoppingCartItem = _dbContext.ShoppingCarts.Where(p => p.GolfBallId == id && p.ApplicationUserId == userId).FirstOrDefault();

            return ShoppingCartItem;
        }

        public int IncrementQty(ShoppingCart shoppingCart, int qty)
        {
            shoppingCart.Quantity += qty;
            _dbContext.SaveChanges();
            return shoppingCart.Quantity;
        }

        public IEnumerable<ShoppingCart> GetShoppingCartProduct(string userId)
        {
            var ShoppingCartItem = _dbContext.ShoppingCarts.Where(u => u.ApplicationUserId == userId).Include(p => p.GolfBall).ThenInclude(b => b.Brand);
            return ShoppingCartItem;
        }

        public void RemoveAll(IEnumerable<ShoppingCart> items)
        {
            _dbContext.RemoveRange(items);
            _dbContext.SaveChanges();
        }

        public int DecrementQty(ShoppingCart shoppingCart, int qty)
        {
            shoppingCart.Quantity -= qty;
            _dbContext.SaveChanges();
            return shoppingCart.Quantity;
        }
    }
}
