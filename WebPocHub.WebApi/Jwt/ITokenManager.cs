using WebPocHub.Models;

namespace WebPocHub.WebApi.Jwt
{
    public interface ITokenManager
    {
        string GenerateToken(User user, string roleName);
    }
}
