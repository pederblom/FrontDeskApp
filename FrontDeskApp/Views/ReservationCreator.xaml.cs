using FrontDeskApp;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for ReservationCreator.xaml
    /// </summary>
    public partial class ReservationCreator : Window
    {

        private FrontDeskController controller;
        private string roomNr;
        private String checkIn;
        private String checkOut;
        private String eMail;

        public ReservationCreator()
        {
            InitializeComponent();

            controller = new FrontDeskController();

        }

        public ReservationCreator(string roomNr, String checkIn, String checkOut, String eMail)
        {
            InitializeComponent();

            this.roomNr = roomNr;
            this.checkIn = checkIn;
            this.checkOut = checkOut;
            this.eMail = eMail;

            SetReservationInfo();

            controller = new FrontDeskController();

        }

        private void SetReservationInfo()
        {
            RoomNr.Text = roomNr.ToString();
            CheckInDate.Text = checkIn;
            CheckOutDate.Text = checkOut;
            Email.Text = eMail;
            Confirmed.Text = "1";
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            controller.addReservation(RoomNr.Text, CheckInDate.Text, CheckOutDate.Text, Email.Text);
            Close();
        }
    }
}
