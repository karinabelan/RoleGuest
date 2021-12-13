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

namespace RoleGuestWpf
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

        private void Button_LogOut_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }

        private void Button_Settings_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            ChangeWindow changeWindow = new ChangeWindow();
            changeWindow.Show();
        }
    }
}
