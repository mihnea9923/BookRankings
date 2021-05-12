using BookRankings.DataAcess.Abstractions;
using BookRankings.Model;
using BookRankings.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookRankings.Controllers
{
    public class IdentityController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IUserRepository userRepository;
        private readonly SignInManager<IdentityUser> signInManager;

        public IdentityController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager
            , IUserRepository userRepository, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.userRepository = userRepository;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    userRepository.Add(new User { Name = user.UserName, UserId = user.Id });
                    await signInManager.SignInAsync(user, isPersistent: false);
                    await userManager.AddToRoleAsync(user, "user");
                    string filePath = @"C:\Users\menta\source\repos\BookRankings\BookRankings\wwwroot\UsersPhotos";
                    filePath = Path.Combine(filePath, user.Id + ".jpg");
                    using (FileStream fs = System.IO.File.Create(filePath))
                    {
                        HttpContext.Request.Form.Files[0].CopyTo(fs);
                        fs.Flush();
                    }
                    return RedirectToAction("Ratings", "Home");

                }

            }
            return Register();

        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await signInManager.PasswordSignInAsync(model.Name, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var user = await userManager.FindByEmailAsync(model.Name);
                    await signInManager.SignInAsync(user, true);
                    if (await userManager.IsInRoleAsync(user, "user"))
                    {
                        return RedirectToAction("Ratings", "Home");
                    }
                    if (await userManager.IsInRoleAsync(user, "admin"))
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                }
            }
            return View();
        }
    }
}
