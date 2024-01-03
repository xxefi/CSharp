using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MonefyApp.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            
        }

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            ClearFieldBorders();
            string login = textBoxLogin.Text.Trim();
            string email = textBoxLogin.Text.Trim();
            string password = passBox.Password.Trim();
            if (login.Length < 5 || password.Length < 5)
            {
                MessageBox.Show("Вы не заполнили необходимые поля, пожалуйста, повторите попытку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                ClearFields() ;
            }

            if (login.Length < 5)
            {   
                textBoxLogin.ToolTip = "Это поле введено неккоректно!";
                textBoxLogin.BorderBrush = Brushes.DarkRed;
            }
            if (password.Length < 5)
            {
                passBox.ToolTip = "Это поле введено неккоректно!";
                passBox.BorderBrush = Brushes.DarkRed;
            }
            else
            {
                textBoxLogin.BorderBrush = Brushes.Black;
                passBox.BorderBrush = Brushes.Black;
                ClearFields();
                JsonSerializerUsers users = JsonSerializerUsers.LoadFromJson("DataUsers.json");
                if (users.Users.Any(user => user.Login == login || users.Password == password))
                {
                    MainWindow main = new();
                    main.Show();
                    Hide();
                }
                else if (users.Users.Any(user => user.Email == email || users.Password == password))
                {
                    MainWindow main = new();
                    main.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Неверный логин/e-mail или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }

            
        }

        private void ClearFields()
        {
            passBox.Clear();
        }

        private void ClearFieldBorders()
        {
            passBox.ClearValue(BorderBrushProperty);
        }

        private void RegisterClick(object sender, EventArgs e)
        {
            LoginRegisterWindow registerWindow = new LoginRegisterWindow();
            registerWindow.Show();
            Hide();
        }

        private void Window_Closed(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.Current.Shutdown();
        }

    }
}
