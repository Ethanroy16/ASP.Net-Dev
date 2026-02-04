using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProject_L00181476.DataAccess;
using MyProject_L00181476.Models;

namespace MyProject_L00181476.Pages.Brands
{
    public class DeleteModel : PageModel
    {
        private readonly GolfDBContext _dbcontext;

        public DeleteModel(GolfDBContext dbcontext)
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
            var entity = await _dbcontext.Brands.FindAsync(Brand.Id);
            if (entity == null)
            {
                return NotFound();
            }

            _dbcontext.Brands.Remove(entity);
            await _dbcontext.SaveChangesAsync();
            return RedirectToPage("Brands");
        }
    }
}
