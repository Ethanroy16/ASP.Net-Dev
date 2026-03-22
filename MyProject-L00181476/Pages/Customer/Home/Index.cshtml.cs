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
                // Find brand ids that match the search string (case-insensitive)
                var matchingBrandIds = listOfBrands
                    .Where(b => b.BrandName != null && b.BrandName.Contains(SearchString, StringComparison.OrdinalIgnoreCase))
                    .Select(b => b.Id)
                    .ToHashSet();

                // Filter golf balls by product name or by matching brand id
                listOfGolfBalls = listOfGolfBalls.Where(g =>
                    (!string.IsNullOrEmpty(g.Name) && g.Name.Contains(SearchString, StringComparison.OrdinalIgnoreCase))
                    || matchingBrandIds.Contains(g.BrandId));
            }
        }
    }
}
