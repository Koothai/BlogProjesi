using BlogProjesi.Models.Data;
using BlogProjesi.Models.Entity;
using BlogProjesi.ViewModels.Auth.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogProjesi.Controllers
{
    public class AuthController : Controller
    {
        private readonly DataBaseContext _context;
        public AuthController(DataBaseContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Login(string rPATH)
        {
            ViewBag.rPATH = rPATH;
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model, string rPATH)
        {
            if (ModelState.IsValid)
            {
                User user = _context.Users.FirstOrDefault(x => x.Username.Equals(model.Username) && x.Password.Equals(model.Password));
                if (user is not null)
                {
                    HttpContext.Session.SetString("userId", user.Id.ToString());
                    HttpContext.Session.SetString("username", user.Username.ToString());
                    if (string.IsNullOrEmpty(rPATH)) return RedirectToAction("Index", "Home");
                    else Redirect(rPATH);
                }
                else ModelState.AddModelError("", "User not found.");
            }
            else ModelState.AddModelError("", "Lütfen her alanı doldurun.");
            return View();
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("userId");
            HttpContext.Session.Remove("username");
            return RedirectToAction("Login");

        }
    }
}
