using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProject_L00181476.DataAccess;
using MyProject_L00181476.Models.Models;
using RP1.DataAccess.Repository;
using RP1.Services;

namespace MyProject_L00181476.Pages.Admin.Brands
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Brand Brand { get; set; }

        public void OnGet(int id)
        {
            Brand = _unitOfWork.BrandRepo.Get(id);
        }

        public IActionResult OnPost()
        {
            // Use the bound Id to fetch the tracked entity, then delete.
            var entity = _unitOfWork.BrandRepo.Get(Brand?.Id ?? 0);
            if (entity == null)
            {
                return NotFound();
            }

            _unitOfWork.BrandRepo.Delete(entity);
            _unitOfWork.Save();

            return RedirectToPage("/Admin/Brands/Brands");
        }
    }
}
