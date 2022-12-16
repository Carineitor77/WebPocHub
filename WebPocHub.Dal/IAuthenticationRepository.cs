using WebPocHub.Models;

namespace WebPocHub.Dal
{
    public interface IAuthenticationRepository
    {
        int RegisterUser(User user);
        User? CheckCredentials(User user);
        string GetUserRole(int roleId);
    }
}
