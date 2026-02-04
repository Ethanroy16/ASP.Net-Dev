using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProject_L00181476.DataAccess;
using MyProject_L00181476.Models;

namespace MyProject_L00181476.Pages.Brands
{
    public class BrandsModel : PageModel
    {
        private readonly GolfDBContext _dbcontext;

        // Exposed public property for the Razor view to bind to
        public IEnumerable<Brand> Brands { get; private set; } = Enumerable.Empty<Brand>();

        public BrandsModel(GolfDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void OnGet()
        {
            // Materialize the query to a list so the view can iterate safely
            Brands = _dbcontext.Brands;
        }
    }
}
