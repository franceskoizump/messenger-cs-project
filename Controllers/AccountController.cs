using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.VIewModels;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        // GET
       /* public IActionResult Index()
        {
            return
                View();
        }*/

        private ContactsContext db;

        public AccountController(ContactsContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Contact contact =
                    await db.Contacts.FirstOrDefaultAsync(u => u.name == model.Name && u.password == model.Password);
                if (contact != null)
                {
                    await Authenticate(model.Name);

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                Contact contact = await db.Contacts.FirstOrDefaultAsync(u => u.name == model.Name);
                if (contact == null)
                {
                    db.Contacts.Add(new Contact {name = model.Name, password = model.Password});
                    await db.SaveChangesAsync();

                    await Authenticate(model.Name); 

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }

            return View(model);
        }

        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
