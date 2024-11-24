using DemoExam.App.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace DemoExam.App.Services.Implementations
{
    public class ViewService: IViewService
    {
        private IServiceProvider _serviceProvider;

        public ViewService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        private Window _window;
        public Window Current { get => _window; }

        public void Open<TView>(object? dataContext = null) where TView : Window
        {
            var window = _serviceProvider.GetRequiredService<TView>();

            _window = Current;
            Current?.Close();
            _window = window;

            if (dataContext is not null)
                _window.DataContext = dataContext;

            _window.Show();
        }
    }
}
