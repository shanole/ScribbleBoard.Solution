using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ScribbleBoard.Models;
using System.Threading.Tasks;
using ScribbleBoard.ViewModels;
using Microsoft.AspNetCore.Http;
using System;

namespace ScribbleBoard.Controllers
{
    public class AccountController : Controller
    {
        private readonly ScribbleBoardContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController (UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ScribbleBoardContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }

        public ActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register (RegisterViewModel model)
        {
            var result = RegisterViewModel.Register(model);
            if (result == "Success")
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
        //   ApplicationUser user = await _userManager.FindByEmailAsync(model.Email);
        //   string loginUser = user.UserName; 
        //     Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(loginUser, model.Password, isPersistent: true, lockoutOnFailure: false);
        //     if (result.Succeeded)
        //     {
        //         return RedirectToAction("Index");
        //     }
        //     else
        //     {
        //         return View();
        //     }
            string loginResult = LoginViewModel.Login(model);
            if (loginResult == "Error")
            {
                return View();
            }
            else
            {
                SetJwtCookie(loginResult);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            // maybe create a LogOff confirmed page?
            return NoContent();
        }
        private void SetJwtCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddHours(3)
            };
            Response.Cookies.Append("jwtCookie", token, cookieOptions);
        }
    }
}