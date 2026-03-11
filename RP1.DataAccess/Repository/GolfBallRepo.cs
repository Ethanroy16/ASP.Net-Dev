using MyProject_L00181476.DataAccess;
using MyProject_L00181476.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP1.DataAccess.Repository
{
    public class GolfBallRepo : Repository<GolfBall>, IGolfBallRepo
    {

        private readonly GolfDBContext _dbContext;
        public GolfBallRepo(GolfDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public void Update(GolfBall golfBall)
        {
            var GolfFromDB = _dbContext.GolfBalls.
                FirstOrDefault(GolfFromDB => GolfFromDB.Id == golfBall.Id);
            GolfFromDB.Name = golfBall.Name;
            GolfFromDB.BrandId = golfBall.BrandId;
            if (golfBall.ImageUrl != null)
            {
                GolfFromDB.ImageUrl = golfBall.ImageUrl;
            }
        }

        GolfBall IGolfBallRepo.GetGolfBallByName(string name)
        {
            if (name == "")
                return null;
            else
                return _dbContext.GolfBalls.Where(g => g.Name == name).FirstOrDefault();
        }
    }
}
