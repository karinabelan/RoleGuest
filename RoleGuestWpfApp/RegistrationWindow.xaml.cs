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
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        IClientAccount _clientAccount;
        IClientDAL clientDAL = new ClientADO();
        IAddressInfoAccount _addressInfoAccount;
        IAddressInfoDAL addressInfoDAL = new AddressInfoADO();
        IInfoAccount _infoAccount;
        IInfoDAL infoDAL = new InfoADO();
        public RegistrationWindow()
        {
            _clientAccount = new ClientAccount(clientDAL);
            _addressInfoAccount = new AddressInfoAccount(addressInfoDAL);
            _infoAccount = new InfoAccount(infoDAL);
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
            String firstName = textBoxFirstName.Text.Trim();
            String lastName = textBoxLastName.Text.Trim();
            String country = textBoxCountry.Text.Trim();
            String city = textBoxCity.Text.Trim();
            String loginUser = textBoxLogin.Text.Trim();
            String passUser = textBoxPassword.Password.Trim();

            if (firstName.Length <= 0)
            {
                textBoxFirstName.ToolTip = "Input first name!";
                textBoxFirstName.Background = Brushes.DarkRed;
            }
            else if (lastName.Length <= 0)
            {
                textBoxLastName.ToolTip = "Input last name!";
                textBoxLastName.Background = Brushes.DarkRed;
            }
            else if (country.Length <= 0)
            {
                textBoxCountry.ToolTip = "Input country!";
                textBoxCountry.Background = Brushes.DarkRed;
            }
            else if (city.Length <= 0)
            {
                textBoxCity.ToolTip = "Input city!";
                textBoxCity.Background = Brushes.DarkRed;
            }
            else if (loginUser.Length <= 0)
            {
                textBoxLogin.ToolTip = "Input login!";
                textBoxLogin.Background = Brushes.DarkRed;
            }
            else if (passUser.Length <= 0)
            {
                textBoxPassword.ToolTip = "Input password!";
                textBoxPassword.Background = Brushes.DarkRed;
            }
            else
            {

                textBoxFirstName.ToolTip = "";
                textBoxFirstName.Background = Brushes.Transparent;
                textBoxLastName.ToolTip = "";
                textBoxLastName.Background = Brushes.Transparent;
                textBoxCountry.ToolTip = "";
                textBoxCountry.Background = Brushes.Transparent;
                textBoxCity.ToolTip = "";
                textBoxCity.Background = Brushes.Transparent;
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                textBoxPassword.ToolTip = "";
                textBoxPassword.Background = Brushes.Transparent;

                int countOfVisitStr = 1;
                int discountStr = 1;

                AddressInfoDTO addressInfoDTO = new AddressInfoDTO();
                addressInfoDTO.Country = textBoxCountry.Text;
                addressInfoDTO.City = textBoxCity.Text;
                DateTime qurentTime = DateTime.Now;
                addressInfoDTO.RowInsertTime = qurentTime;

                addressInfoDTO.RowUpdateTime = DateTime.Now;
                _addressInfoAccount.Add(addressInfoDTO);
                _addressInfoAccount.ReadDB();
                int qurentID = 0;
                foreach (var address in _addressInfoAccount.GetAll())
                {
                    if (Convert.ToString(qurentTime) == Convert.ToString(address.RowInsertTime))
                    {
                        qurentID = address.AddressID;
                    }
                }

                InfoDTO infoDTO = new InfoDTO();
                infoDTO.CountOfVisit = countOfVisitStr;
                infoDTO.Discount = discountStr;
                DateTime qurent1Time = DateTime.Now;
                infoDTO.RowInsertTime = qurent1Time;
                infoDTO.RowUpdateTime = DateTime.Now;

                //infoDTO.InfoID =InfoIDStr;
                infoDTO.AddressID = qurentID;
                _infoAccount.Add(infoDTO);
                _infoAccount.ReadDB();
                int qurent1ID = 0;
                foreach (var inforn in _infoAccount.GetAll())
                {
                    if (Convert.ToString(qurent1Time) == Convert.ToString(inforn.RowInsertTime))
                    {
                        qurent1ID = inforn.InfoID;
                    }
                }
                ClientDTO clients = new ClientDTO();
                clients.FirstName = textBoxFirstName.Text;
                clients.LastName = textBoxLastName.Text;
                clients.Login = textBoxLogin.Text;
                clients.Password = textBoxPassword.Password;
                clients.InfoID = qurent1ID;

                clients.RowInsertTime = DateTime.Now;
                clients.RowUpdateTime = DateTime.Now;

                _clientAccount.Add(clients);

                MessageBox.Show("Account created", "Information");
                this.Hide();
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
            }
        }
    }
}
