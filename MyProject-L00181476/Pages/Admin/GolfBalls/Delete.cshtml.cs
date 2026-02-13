using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProject_L00181476.Models.Models;
using RP1.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProject_L00181476.Models.Models;
using RP1.Services;
using System.IO;

namespace MyProject_L00181476.Pages.Admin.GolfBalls
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;

        public DeleteModel(IUnitOfWork unitOfWork, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _env = env;
        }

        [BindProperty]
        public GolfBall GolfBall { get; set; } = new();

        public void OnGet(int id)
        {
            GolfBall = _unitOfWork.GolfBallRepo.Get(id);
        }

        public IActionResult OnPost()
        {
            var entity = _unitOfWork.GolfBallRepo.Get(GolfBall.Id);
            if (entity == null) return NotFound();

            // delete image file if exists
            if (!string.IsNullOrEmpty(entity.ImageUrl))
            {
                try
                {
                    var filePath = Path.Combine(_env.WebRootPath, entity.ImageUrl.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
                    if (System.IO.File.Exists(filePath)) System.IO.File.Delete(filePath);
                }
                catch { /* ignore file deletion errors */ }
            }

            _unitOfWork.GolfBallRepo.Delete(entity);
            _unitOfWork.Save();

            return RedirectToPage("Index");
        }
    }
}