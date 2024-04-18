using System.Windows;
using System.Windows.Input;

namespace TicketBooking.views
{
    /// <summary>
    /// Interaction logic for ModalWindow.xaml
    /// </summary>
    public partial class ModalWindow : Window
    {
        public ModalWindow()
        {
            InitializeComponent();
            this.Owner = App.Current.MainWindow;
        }
        public ModalWindow(string? wTitle, string? imageUrl, string? wContent)
        {
            WTitle = wTitle;
            ImageUrl = imageUrl;
            WContent = wContent;
            InitializeComponent();
            this.Owner = App.Current.MainWindow;
        }

        private string? _wTitle;
        public string? WTitle
        {
            get => _wTitle;
            private set => _wTitle = value;
        }

        private string? _imageUrl;
        public string? ImageUrl
        {
            get => _imageUrl;
            private set => _imageUrl = value;
        }

        private string? _wContent;
        public string? WContent
        {
            get => _wContent;
            private set => _wContent = value;
        }

        private void firstButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Border_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Escape)
            {
                this.DialogResult= false;
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
