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
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void Button_LogIn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }

        private void Button_SingUp_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
