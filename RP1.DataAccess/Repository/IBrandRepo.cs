using MyProject_L00181476.DataAccess;
using MyProject_L00181476.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP1.DataAccess.Repository
{
    public interface IBrandRepo : IRepository<Brand>
    {
        void SaveAll();
    }

    public class BrandRepo : Repository<Brand>, IBrandRepo
    {
        private readonly GolfDBContext _dbContext;
        public BrandRepo(GolfDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public void SaveAll()
        {
            _dbContext.SaveChanges();
        }
    }

}
