using Hotel.EntityLayer.Concrete;
using Hotel.WebUI.Dtos.LoginDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hotel.WebUI.Controllers;
public class LoginController : Controller
{
    private readonly SignInManager<AppUser> _signInManager;

    public LoginController(SignInManager<AppUser> signInManager)
    {
        _signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Index(LoginUserDto loginUserDto)
    {
       if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(loginUserDto.UserName, loginUserDto.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Staff");
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı.");
            }
        }
        return View();
    }
}
