using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using TicketBooking.classes;
using System.Diagnostics;
using System.Windows.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Collections.Specialized;

namespace TicketBooking.controls
{
    /// <summary>
    /// Interaction logic for SeatPicker.xaml
    /// </summary>
    public partial class SeatPicker : UserControl, INotifyPropertyChanged
    {
        private ItemsControl _rowsView;
        private bool _bSelectedSeatsChanged = false;

        #region Hall

        public static readonly DependencyProperty HallProperty = DependencyProperty.Register(
            "Hall",
            typeof(Hall),
            typeof(SeatPicker));
        public Hall? Hall
        {
            get { return (Hall)GetValue(HallProperty);}
            set { SetValue(HallProperty, value);}
        }

        #endregion

        #region SelectedSeats

        public static readonly DependencyProperty SelectedSeatsProperty = DependencyProperty.Register(
            "SelectedSeats",
            typeof(ObservableCollection<Seat>),
            typeof(SeatPicker),
            new FrameworkPropertyMetadata(new ObservableCollection<Seat>(), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnSelectedSeatsChanged));

        public ObservableCollection<Seat> SelectedSeats
        {
            get { return (ObservableCollection<Seat>)GetValue(SelectedSeatsProperty); }
            set { SetValue(SelectedSeatsProperty, value);}
        }

        private static void OnSelectedSeatsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var picker = (SeatPicker)d;
            if(picker == null)
            {
                return;
            }
            picker.SetSeatButtons();
            //picker._bSelectedSeatsChanged = true;
        }

        #endregion

        public SeatPicker()
        {
            InitializeComponent();
            SelectedSeats = new ObservableCollection<Seat>();
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _rowsView = FindName("PART_RowsView") as ItemsControl;
        }

        private void ItemContainerGenerator_StatusChanged(object? sender, EventArgs e)
        {
            var icg = sender as ItemContainerGenerator;
            if (icg == null)
            {
                return;
            }
            Debug.WriteLine(icg.Status);
            if (icg.Status == System.Windows.Controls.Primitives.GeneratorStatus.ContainersGenerated)
            {
                if (_bSelectedSeatsChanged)
                {
                    _bSelectedSeatsChanged = false;
                    Debug.WriteLine(_rowsView.Items.Count);
                    SetSeatButtons();
                }
            }
        }

        private void SetSeatButtons()
        {
            if(_rowsView == null)
            {
                return;
            }
            for (int i = 0; i < _rowsView.Items.Count; i++)
            {
                ContentPresenter cp = (ContentPresenter)(_rowsView.ItemContainerGenerator.ContainerFromIndex(i));
                DataTemplate dt = cp.ContentTemplate;
                ItemsControl seatsview = dt?.FindName("PART_SeatView", cp) as ItemsControl;
                if (seatsview == null)
                {
                    continue;
                }
                for (int k = 0; k < seatsview.Items.Count; k++)
                {
                    cp = (ContentPresenter)(seatsview.ItemContainerGenerator.ContainerFromIndex(k));
                    dt = cp.ContentTemplate;
                    SeatPickerButton seatPickerButton = dt?.FindName("seatPickerButton", cp) as SeatPickerButton;
                    if (seatPickerButton == null || !(seatPickerButton.DataContext is Seat s))
                    {
                        continue;
                    }
                    seatPickerButton.SetSelectedPropertyValue(SelectedSeats.Contains(s));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void SeatPickerButton_Click(object sender, RoutedEventArgs e)
        {
            SeatPickerButton b = sender as SeatPickerButton;
            if (b == null)
            {
                return;
            }
            if(b.DataContext is Seat s)
            {
                if(SelectedSeats.Contains(s))
                {
                    SelectedSeats.Remove(s);
                }
                else
                {
                    SelectedSeats.Add(s);
                }
            }
        }
    }
}
