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

namespace Internet_Shop
{
    /// <summary>
    /// Логика взаимодействия для GuestMenu.xaml
    /// </summary>
    public partial class GuestMenu : Window
    {
        public GuestMenu()
        {
            InitializeComponent();
        }

        private void Authorization(object sender, RoutedEventArgs e)
        {
            Authorization athorization = new Authorization();
            Hide();
            athorization.ShowDialog();
        }
    }
}
