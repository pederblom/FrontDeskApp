
using FrontDeskApp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
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
    /// Interaction logic for ReservationsWindow.xaml
    /// </summary>
    public partial class ReservationsWindow : Window
    {

        private FrontDeskController controller;

        public ReservationsWindow()
        {
            InitializeComponent();

            controller = new FrontDeskController();
            ReservationList.DataContext = controller.GetReservations();

        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            ReservationCreator newReservationWindow = new ReservationCreator();
            newReservationWindow.Show();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            RESERVATION selected = controller.GetReservation(ReservationList);
            controller.deleteReservation(selected);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            RESERVATION selected = controller.GetReservation(ReservationList);

            ReservationEditor editorView = new ReservationEditor(selected);

            editorView.Show();
        }
    }
}
