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

namespace RoleGuestWpf
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

        private void Button_Change_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            ChangeWindow changeWindow = new ChangeWindow();
            changeWindow.Show();
        }

        private void Button_Registration_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
        }

        private void Button_LogIn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
