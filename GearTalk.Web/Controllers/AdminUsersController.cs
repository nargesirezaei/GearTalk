using Azure.Core;
using GearTalk.Web.Models.ViewModel;
using GearTalk.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GearTalk.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminUsersController : Controller
    {
        private readonly IUsersRepository usersRepository;
        private readonly UserManager<IdentityUser> userManager;

        public AdminUsersController(IUsersRepository usersRepository, UserManager<IdentityUser> userManager)
        {
            this.usersRepository = usersRepository;
            this.userManager = userManager;
        }
        public async Task<IActionResult> List()
        {
            var users = await usersRepository.GetAllAsync();
            var userViewModel = new UserViewModel();
            userViewModel.Users = new List<User>();

            foreach (var user in users)
            {
                userViewModel.Users.Add(new Models.ViewModel.User
                {
                    Id = Guid.Parse(user.Id),
                    Username = user.UserName,
                    EmailAddress = user.Email
                });
            }
            return View(userViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> List(UserViewModel request)
        {
            if (!ModelState.IsValid)
            {
                // Last inn eksisterende brukere på nytt, slik at viewet fungerer
                var users = await usersRepository.GetAllAsync();
                request.Users = users.Select(u => new Models.ViewModel.User
                {
                    Id = Guid.Parse(u.Id),
                    Username = u.UserName,
                    EmailAddress = u.Email
                }).ToList();

                return View(request);
            }

            var identityUser = new IdentityUser
            {
                UserName = request.Username,
                Email = request.Email
            };

            var identityResult = await userManager.CreateAsync(identityUser, request.Password);

            if (identityResult != null && identityResult.Succeeded)
            {
                var roles = new List<string> { "User" };

                if (request.AdminRoleCheckBox)
                {
                    roles.Add("Admin");
                }

                await userManager.AddToRolesAsync(identityUser, roles);

                return RedirectToAction("List");
            }

            // Hvis noe går galt under oppretting, vis feilmeldinger
            ModelState.AddModelError("", "Failed to create user.");

            var allUsers = await usersRepository.GetAllAsync();
            request.Users = allUsers.Select(u => new Models.ViewModel.User
            {
                Id = Guid.Parse(u.Id),
                Username = u.UserName,
                EmailAddress = u.Email
            }).ToList();

            return View(request);
        }

        [HttpPost]
        public  async Task<IActionResult> Delete (Guid id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                var identityResult = await userManager.DeleteAsync(user);

                if (identityResult != null && identityResult.Succeeded)
                {
                    return RedirectToAction("List", "AdminUsers");
                }
            }
            return View();
        }
    }
}
