using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProject_L00181476.Pages.PageViewModels;

namespace MyProject_L00181476.Pages
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        [BindProperty]
        public Login Login { get; set; }
        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public async void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Login.Email, Login.Password, Login.RememberMe, false);
                if(result.Succeeded)
                {
                    return RedirectToPage("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is Incorrect");
                    return Page();
                }
            }

            return RedirectToPage("Index");
        }
    }
}
