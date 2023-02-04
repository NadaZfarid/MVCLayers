using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCLayers.Models;
using MVCLayers.ViewModels;
using System.Security.Claims;

namespace MVCLayers.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> manager;
        private readonly SignInManager<User> signIn;

        public UserController(UserManager<User> manager, SignInManager<User> signIn )
        {
            this.manager = manager;
            this.signIn = signIn;
        }
        public IActionResult List()
        {
            List<User> users = manager.Users.ToList();
            List<RegistrationVM> registrationVMs = new List<RegistrationVM>();
            foreach (var item in users)
            {
                registrationVMs.Add(new RegistrationVM()
                {
                    UserName = item.UserName,
                    Email = item.Email,
                    PhoneNumber = item.PhoneNumber,
                    RegisterDate = item.RegisterDate,
                    Address = item.Address,
                    Age = item.Age,
                });
            }
            return View(registrationVMs);
        }
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationVM registrationVM )
        {
            if(ModelState.IsValid)
            {
                User user = new User()
                {
                    UserName= registrationVM.UserName,
                    Email= registrationVM.Email,
                    PhoneNumber= registrationVM.PhoneNumber,
                    Address= registrationVM.Address,
                    Age= registrationVM.Age,
                    RegisterDate= registrationVM.RegisterDate,
                };
                IdentityResult result = await manager.CreateAsync(user,registrationVM.Password);
                if(result.Succeeded)
                {
                    return RedirectToAction(nameof(List));
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(registrationVM);
            }
            return View(registrationVM);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                User user = await manager.FindByEmailAsync(loginVM.Email);
                if (user != null)
                {
                    bool valid = await manager.CheckPasswordAsync(user, loginVM.Password);
                    if (valid)
                    {
                        List<Claim> claims = new List<Claim>()
                        {
                            new Claim("Address",user.Address),
                            new Claim("Age",user.Age.ToString())
                        };
                        await signIn.SignInWithClaimsAsync(user, loginVM.RememberMe, claims);
                        return RedirectToAction(nameof(Profile));
                    }
                }
                ModelState.AddModelError("", "Wrong email or password");
                return View(loginVM);
            }
            return View(loginVM);
        }
        public async Task<IActionResult> Profile()
        {
            string id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            User user = await manager.FindByIdAsync(id);
            RegistrationVM registrationVM = new RegistrationVM()
            {
                UserName= user.UserName,
                Email = user.Email,
                Address=user.Address,
                Age= user.Age,
                PhoneNumber= user.PhoneNumber,
                RegisterDate = user.RegisterDate
            };
            return View(registrationVM);
        }
    }
}
