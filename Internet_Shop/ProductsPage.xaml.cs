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
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Window
    {
        public ProductsPage()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Context.DB.Product.ToList();
            ProductsGrid.ItemsSource = Context.DB.Product.Local;
            ProductPickComboBox();

        }
        private void Window_Closed(object sender, EventArgs e)
        {

        }
        private void LoadClients()
        {
            List<Product> products = Context.DB.Product.ToList(); // Получение обновленного списка клиентов из базы данных
            ProductComboBox.ItemsSource = products;
            ProductComboBox.DisplayMemberPath = "Name"; // Укажите свойство, которое будет отображаться в ComboBox
        }

        private void Menu(object sender, RoutedEventArgs e)
        {
            MainWindow glavnaya = new MainWindow();
            Hide();
            glavnaya.ShowDialog();
        }

        private void delete(object sender, RoutedEventArgs e)
        {
            if (ProductComboBox.SelectedItem != null)
            {
                Product selectedEmployee = ProductComboBox.SelectedItem as Product;
                Context.DB.Product.Remove(selectedEmployee);
                Context.DB.SaveChanges();
                MessageBox.Show("Товар удален");
                ProductPickComboBox();
            }
            else
            {
                MessageBox.Show("Выберите товар для удаления.");
            }
        }
        private void ProductPickComboBox()
        {
            List<Product> products = Context.DB.Product.ToList();
            ProductComboBox.ItemsSource = products;
            ProductComboBox.DisplayMemberPath = "Name";
        }
        private void Add(object sender, RoutedEventArgs e)
        {
            // Проверяем, что все поля заполнены
            if (string.IsNullOrEmpty(nameBox.Text) || string.IsNullOrEmpty(descriptionBox.Text) || string.IsNullOrEmpty(priceBox.Text) || string.IsNullOrEmpty(amountBox.Text))
            {
                MessageBox.Show("Заполните все поля и выберите товар для добавления.");
                return;
            }
            Product products = new Product();
            products.Name = nameBox.Text;
            products.Description = descriptionBox.Text;
            products.Price = priceBox.Text;
            products.Amount = amountBox.Text;
            // Добавляем сотрудника в базу данных
            Context.DB.Product.Add(products);
            Context.DB.SaveChanges();

            MessageBox.Show("Вы добавили товар.");
            LoadClients();
        }
    }
}
