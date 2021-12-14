using BLL.Interface;
using DAL.ADO;
using DAL.Interface;
using DTO;
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
    /// Логика взаимодействия для ChangeWindow.xaml
    /// </summary>
    public partial class ChangeWindow : Window
    {

        IClientAccount _clientAccount;
        IClientDAL clientDAL = new ClientADO();
        public ChangeWindow()
        {
            _clientAccount = new ClientAccount(clientDAL);
            InitializeComponent();
        }

        private void Button_LogIn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }

        private void Button_Registration_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();

        }

        private void Button_Change_Click(object sender, RoutedEventArgs e)
        {

            string login = textBoxLogin.Text.Trim();
            string firstName = textBoxFirstName.Text.Trim();
            if (login.Length <= 0)
            {
                textBoxLogin.ToolTip = "Input login!";
                textBoxLogin.Background = Brushes.DarkRed;
            }
            else if (firstName.Length <= 0)
            {
                textBoxFirstName.ToolTip = "Input first name!";
                textBoxFirstName.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                textBoxFirstName.ToolTip = "";
                textBoxFirstName.Background = Brushes.Transparent;
                bool isLogin1 = false;
                foreach (ClientDTO temp in _clientAccount.GetAll())
                {
                    if (temp.Login == login && temp.FirstName == firstName)
                    {
                        isLogin1 = true;
                    }
                }
                if (isLogin1)
                {
                    string newPass = textBoxNewPassword.Password.Trim();
                    if (newPass.Length <= 0)
                    {
                        textBoxNewPassword.ToolTip = "Input new password!";
                        textBoxNewPassword.Background = Brushes.DarkRed;
                    }
                    else
                    {
                        textBoxNewPassword.ToolTip = "";
                        textBoxNewPassword.Background = Brushes.Transparent;
                        _clientAccount.Change(newPass, login, firstName);
                        MessageBox.Show("Sucessfully changed!", "Information");
                        Hide();
                        LoginWindow loginWindow = new LoginWindow();
                        loginWindow.Show();
                    }

                }
                else
                {
                    MessageBox.Show("Wrong login or first name", "Error");
                }
            }
        }
    }
}
