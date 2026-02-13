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
            string wwwRootFolder = _webHostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            var golfFromDB = _unitOfWork.GolfBallRepo.Get(GolfBall.Id);

            if(files.Count > 0)
            {
                string new_fileName = Guid.NewGuid().ToString();

                var upload = Path.Combine(wwwRootFolder, @"images\golfballs");

                var extension = Path.GetExtension(files[0].FileName);
                if (golfFromDB != null)
                {
                    var oldFile = Path.Combine(wwwRootFolder, golfFromDB.ImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldFile))
                    {
                        System.IO.File.Delete(oldFile);
                    }
                }
                using (var fileStream = new FileStream(Path.Combine(upload, new_fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                    GolfBall.ImageUrl = @"\images\folfballs\" + new_fileName + extension;
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
