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
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Window
    {
        public OrdersPage()
        {
            InitializeComponent();
        }
        private void ClientSC(object sender, SelectionChangedEventArgs e)
        {
            Order choseroom = Orderpick.SelectedItem as Order;

            if (choseroom == null)
                return;
            OrderTable.ItemsSource = choseroom.Client;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Orderpick.ItemsSource = Context.DB.Order.ToList();
        }
        private void Window_Closed(object sender, EventArgs e)
        {

        }
        private void Menu(object sender, RoutedEventArgs e)
        {
            MainWindow glavnaya = new MainWindow();
            Hide();
            glavnaya.ShowDialog();
        }
    }
}
