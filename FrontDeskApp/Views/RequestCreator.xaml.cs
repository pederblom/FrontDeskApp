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

        private string type;
        FrontDeskController controller;

        public RequestCreator()
        {
            InitializeComponent();
            controller = new FrontDeskController();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if(type != null && RoomNr.Text != null && RoomNr.Text != "Room Nr")
            {
                controller.CreateRequest(type, Comment.Text, RoomNr.Text);
                SaveButton.IsEnabled = false;
            }
        }

        private void ListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listbox = sender as ListBox;
            ListBoxItem item = (ListBoxItem)listbox.SelectedItem;
            type = item.Content.ToString();
        }
    }
}
