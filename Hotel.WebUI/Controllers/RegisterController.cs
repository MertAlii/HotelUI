using Hotel.EntityLayer.Concrete;
using Hotel.WebUI.Dtos.RegisterDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateNewUserDto createNewUserDto)
        {
            if (!ModelState.IsValid)
            {
                return View(createNewUserDto);
            }

            var appUser = new AppUser()
            {
                Name = createNewUserDto.Name,
                Surname = createNewUserDto.Surname,
                UserName = createNewUserDto.UserName,
                Email = createNewUserDto.Mail
            };

            var result = await _userManager.CreateAsync(appUser, createNewUserDto.Password);
            
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(createNewUserDto);
            }
        }
    }
}
