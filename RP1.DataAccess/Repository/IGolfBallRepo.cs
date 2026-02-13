using MyProject_L00181476.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP1.DataAccess.Repository
{
    public interface IGolfBallRepo : IRepository<GolfBall>
    {

        public void Update(GolfBall golfBall);
    }
}
