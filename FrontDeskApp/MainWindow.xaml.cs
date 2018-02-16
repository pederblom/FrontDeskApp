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

namespace FrontDeskApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DbContext dx = new DbContext("Data Source=DESKTOP-U4HAM0I;Initial Catalog=DAT154;Integrated Security=True");
            var users = dx.Set<USER>();
            var rooms = dx.Set<ROOM>();
            var requests = dx.Set<REQUEST>();
            var reservations = dx.Set<RESERVATION>();
        }
    }
}
