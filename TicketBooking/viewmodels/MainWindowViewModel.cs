using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Windows.Input;
using TicketBooking.classes;
using TicketBooking.models;
using TicketBooking.views;

namespace TicketBooking.viewmodels
{
    internal class MainWindowViewModel : Notifier
    {
        Random random;
        private readonly MainWindowModel _model;

        #region Properties

        private int _selectedSubPage = 0;
        public int SelectedSubPage
        {
            get { return _selectedSubPage; }
            set
            {
                _selectedSubPage = value;
                OnPropertyChanged();
            }
        }

        private double _totalAmount;
        public double TotalAmount
        {
            get { return _totalAmount; }
            set
            {
                _totalAmount = value;
                OnPropertyChanged();
            }
        }

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

        private ObservableCollection<Session> _sessionsCollection = new ObservableCollection<Session>();
        public ObservableCollection<Session> Sessions
        {
            get { return _sessionsCollection; }
            set
            {
                _sessionsCollection = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Movie> _movieCollection = new ObservableCollection<Movie>();
        public ObservableCollection<Movie> Movies
        {
            get { return _movieCollection; }
            set
            {
                _movieCollection = value;
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

        private Movie? _selectedMovie;
        public Movie? SelectedMovie
        {
            get { return _selectedMovie; }
            set
            {
                _selectedMovie = value;
                OnPropertyChanged();
            }
        }

        private Hall? _hall;
        public Hall? Hall
        {
            get { return _hall; }
            set
            {
                _hall = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Seat> _selectedSeats = new ObservableCollection<Seat>();
        public ObservableCollection<Seat> SelectedSeats
        {
            get { return _selectedSeats; }
            set
            {
                _selectedSeats = value;
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
                        if(obj is Movie movie)
                        {
                            if (movie == SelectedMovie) return;

                            SelectedSubPage = 0;
                            TotalAmount = 0;
                            SelectedSeats.Clear();

                            if(IsInformationBarOpen == false)
                            {
                                IsInformationBarOpen = true;
                            }
                            SelectedMovie = movie; 
                            List<Row> rows = new List<Row>();
                            int rowsnum = random.Next() % 15;
                            rows.Add(new Row() { Number = 1, Seats = new List<Seat> { new Seat() {Row = 1, Type=SeatType.Sofa, Status="Free", Number="1" }, new Seat() { Row = 1, Type = SeatType.Sofa, Status = "Free", Number = "2" } } });
                            for (int i = 1; i < rowsnum; i++) rows.Add(new Row() { Seats = GetSeats(i + 1, random.Next()%15, random), Number = i + 1 });
                            rows.Add(new Row() { Number = rowsnum+1, Seats = new List<Seat> { new Seat() { Row = rowsnum+1, Type = SeatType.Loveseat, Status = "Free", Number = "1" }, new Seat() { Row = rowsnum, Type = SeatType.Loveseat, Status = "Free", Number = "2" } } });
                            Hall = new Hall() { Rows = rows, MaxSeatsToPick = 6 };
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
                        SelectedMovie = null;
                    }));
            }
        }

        private ICommand? _openSessionView;
        public ICommand OpenSessionView
        {
            get
            {
                return _openSessionView ??
                    (_openSessionView = new RelayCommand(obj =>
                    {
                        SelectedSubPage = 1;
                    }));
            }
        }

        private ICommand? _buyButtonCommand;
        public ICommand BuyButtonCommand
        {
            get
            {
                return _buyButtonCommand ??
                    (_buyButtonCommand = new RelayCommand(obj =>
                    {

                    SelectedSubPage = 2; 
                    }));
            }
        }

        #endregion

        private List<Seat> GetSeats(int rowNum, int seatsInARow, Random r)
        {
            List<Seat> seats = new List<Seat>();
            for(int i = 0; i<seatsInARow; i++) seats.Add(new Seat() { Row=rowNum, Type = SeatType.Ordinary, Status = r.Next(10) < 5 ? "Free" : "Reserved", Number = (i + 1).ToString() });
            return seats;
        }
        public MainWindowViewModel()
        {
            _model = new MainWindowModel();
            _movieCollection.Add(new Movie() { ImageUrl=$"https://m.media-amazon.com/images/M/MV5BMDBmYTZjNjUtN2M1MS00MTQ2LTk2ODgtNzc2M2QyZGE5NTVjXkEyXkFqcGdeQXVyNzAwMjU2MTY@._V1_.jpg", 
                ReleaseYear="2023", 
                Title="Oppenheimer", 
                Genre= "Biography", 
                Country="USA, UK",
                Duration="180 min.",
                Description= "The story of American scientist J. Robert Oppenheimer and his role in the development of the atomic bomb.",
                Rating =5.5 } );
            _movieCollection.Add(new Movie() { ImageUrl = $"https://www.dvdsreleasedates.com/posters/800/D/Dune-Part-Two-2023-movie-poster.jpg", 
                ReleaseYear = "2024", 
                Title = "Dune: Part Two", 
                Genre="Fantastic", 
                Country= "USA, Canada, UAE, Hungary, Italy, New Zealand, Jordan, Gambia",
                Duration="166 min.",
                Description= "Paul Atreides unites with Chani and the Fremen while seeking revenge against the conspirators who destroyed his family.",
                Rating =1.2 });
            _movieCollection.Add(new Movie() { ImageUrl = $"https://cinemaorion.fi/wp-content/uploads/2023/07/poor_payoff_poster_fi-717x1024.jpg", 
                ReleaseYear = "2023", 
                Title = "Poor Things",
                Genre="Drama",
                Country = "Ireland, UK, USA, Hungary",
                Duration = "141 min.",
                Description = "The incredible tale about the fantastical evolution of Bella Baxter, a young woman brought back to life by the brilliant and unorthodox scientist Dr. Godwin Baxter",
                Rating =9.3 });

            _sessionsCollection.Add(new Session()
            {
                Format = "2D",
                Hall = 1,
                Time = new DateTime(1, 1, 1, 16, 30, 0)
            });
            _sessionsCollection.Add(new Session()
            {
                Format = "2D",
                Hall = 2,
                Time = new DateTime(1, 1, 1, 19, 0, 0)
            });
            _sessionsCollection.Add(new Session()
            {
                Format = "2D",
                Hall = 1,
                Time = new DateTime(1, 1, 1, 22, 25, 0)
            });

            List<Discount> discounts = new List<Discount>()
            {
                new Discount { Name = "Adult", PriceMultiplier = 1},
                new Discount { Name = "Child", PriceMultiplier = 0.5},
                new Discount { Name = "Student", PriceMultiplier = 0.75}
            };

            _ticketCollection.Add(new Ticket()
            {
                SeatType=SeatType.Ordinary,
                Price=8,
                Name="Ordinary",
                Discounts = discounts
            });
            _ticketCollection.Add(new Ticket()
            {
                SeatType=SeatType.Sofa,
                Price=22,
                Name="Sofa",
                Discounts = discounts
            });
            _ticketCollection.Add(new Ticket()
            {
                SeatType=SeatType.Loveseat,
                Price=18,
                Name="Loveseat",
                Discounts = discounts
            });

            SelectedSeats.CollectionChanged += SelectedSeats_CollectionChanged;
            random = new Random();
        }

        private void SelectedSeats_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            var seats = sender as ObservableCollection<Seat>;
            
            if (seats == null) return;
            if (Hall == null) return;

            if (seats.Count > Hall.MaxSeatsToPick)
            {
                ModalWindow _mw = new ModalWindow("Warning", null, $"You can pick only {Hall.MaxSeatsToPick} seats.");
                _mw.ShowDialog();
                SelectedSeats.CollectionChanged -= SelectedSeats_CollectionChanged;
                var _nseats = new ObservableCollection<Seat>(seats.Take(Hall.MaxSeatsToPick));
                SelectedSeats = _nseats;
                SelectedSeats.CollectionChanged += SelectedSeats_CollectionChanged;
            }

            double sum = 0;
            foreach (var seat in SelectedSeats)
            {
                sum += _ticketCollection.First(u => u.SeatType == seat.Type).Price;
            }
            TotalAmount = sum;
            Debug.WriteLine(TotalAmount);
        }
    }
}
