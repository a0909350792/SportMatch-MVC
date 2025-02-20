using SportMatch.Models;
using System.Linq;
namespace SportMatch.Services
{
    public class AuthenticationService
    {
        private readonly SportMatchContext _context;
        public AuthenticationService(SportMatchContext context) {
            _context = context;
        }
        public bool VaildateUser(string account,string password) { 
            var user = _context.Logins.FirstOrDefault(u => u.Account == account&& u.Password  == password );
            return user != null;
        }
    }
}
