using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProject_L00181476.Models.Models;
using RP1.Services;

namespace MyProject_L00181476.Pages.Admin.GolfBalls
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<GolfBall> GolfBall;
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
            GolfBall = _unitOfWork.GolfBallRepo.GetAll();
        }
    }
}
