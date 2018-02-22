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
    /// Interaction logic for CheckInWindow.xaml
    /// </summary>
    public partial class CheckInWindow : Window
    {

        private FrontDeskController controller;


        public CheckInWindow()
        {
            InitializeComponent();

            controller = new FrontDeskController();

        }

        private void FindRoomButton_Click(object sender, RoutedEventArgs e)
        {
            if(ReservationNr.Text != "Reservation Number" && ReservationNr.Text != null)
            {
                // Rooms = controller.GetRoomsForReservation(ReservationNr.Text);

                // RESERVATION res = controller.GetReservation(ReservationNr.Text);

                 CheckInResults cIR = new CheckInResults(ReservationNr.Text);
                 cIR.Show();

            }
            else
            {
                // Rooms = controller.GetRoomsWithoutReservation(CheckInDate.Text, CheckOutDate.Text, Size.Text, NrBeds.text,
                //      Smoker.Text, Quality.Text);

                // CheckInResults cIR = new CheckInResults(CheckInDate.Text, CheckOutDate.Text, Rooms);
            }
        }
    }
}
