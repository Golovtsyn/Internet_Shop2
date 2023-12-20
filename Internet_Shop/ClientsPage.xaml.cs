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
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Window
    {
        public ClientsPage()
        {
            InitializeComponent();
        }

        private void Menu(object sender, RoutedEventArgs e)
        {
            MainWindow glavnaya = new MainWindow();
            Hide();
            glavnaya.ShowDialog();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Context.DB.Client.ToList();
            Context.DB.Product.ToList();
            ProductSk.ItemsSource = Context.DB.Product.Local;
            Clienttable.ItemsSource = Context.DB.Client.Local;
            FillClientComboBox();
        }
        private void Window_Closed(object sender, EventArgs e)
        {

        }
        private void LoadClients()
        {
            List<Client> clients = Context.DB.Client.ToList(); // Получение обновленного списка клиентов из базы данных
            ClientComboBox.ItemsSource = clients;
            ClientComboBox.DisplayMemberPath = "FullName"; // Укажите свойство, которое будет отображаться в ComboBox
        }
    private void FillClientComboBox()
        {
            List<Client> clients = Context.DB.Client.ToList();
            ClientComboBox.ItemsSource = clients;
            ClientComboBox.DisplayMemberPath = "FullName";
        }
        private void FireClick(object sender, RoutedEventArgs e)
        {

            if (ClientComboBox.SelectedItem != null)
            {
                Client selectedClient = ClientComboBox.SelectedItem as Client;
                Context.DB.Client.Remove(selectedClient);
                Context.DB.SaveChanges();
                MessageBox.Show("Клиент удален.");
                FillClientComboBox(); // Обновляем список сотрудников в ComboBox после удаления
            }
            else
            {
                MessageBox.Show("Выберите клиента для удаления.");
            }
        }

        private void HireClick(object sender, RoutedEventArgs e)
        {
            // Проверяем, что все поля заполнены
            if (string.IsNullOrEmpty(FullNameBox.Text) || string.IsNullOrEmpty(AddressBox.Text) || string.IsNullOrEmpty(PhoneNumberBox.Text)|| ProductSk.SelectedItem == null)
            {
                MessageBox.Show("Заполните все поля и выберите товар для добавления.");
                return;
            }

            // Получаем выбранную Должность
            Product selectedProduct = ProductSk.SelectedItem as Product;

            // Создаем нового сотрудника и заполняем его данными
            Client client = new Client();
            client.FullName = FullNameBox.Text;
            client.Address = AddressBox.Text;
            client.PhoneNumber = PhoneNumberBox.Text;
            client.ProductID = selectedProduct.ID;

            // Добавляем сотрудника в базу данных
            Context.DB.Client.Add(client);
            Context.DB.SaveChanges();

            MessageBox.Show("Вы добавили человека.");
            LoadClients();
        }
        private void ProductSCT(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
