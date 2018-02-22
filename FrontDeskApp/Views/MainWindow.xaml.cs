using FrontDeskApp.Views;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FrontDeskApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }


        private void ListViewItem_Clicked(object sender, RoutedEventArgs e)
        {
            ListViewItem item = (ListViewItem)(sender as ListView).SelectedItem;
            if (item != null)
            {
                switch (item.Name)
                {
                    case "Rooms":
                        RoomsWindow roomsView = new RoomsWindow();
                        roomsView.Show();
                        break;
                    case "Reservations":
                        ReservationsWindow reservationsView = new ReservationsWindow();
                        reservationsView.Show();
                        break;
                    case "CheckIn":
                        CheckInWindow checkInView = new CheckInWindow();
                        checkInView.Show();
                        break;
                    case "CheckOut":
                        CheckOutWindow checkOutView = new CheckOutWindow();
                        checkOutView.Show();
                        break;
                    case "Requests":
                        RequestCreator requestView = new RequestCreator();
                        requestView.Show();
                        break;
                }
            }
        }

    }
}
