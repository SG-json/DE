using DemoExam.App.Command;
using DemoExam.App.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Input;

namespace DemoExam.App.ViewModels
{
    public class AuthViewModel : BaseViewModel
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IAuthService _authService;
        private readonly IViewService _viewService;

        private string _login = string.Empty!;
        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }

        private string _password = string.Empty!;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public ICommand LogIn
        {
            get => new RelayCommand(
                execute: async (o) =>
                {
                    try
                    {
                        await _authService.Auth(Login, Password);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                },
                canExecute: (o) => !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password)
            );
        }

        public AuthViewModel(IServiceProvider serviceProvider, IAuthService authorizationService, IViewService viewsManager)
        {
            _serviceProvider = serviceProvider;
            _authService = authorizationService;
            _viewService = viewsManager;
        }
    }
}
