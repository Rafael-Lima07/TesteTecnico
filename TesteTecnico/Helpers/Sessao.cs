using Newtonsoft.Json;
using TesteTecnico.ViewModel;

namespace TesteTecnico.Helpers;

public class Sessao : ISessao
{
    private readonly IHttpContextAccessor _httpContext;

    public Sessao(IHttpContextAccessor httpContext)
    {
        _httpContext = httpContext;
    }

    public LoginViewModel BuscarSessaoDoUsuario()
    {
        string sessaoUsuario = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");

        if (string.IsNullOrEmpty(sessaoUsuario))
            return null;

        return JsonConvert.DeserializeObject<LoginViewModel>(sessaoUsuario);
    }

    public void CriarSessaoDoUsuario(LoginViewModel usuario)
    {
        string valor = JsonConvert.SerializeObject(usuario);
        _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
    }

    public void RemoverSessaoDoUsuario()
    {
        _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
    }
}
