using System.Windows;
using TicketBooking.viewmodels;
using TicketBooking.views;

namespace TicketBooking
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindowViewModel mvvm = new MainWindowViewModel();
            this.MainWindow = new MainWindow();
            this.MainWindow.DataContext = mvvm;
            this.MainWindow.Show();
            base.OnStartup(e);
        }
    }

}
