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
    /// Interaction logic for RequestCreator.xaml
    /// </summary>
    public partial class RequestCreator : Window
    {

        private String type = null;

        public RequestCreator()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if(type != null && RoomNr.Text != null && RoomNr.Text != "Room Nr")
            {
                // controller.CreateRequest(Int32.Parse(RoomNr.Text), type, Comment.Text);
                SaveButton.IsEnabled = false;
            }
        }

        private void ListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listbox = sender as ListBox;
            type = listbox.SelectedItem as String;
        }
    }
}
