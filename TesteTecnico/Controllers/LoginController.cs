using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TesteTecnico.Helpers;
using TesteTecnico.ViewModel;

namespace TesteTecnico.Controllers;

public class LoginController : Controller
{
    private readonly ISessao _sessao;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public LoginController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ISessao sessao)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _sessao = sessao;
    }

    public IActionResult Login()
    {

        if (_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel login)
    {
        if (!ModelState.IsValid)
            return View(login);

        var user = await _userManager.FindByNameAsync(login.UserName);

        if (user != null)
        {
            var result = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);

            if (result.Succeeded)
            {
                _sessao.CriarSessaoDoUsuario(login);

                return RedirectToAction("Index", "Home");
            }
        }
        ModelState.AddModelError("Login", "Falha ao realizar o login");
        return View(login);

    }
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(LoginViewModel register)
    {
        if (ModelState.IsValid)
        {
            var user = new IdentityUser
            {
                UserName = register.UserName,
            };

            var result = await _userManager.CreateAsync(user, register.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);

                return RedirectToAction("Login", "Login");
            }
            else
                this.ModelState.AddModelError("Registro", "Falha ao registrar o usuario");

        }

        return View(register);
    }
}
