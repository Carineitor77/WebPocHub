using System.Linq;
using WebPocHub.Models;

namespace WebPocHub.Dal
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly WebPocHubDbContext _dbContext;

        public AuthenticationRepository(WebPocHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User? CheckCredentials(User user)
        {
            var userCredentials = _dbContext.Users.SingleOrDefault(u => u.Email == user.Email);
            return userCredentials;
        }

        public string GetUserRole(int roleId)
        {
            return _dbContext.Roles.SingleOrDefault(role => role.RoleId == roleId)!.RoleName;
        }

        public int RegisterUser(User user)
        {
            _dbContext.Users.Add(user);
            return _dbContext.SaveChanges();
        }
    }
}
