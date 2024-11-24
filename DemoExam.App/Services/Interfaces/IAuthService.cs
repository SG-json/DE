namespace DemoExam.App.Services.Interfaces
{
    public interface IAuthService
    {
        public dynamic CurrentUser { get; }

        public Task Auth(string login, string password);

        public void LogOut();
    }
}
