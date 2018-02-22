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
    /// Interaction logic for CheckOutWindow.xaml
    /// </summary>
    public partial class CheckOutWindow : Window
    {

        public CheckOutWindow()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CheckOutButton_Click(object sender, RoutedEventArgs e)
        {
            if (ResNrBox.Text != "Reservation Nr" && ResNrBox.Text != null)
            {
                // controller.CheckOut(ResNrBox.Text);
                Close();
            }
        }
    }
}
