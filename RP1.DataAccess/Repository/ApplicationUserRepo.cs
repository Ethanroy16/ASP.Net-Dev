using MyProject_L00181476.DataAccess;
using RP1.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP1.DataAccess.Repository
{
    public class ApplicationUserRepo : Repository<ApplicationUser>, IApplicationUserRepo
    {
        private readonly GolfDBContext _dbContext;
        public ApplicationUserRepo(GolfDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public ApplicationUser Get(string s)
        {
            if (s == "")
                return null;
            else
                return _dbContext.ApplicationUsers.Where(a => a.Id == s).FirstOrDefault();
        }
    }
}
