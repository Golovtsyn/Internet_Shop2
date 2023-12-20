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
    /// Логика взаимодействия для EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Window
    {
        public EmployeesPage()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Context.DB.Employee.ToList();
            table.ItemsSource = Context.DB.Employee.Local;
            FillEmployeeComboBox();
        }
        private void Menu(object sender, RoutedEventArgs e)
        {
            MainWindow glavnaya = new MainWindow();
            Hide();
            glavnaya.ShowDialog();
        }
        private void Window_Closed(object sender, EventArgs e)
        {

        }
        private void LoadClients()
        {
            List<Employee> employees = Context.DB.Employee.ToList(); // Получение обновленного списка клиентов из базы данных
            EmployeeComboBox.ItemsSource = employees;
            EmployeeComboBox.DisplayMemberPath = "FullName"; // Укажите свойство, которое будет отображаться в ComboBox
        }
        private void FillEmployeeComboBox()
        {
            List<Employee> employees = Context.DB.Employee.ToList();
            EmployeeComboBox.ItemsSource = employees;
            EmployeeComboBox.DisplayMemberPath = "FullName";
        }
        private void FireClick(object sender, RoutedEventArgs e)
        {
            if (EmployeeComboBox.SelectedItem != null)
            {
                Employee selectedEmployee = EmployeeComboBox.SelectedItem as Employee;
                Context.DB.Employee.Remove(selectedEmployee);
                Context.DB.SaveChanges();
                MessageBox.Show("Сотрудник уволен.");
                FillEmployeeComboBox(); // Обновляем список сотрудников в ComboBox после удаления
            }
            else
            {
                MessageBox.Show("Выберите сотрудника для увольнения.");
            }
        }

        private void HireClick(object sender, RoutedEventArgs e)
        {
            // Проверяем, что все поля заполнены
            if (string.IsNullOrEmpty(FullNameBox.Text) || string.IsNullOrEmpty(SexBox.Text) || string.IsNullOrEmpty(PositionBox.Text) || string.IsNullOrEmpty(SalaryBox.Text))
            {
                MessageBox.Show("Заполните все поля и выберите комнату для найма.");
                return;
            }

            // Получаем выбранную Должность

            // Создаем нового сотрудника и заполняем его данными
            Employee employee = new Employee();
            employee.FullName = FullNameBox.Text;
            employee.Gender = SexBox.Text;
            employee.Position = PositionBox.Text;
            employee.Salary = SalaryBox.Text;

            // Добавляем сотрудника в базу данных
            Context.DB.Employee.Add(employee);
            Context.DB.SaveChanges();

            MessageBox.Show("Вы наняли человека.");
            LoadClients();
        }
    }
}
