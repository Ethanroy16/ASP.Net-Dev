using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProject_L00181476.DataAccess;
using MyProject_L00181476.Models;

namespace MyProject_L00181476.Pages.Brands
{
    public class CreateModel : PageModel
    {
        private readonly GolfDBContext _dbcontext;

        public CreateModel(GolfDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [BindProperty]
        public Brand Brand { get; set; } = new();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _dbcontext.Brands.AddAsync(Brand);
            await _dbcontext.SaveChangesAsync();

            return RedirectToPage("Brands");
        }
    }
}
