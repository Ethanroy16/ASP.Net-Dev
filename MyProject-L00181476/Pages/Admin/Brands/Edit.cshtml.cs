using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProject_L00181476.DataAccess;
using MyProject_L00181476.Models.Models;
using RP1.DataAccess.Repository;
using RP1.Services;

namespace MyProject_L00181476.Pages.Admin.Brands
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Brand Brand { get; set; }

        public void OnGet(int id)
        {
            Brand = _unitOfWork.BrandRepo.Get(id);
        }

        public IActionResult OnPost(Brand brand)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.BrandRepo.Update(brand);
                _unitOfWork.Save();
            }
            return RedirectToPage("Brands");
        }
    }
}
