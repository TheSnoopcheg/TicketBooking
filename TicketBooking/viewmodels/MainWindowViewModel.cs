using TicketBooking.classes;
using TicketBooking.models;

namespace TicketBooking.viewmodels
{
    internal class MainWindowViewModel : Notifier
    {
        private readonly MainWindowModel _model;

        public MainWindowViewModel()
        {
            _model = new MainWindowModel();
        }
    }
}
