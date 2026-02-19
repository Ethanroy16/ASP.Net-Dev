using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProject_L00181476.Models.Models;
using RP1.Services;

namespace MyProject_L00181476.Pages.Customer.Home
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<GolfBall> listOfGolfBalls { get; set; }
        public IEnumerable<Brand> listOfBrands { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public void OnGet()
        {
            listOfGolfBalls = _unitOfWork.GolfBallRepo.GetAll();
            listOfBrands = _unitOfWork.BrandRepo.GetAll();
                if (!string.IsNullOrEmpty(SearchString))
                {
                    listOfGolfBalls = listOfGolfBalls.Where(g => g.Name.Contains(SearchString, StringComparison.OrdinalIgnoreCase));
            }
        }
    }
}
