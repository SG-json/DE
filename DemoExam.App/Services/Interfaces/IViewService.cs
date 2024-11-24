using System.Windows;

namespace DemoExam.App.Services.Interfaces
{
    public interface IViewService
    {
        public Window Current { get; }
        public void Open<TView>(object? dataContext = null) where TView : Window;
    }
}
