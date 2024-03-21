using System.Collections.ObjectModel;
using System.Windows.Input;
using TicketBooking.classes;
using TicketBooking.models;

namespace TicketBooking.viewmodels
{
    internal class MainWindowViewModel : Notifier
    {
        private readonly MainWindowModel _model;

        #region Properties

        private ObservableCollection<Ticket> _ticketCollection = new ObservableCollection<Ticket>();
        public ObservableCollection<Ticket> Tickets
        {
            get { return _ticketCollection; }
            set
            {
                _ticketCollection = value;
                OnPropertyChanged();
            }
        }
        private bool _isInformationBarOpen = false;
        public bool IsInformationBarOpen
        {
            get { return _isInformationBarOpen; }
            set
            {
                _isInformationBarOpen = value;
                OnPropertyChanged();
            }
        }

        private Ticket? _selectedTicket;
        public Ticket? SelectedTicket
        {
            get { return _selectedTicket; }
            set
            {
                _selectedTicket = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands
        private ICommand? _openInformationBar;
        public ICommand OpenInformationBar
        {
            get
            {
                return _openInformationBar ??
                    (_openInformationBar = new RelayCommand(obj =>
                    {
                        if(obj is Ticket ticket)
                        {
                            if(IsInformationBarOpen == false)
                            {
                                IsInformationBarOpen = true;
                            }
                            SelectedTicket = ticket;
                        }
                    }));
            }
        }
        private ICommand? _closeInformationBar;
        public ICommand CloseInformationBar
        {
            get
            {
                return _closeInformationBar ??
                    (_closeInformationBar = new RelayCommand(obj =>
                    {
                        IsInformationBarOpen = false;
                        SelectedTicket = null;
                    }));
            }
        }

        #endregion

        public MainWindowViewModel()
        {
            _model = new MainWindowModel();
            _ticketCollection.Add(new Ticket() { ImageUrl=$"https://m.media-amazon.com/images/M/MV5BMDBmYTZjNjUtN2M1MS00MTQ2LTk2ODgtNzc2M2QyZGE5NTVjXkEyXkFqcGdeQXVyNzAwMjU2MTY@._V1_.jpg", 
                ReleaseYear="2023", 
                Title="Oppenheimer", 
                Genre= "Biography", 
                Country="USA, UK",
                Duration="180 min.",
                Description= "The story of American scientist J. Robert Oppenheimer and his role in the development of the atomic bomb.",
                Rating =5.5 } );
            _ticketCollection.Add(new Ticket() { ImageUrl = $"https://www.dvdsreleasedates.com/posters/800/D/Dune-Part-Two-2023-movie-poster.jpg", 
                ReleaseYear = "2024", 
                Title = "Dune: Part Two", 
                Genre="Fantastic", 
                Country= "USA, Canada, UAE, Hungary, Italy, New Zealand, Jordan, Gambia",
                Duration="166 min.",
                Description= "Paul Atreides unites with Chani and the Fremen while seeking revenge against the conspirators who destroyed his family.",
                Rating =1.2 });
            _ticketCollection.Add(new Ticket() { ImageUrl = $"https://cinemaorion.fi/wp-content/uploads/2023/07/poor_payoff_poster_fi-717x1024.jpg", 
                ReleaseYear = "2023", 
                Title = "Poor Things",
                Genre="Drama",
                Country = "Ireland, UK, USA, Hungary",
                Duration = "141 min.",
                Description = "The incredible tale about the fantastical evolution of Bella Baxter, a young woman brought back to life by the brilliant and unorthodox scientist Dr. Godwin Baxter",
                Rating =9.3 });
        }
    }
}
