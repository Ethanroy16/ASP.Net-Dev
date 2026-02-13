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
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateModel(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public GolfBall GolfBall { get; set; }
        public IEnumerable<SelectListItem> BrandsList { get; set; }


        public void OnGet()
        {
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
            string new_file_name = Guid.NewGuid().ToString();

            var upload = Path.Combine(wwwRootFolder, @"images\golfballs");

            var extension = Path.GetExtension(files[0].FileName);
            using (var fileStream = new FileStream(Path.Combine(upload, new_file_name + extension), FileMode.Create))
            {
                files[0].CopyTo(fileStream);
            }

            GolfBall.ImageUrl = @"\images\golfballs\" + new_file_name + extension;
            if (ModelState.IsValid)
            {
                _unitOfWork.GolfBallRepo.Add(GolfBall);
                _unitOfWork.Save();
            }

            return RedirectToPage("Index");
        }
        
    }
}
