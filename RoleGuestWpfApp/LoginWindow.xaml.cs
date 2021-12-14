using BLL.Interface;
using DAL.ADO;
using DAL.Interface;
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
using WinFormRoleGuest.BLL;

namespace RoleGuestWpfApp
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        IClientAccount _clientAccount;
        IClientDAL clientDAL = new ClientADO();
        public LoginWindow()
        {
            _clientAccount = new ClientAccount(clientDAL);
            InitializeComponent();
        }

        private void Button_Change_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            ChangeWindow changeWindow = new ChangeWindow();
            changeWindow.Show();

        }

        private void Button_LogIn_Click(object sender, RoutedEventArgs e)
        {
            String loginUser = textBoxLogin.Text.Trim();
            String passUser = textBoxPassword.Password.Trim();
            if (textBoxLogin.Text == "")
            {
                MessageBox.Show("input login", "Error");
                return;
            }
            if (textBoxPassword.Password == "")
            {
                MessageBox.Show("input password", "Error");
                return;
            }
            var tempObj = _clientAccount.GetObj(loginUser);
            if (tempObj == null)
            {
                MessageBox.Show("Coudnt find your account", "Error");
                return;
            }
            bool isExist = true;

            if (loginUser == tempObj.Login)
            {
                for (int i = 0; i < passUser.Length; i++)
                {
                    if (passUser[i] != tempObj.Password[i])
                    {
                        isExist = false;
                    }
                }
            }
            if (isExist == true)
            {

                this.Hide();
                MainWindow mainWindows = new MainWindow();
                mainWindows.Show();
            }
            else
            {
                MessageBox.Show("Incorrect password or login", "Error");
            }

        }

        private void Button_Registration_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
        }
    }
}
