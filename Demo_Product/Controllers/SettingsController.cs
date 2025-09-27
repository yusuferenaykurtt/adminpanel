using Demo_Product.EntityLayer.Concrete.AppUser;
using Demo_Product.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Product.Controllers
{
    public class SettingsController : Controller
    {

        protected readonly UserManager<AppUser> _userManager;

        public SettingsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            UserSettingViewModel viewModel = new UserSettingViewModel();

            viewModel.UserName = value.UserName;
            viewModel.surName = value.SurName;
            viewModel.eMail = value.Email;
            viewModel.password = value.PasswordHash;

            return View(viewModel);
        }

        [HttpPost]

        public async  Task<IActionResult> Index(UserSettingViewModel u)
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
    

            value.UserName= u.UserName;
            value.SurName = u.surName;
            value.Email=u.eMail;
            value.PasswordHash = _userManager.PasswordHasher.HashPassword(value, u.password);
            var result=await _userManager.UpdateAsync(value);

            if (result.Succeeded)
            {

                return RedirectToAction("Index", "Login");

            }
           
            return View(u);
        }
    }
}
