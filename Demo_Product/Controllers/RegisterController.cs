using Demo_Product.EntityLayer.Concrete;
using Demo_Product.EntityLayer.Concrete.AppUser;
using Demo_Product.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Product.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(new UserRegisterViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Index(UserRegisterViewModel model)
        {
            
            if (!ModelState.IsValid)
                return View(model);

     
            if (model.password != model.confirmedPassword)
            {
                ModelState.AddModelError(string.Empty, "Passwords do not match.");
                return View(model);
            }

            
            var appUser = new AppUser
            {
                UserName = model.UserName,      
                Email = model.eMail,
                Name = model.UserName,
                SurName = model.surName,
                 Gender = "Unknown"
            };

          
            var result = await _userManager.CreateAsync(appUser, model.password);

            if (result.Succeeded)
            {
                    
                
                return RedirectToAction("Index", "Login");
            }

            foreach (var err in result.Errors)
                ModelState.AddModelError(string.Empty, err.Description);

            return View(model);
        }
    }
}
