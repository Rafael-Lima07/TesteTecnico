using TesteTecnico.ViewModel;

namespace TesteTecnico.Helpers
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(LoginViewModel usuario);
        void RemoverSessaoDoUsuario();
        LoginViewModel BuscarSessaoDoUsuario();
    }
}
