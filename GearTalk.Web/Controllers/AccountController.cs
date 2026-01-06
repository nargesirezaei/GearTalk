using GearTalk.Web.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GearTalk.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        //UserManager Api som snakker med identity(bruker-service i identity)
       public AccountController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            //mapping fra viewModel to IdentityUser
            var identityUser = new IdentityUser
            {
                UserName = registerViewModel.Username,
                Email = registerViewModel.Email,
            };

            var identityResult = await userManager.CreateAsync(identityUser, registerViewModel.Password);

            if(identityResult.Succeeded)
            {
                //asign this user the user Role
                 var roleIdentityResult = await userManager.AddToRoleAsync(identityUser, "User"); 

                if(roleIdentityResult.Succeeded)
                {
                    return RedirectToAction("Register");
                }
            }
            return View();

        }
    }
}
