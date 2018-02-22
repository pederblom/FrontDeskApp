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

        private string reservation = null;
        private String checkIn;
        private String checkOut;

        public CheckInResults(string res)
        {
            InitializeComponent();

            controller = new FrontDeskController();
            RoomList.DataContext = controller.GetRoomsForReservation(res);
            
            reservation = res;
        }

        public CheckInResults(String checkInDate, String checkOutDate, ObservableCollection<ROOM> Rooms)
        {
            InitializeComponent();

            controller = new FrontDeskController();

            checkIn = checkInDate;
            checkOut = checkOutDate;
            //this.R = Rooms;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            int selectedRoom = controller.GetRoom(RoomList);

            if (Email.Text == "Guest E-mail" && reservation != null)
            {
                RESERVATION res = controller.findReservation(reservation);
                controller.associateReservation(selectedRoom.ToString(), res);

            } else
            {
                ReservationCreator resCreator = new ReservationCreator(selectedRoom.ToString(), checkIn, checkOut, Email.Text);
            }

            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
