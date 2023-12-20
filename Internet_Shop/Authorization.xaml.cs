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
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }
        private void LoginClick(object sender, RoutedEventArgs e)
        {
            List<User> users = Context.DB.User.Where(user => user.Login == login.Text && user.Password == password.Password).ToList();
            if (users.Count > 0)
            {
                User user = users[0];

                string roles = "";
                string separator = ", ";
                bool addSeparator = false;
                List<string> rolelist = new List<string>();
                foreach (Role role in user.Role)
                {
                    rolelist.Add(role.Name);
                    if (addSeparator)
                        roles += separator;
                    roles += role.Name;
                    addSeparator = true;
                }
                MessageBox.Show($"Здравствуйте, {user.Login}, ваши роли: {roles}");
                if (rolelist.Contains("1"))
                {
                    MessageBox.Show($"Здравствуйте,{user.Login}.Ваши роли :{roles} ");
                    MainWindow window = new MainWindow();
                    Close();
                    window.ShowDialog();

                }
                else
                {
                    MainWindow window = new MainWindow();
                    Close();
                    window.ShowDialog();

                }

            }
            else { MessageBox.Show("Введённый логин или пароль не совпадают"); }
        }
        private void GuestClick(object sender, RoutedEventArgs e)
        {
            GuestMenu guest = new GuestMenu();
            Hide();
            guest.ShowDialog();
        }
    }
}
