using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProject_L00181476.Pages.PageViewModels;
using RP1.Models.Models;

namespace MyProject_L00181476.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        [BindProperty]
        public Register Register { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public RegisterModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    FirstName = Register.FirstName, LastName = Register.LastName,
                    PhoneNumber = Register.PhoneNumber,
                    UserName = Register.Email,
                    Email = Register.Email
                };

                var result = await _userManager.CreateAsync(user, Register.Password);
                if(result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Customer");
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToPage("Index");
                }
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);

                return Page();
            }

            // ModelState invalid — re-render page so validation messages show
            return Page();
        }
    }
}
