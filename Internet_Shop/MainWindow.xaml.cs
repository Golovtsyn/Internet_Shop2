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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Internet_Shop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Vihod(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Clients(object sender, RoutedEventArgs e)
        {
            ClientsPage clients = new ClientsPage();
            Hide();
            clients.ShowDialog();
        }

        private void Sotrudniki(object sender, RoutedEventArgs e)
        {
            EmployeesPage sotrudniki = new EmployeesPage();
            Hide();
            sotrudniki.ShowDialog();
        }

        private void Zakazi(object sender, RoutedEventArgs e)
        {
            OrdersPage orders = new OrdersPage();
            Hide();
            orders.ShowDialog();
        }

        private void Tovari(object sender, RoutedEventArgs e)
        {
            ProductsPage tovari = new ProductsPage();
            Hide();
            tovari.ShowDialog();
        }
    }
}
