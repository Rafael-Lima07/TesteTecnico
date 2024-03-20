using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TesteTecnico.ViewModel;

namespace TesteTecnico.ViewComponentes;

public class Menu : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");

        if (string.IsNullOrEmpty(sessaoUsuario)) return null;

        LoginViewModel login = JsonConvert.DeserializeObject<LoginViewModel>(sessaoUsuario);

        return View(login);
    }
}
