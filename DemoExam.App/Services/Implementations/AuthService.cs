using DemoExam.App.Context;
using DemoExam.App.Services.Interfaces;

namespace DemoExam.App.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly DatabaseContext _context;

        public AuthService(DatabaseContext context)
        {
            _context = context;
        }

        private dynamic _currentUser = null!;
        public dynamic CurrentUser { get => _currentUser; }

        public async Task Auth(string login, string password)
        {
            var user = "";

            if (user is null)
                throw new Exception("Неправильный логин или пароль!");

            _currentUser = user;
        }

        public void LogOut() => _currentUser = null!;
    }
}
