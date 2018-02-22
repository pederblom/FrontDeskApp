using FrontDeskApp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FrontDeskApp.Views
{
    /// <summary>
    /// Interaction logic for CheckInResults.xaml
    /// </summary>
    public partial class CheckInResults : Window
    {

        private FrontDeskController controller;

        private RESERVATION reservation = null;
        private ObservableCollection<ROOM> Rooms;
        private String checkIn;
        private String checkOut;

        public CheckInResults(RESERVATION res, ObservableCollection<ROOM> Rooms)
        {
            InitializeComponent();

            controller = new FrontDeskController();

            this.Rooms = Rooms;
            reservation = res;
        }

        public CheckInResults(String checkInDate, String checkOutDate, ObservableCollection<ROOM> Rooms)
        {
            InitializeComponent();

            controller = new FrontDeskController();

            checkIn = checkInDate;
            checkOut = checkOutDate;
            this.Rooms = Rooms;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            int selectedRoom = controller.GetRoom(RoomList);

            if (Email.Text == "Guest E-mail" && reservation != null)
            {
                // controller.associateRoom(res, selectedRoom);

            } else
            {
                ReservationCreator resCreator = new ReservationCreator(selectedRoom, checkIn, checkOut, Email.Text);
            }

            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
