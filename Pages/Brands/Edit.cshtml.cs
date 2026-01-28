using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProject_L00181476.DataAccess;
using MyProject_L00181476.Models;

namespace MyProject_L00181476.Pages.Brands
{
    public class EditModel : PageModel
    {
        private readonly GolfDBContext _dbcontext;

        public EditModel(GolfDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [BindProperty]
        public Brand Brand { get; set; } = new();

        public void OnGet(int id)
        {
            Brand = _dbcontext.Brands.Find(id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _dbcontext.Brands.Update(Brand);
            await _dbcontext.SaveChangesAsync();

            return RedirectToPage("Brands");
        }
    }
}
