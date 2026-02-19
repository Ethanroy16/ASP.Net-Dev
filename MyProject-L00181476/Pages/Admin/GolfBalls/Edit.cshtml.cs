using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyProject_L00181476.Models.Models;
using RP1.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject_L00181476.Pages.Admin.GolfBalls
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EditModel(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        [BindProperty]
        public GolfBall GolfBall { get; set; }

        public IEnumerable<SelectListItem> BrandsList { get; set; }

        public void OnGet(int id)
        {
            GolfBall = _unitOfWork.GolfBallRepo.Get(id);
            BrandsList = _unitOfWork.BrandRepo.GetAll().Select(b => new SelectListItem()
            {
                Value = b.Id.ToString(),
                Text = b.BrandName
            });
        }

        public IActionResult OnPost()
        {
            string wwwRootFolder = _webHostEnvironment.WebRootPath ?? "";
            var files = HttpContext.Request.Form.Files;
            var golfFromDB = _unitOfWork.GolfBallRepo.Get(GolfBall.Id);

            // Ensure we preserve existing image when user doesn't upload a new one
            if (files.Count > 0 && files[0] != null && files[0].Length > 0)
            {
                string newFileName = Guid.NewGuid().ToString();
                var uploadFolder = Path.Combine(wwwRootFolder, "images", "golfballs");
                Directory.CreateDirectory(uploadFolder);

                var extension = Path.GetExtension(files[0].FileName) ?? "";

                // Delete old file if any and if referenced
                if (!string.IsNullOrWhiteSpace(golfFromDB?.ImageUrl))
                {
                    // ImageUrl stored as a relative URL like "/images/golfballs/xyz.jpg" or "\images\golfballs\xyz.jpg"
                    var relative = golfFromDB.ImageUrl.TrimStart('\\', '/').Replace('/', Path.DirectorySeparatorChar).Replace('\\', Path.DirectorySeparatorChar);
                    var oldFile = Path.Combine(wwwRootFolder, relative);
                    if (System.IO.File.Exists(oldFile))
                    {
                        System.IO.File.Delete(oldFile);
                    }
                }

                var savedFileName = newFileName + extension;
                var savedPath = Path.Combine(uploadFolder, savedFileName);
                using (var fileStream = new FileStream(savedPath, FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }

                // Store a web-friendly relative path for use in <img src="...">
                GolfBall.ImageUrl = $"/images/golfballs/{savedFileName}";
            }
            else
            {
                // No new file uploaded -> keep existing image URL (if any)
                GolfBall.ImageUrl = golfFromDB?.ImageUrl;
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.GolfBallRepo.Update(GolfBall);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }
}
