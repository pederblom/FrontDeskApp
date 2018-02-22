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
    /// Interaction logic for ReservationEditor.xaml
    /// </summary>
    public partial class ReservationEditor : Window
    {

        RESERVATION selectedReservation;

        public ReservationEditor(RESERVATION selectedReservation)
        {
            InitializeComponent();

            this.selectedReservation = selectedReservation;

            setAttributes();

        }

        private void setAttributes()
        {
            ID.Text = selectedReservation.res_ID.ToString();
            RoomNr.Text = selectedReservation.room_nr.ToString();
            CheckInDate.Text = selectedReservation.checkIn_Date.ToString();
            CheckOutDate.Text = selectedReservation.checkOut_Date.ToString();
            Email.Text = selectedReservation.e_mail;
            Confirmed.Text = selectedReservation.confirmed.ToString();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // FrontDeskController.associateRoom(selectedReservation, Int32.Parse(ID.Text));
            Close();
        }
    }
}
