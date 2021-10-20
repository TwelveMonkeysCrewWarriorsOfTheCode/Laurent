using AdoptDevDAL.Models.Security;

namespace AdoptDevDAL.Interfaces
{
    public interface ILoginService
    {
        public BeLoggedModel LogIn(LogInModel logIn);
    }
}
