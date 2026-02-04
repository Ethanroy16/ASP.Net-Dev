using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProject_L00181476.DataAccess;
using MyProject_L00181476.Models.Models;
using RP1.DataAccess.Repository;

namespace MyProject_L00181476.Pages.Admin.Brands
{
    public class BrandsModel : PageModel
    {
        private readonly IBrandRepo _dbcontext;

        // Exposed public property for the Razor view to bind to
        public IEnumerable<Brand> Brands;

        public BrandsModel(IBrandRepo brandRepo)
        {
            _dbcontext = brandRepo;
        }

        public void OnGet()
        {
            // Materialize the query to a list so the view can iterate safely
            Brands = _dbcontext.GetAll();
        }
    }
}
