using Demo_Product.EntityLayer.Concrete.AppUser;
using Demo_Product.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Demo_Product.Controllers
{
    public class LoginController : Controller
    {

        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;


        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager) 
        {
            _signInManager = signInManager;
            _userManager = userManager; 
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Index(UserLoginViewModel u)
        {

            if (ModelState.IsValid)
            {

                var user = await _userManager.FindByEmailAsync(u.eMail);
                
                

                var result = await _signInManager.PasswordSignInAsync(user,
                                                              u.password,
                                                              isPersistent: false,
                                                              lockoutOnFailure: false);

                if (result.Succeeded)
                {


                    return RedirectToAction("Index", "Product");

                }
                else
                {

                    ModelState.AddModelError("", "Wrong enter");
                }
            }
       
            return View();
        
        }

        public async Task<IActionResult> LogOut()
        {

            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Login");
            
        }
    }
}
