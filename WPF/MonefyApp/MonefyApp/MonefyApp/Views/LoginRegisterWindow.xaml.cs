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
using MonefyApp.Views;

namespace MonefyApp.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginRegisterWindow.xaml
    /// </summary>
    public partial class LoginRegisterWindow : Window
    {
        public LoginRegisterWindow()
        {
            InitializeComponent();
            
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string password = passBox.Password.Trim();
            string tryPassword = trypassBox.Password.Trim();
            string email = emailBox.Text.Trim();
            JsonSerializerUsers users = new JsonSerializerUsers(login, password, email);
            ClearFieldBorders();
            if (login.Length < 5 || password.Length < 5 || tryPassword.Length < 5 || email.Length < 5)
            {
                MessageBox.Show("Вы не заполнили необходимые поля, пожалуйста, повторите попытку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Это поле введено неккоректно!";
                textBoxLogin.BorderBrush = Brushes.DarkRed;
            }
            if (email.Length < 5)
            {
                emailBox.ToolTip = "Это поле введено неккоректно!";
                emailBox.BorderBrush = Brushes.DarkRed;
            }
            if (password.Length < 5)
            {
                passBox.ToolTip = "Это поле введено неккоректно!";
                passBox.BorderBrush = Brushes.DarkRed;
            }
            if (tryPassword != password)
            {
                MessageBox.Show("Вы неправильно ввели повторный код. Повторите попытку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                passBox.Clear();
                trypassBox.Clear();
            }
            if (!IsValidEmail(email))
            {
                emailBox.ToolTip = "Вы забыли \"@\" или \".\"";
                emailBox.BorderBrush = Brushes.DarkRed;
            }
            if (!IsValidPassword(password))
            {
                passBox.ToolTip = "Введите более надёжный пароль!";
                passBox.BorderBrush = Brushes.DarkRed;
            }

            else
            {
                users.SaveToJson("DataUsers.json");
                MessageBox.Show("Регистрация успешно пройдена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
                Hide();
                textBoxLogin.BorderBrush = Brushes.Black;
                passBox.BorderBrush = Brushes.Black;
                trypassBox.BorderBrush = Brushes.Black;
                ClearFields();

            }

        }

  
        private void ClearFields()
        {
            passBox.Clear();
            trypassBox.Clear();
        }

        private void ClearFieldBorders()
        {
            passBox.ClearValue(BorderBrushProperty);
            trypassBox.ClearValue(BorderBrushProperty);
        }


        private bool IsValidPassword(string password)
        {
            string passwordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{5,}$";
            return System.Text.RegularExpressions.Regex.IsMatch(password, passwordRegex);
        }

        private bool IsValidEmail(string email)
        {
            string emailRegex = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
            return System.Text.RegularExpressions.Regex.IsMatch(email, emailRegex);
        }

        private void LoginClick(object sender, EventArgs e)
        {
            LoginWindow login = new LoginWindow();
            login.Show();
            Hide();
        }

        private void Window_Closed(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
