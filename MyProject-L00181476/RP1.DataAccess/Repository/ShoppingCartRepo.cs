using Microsoft.EntityFrameworkCore; // Removed duplicate using directive
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
            // Use the navigation property to avoid relying on a ShoppingCarts.GolfBallId column
            // (some database schemas may not expose the FK column with that exact name).
            var shoppingCartItem = _dbContext.ShoppingCarts
                .Include(s => s.GolfBall)
                .Where(p => p.GolfBall != null && p.GolfBall.Id == id && p.ApplicationUserId == userId)
                .FirstOrDefault();

            return shoppingCartItem;
        }

        public int IncrementQty(ShoppingCart shoppingCart, int qty)
        {
            shoppingCart.Quantity += qty;
            _dbContext.SaveChanges();
            return shoppingCart.Quantity;
        }
    }
}
