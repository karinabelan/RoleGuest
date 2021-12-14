using BLL.Interface;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoleGuestWinForm
{
    public partial class RegistrationForm : Form
    {
        IClientAccount _clientAccount;
        IInfoAccount _infoAccount;
        IAddressInfoAccount _addressInfoAccount;
        public RegistrationForm(IClientAccount clientAccount, IInfoAccount infoAccount, IAddressInfoAccount addressInfoAccount)
        {
            _clientAccount = clientAccount;
            _infoAccount = infoAccount;
            _addressInfoAccount = addressInfoAccount;
            //FirstNameField.Text = "First name";
            //FirstNameField.ForeColor = Color.Gray;
            //LastNameField.Text = "Last name";
            //LastNameField.ForeColor = Color.Gray;
            //LoginField.Text = "Login";
            //LoginField.ForeColor = Color.Gray;
            //PasswordField.Text = "Password";
            //PasswordField.ForeColor = Color.Gray;
            //CityField.Text = "City";
            //CityField.ForeColor = Color.Gray;
            //CountryField.Text = "Country";
            //CountryField.ForeColor = Color.Gray;
            InitializeComponent();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (FirstNameField.Text == "First name")
            {
                MessageBox.Show("input first name");
                return;
            }
            if (LastNameField.Text == "Last name")
            {
                MessageBox.Show("input last name");
                return;
            }
            if (LoginField.Text == "login")
            {
                MessageBox.Show("input login");
                return;
            }
            if (CountryField.Text == "Password")
            {
                MessageBox.Show("input password");
                return;
            }
            if (CityField.Text == "City")
            {
                MessageBox.Show("input city");
                return;
            }
            if (PasswordField.Text == "Country")
            {
                MessageBox.Show("input country");
                return;
            }
            //if (IsLoginExists())
            //{
            //    return;
            //}


            int countOfVisitStr = 1;
            int discountStr = 1;

            AddressInfoDTO addressInfoDTO = new AddressInfoDTO();
            addressInfoDTO.Country = PasswordField.Text;
            addressInfoDTO.City = CityField.Text;
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
            clients.FirstName = FirstNameField.Text;
            clients.LastName = LastNameField.Text;
            clients.Login = LoginField.Text;
            clients.Password = CountryField.Text;
            clients.InfoID = qurent1ID;

            clients.RowInsertTime = DateTime.Now;
            clients.RowUpdateTime = DateTime.Now;

            _clientAccount.Add(clients);

            MessageBox.Show("Account created","Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            LoginForm loginForm = new LoginForm(_clientAccount,_infoAccount,_addressInfoAccount);
            loginForm.Show();

        }


    
        private void FirstNameField_Enter(object sender, EventArgs e)
        {
            if (FirstNameField.Text == "First name")
            {
                FirstNameField.Text = "";
                FirstNameField.ForeColor = Color.Black;
            }
        }

        private void FirstNameField_Leave(object sender, EventArgs e)
        {
            if (FirstNameField.Text == "")
            {
                FirstNameField.Text = "First name";
                FirstNameField.ForeColor = Color.Gray;
            }
        }
        private void LastNameField_Enter(object sender, EventArgs e)
        {
            if (LastNameField.Text == "Last name")
            {
                LastNameField.Text = "";
                LastNameField.ForeColor = Color.Black;
            }
        }
        private void LastNameField_Leave(object sender, EventArgs e)
        {
            if (LastNameField.Text == "")
            {
                LastNameField.Text = "Last name";
                LastNameField.ForeColor = Color.Gray;
            }
        }

        private void EmailField_Enter(object sender, EventArgs e)
        {
            if (LoginField.Text == "Login")
            {
                LoginField.Text = "";
                LoginField.ForeColor = Color.Black;
            }
        }

        private void EmailField_Leave(object sender, EventArgs e)
        {
            if (LoginField.Text == "")
            {
                LoginField.Text = "Login";
                LoginField.ForeColor = Color.Gray;
            }
        }

        private void PasswordField_Enter(object sender, EventArgs e)
        {
            if (CountryField.Text == "Password")
            {
                CountryField.Text = "";
                CountryField.ForeColor = Color.Black;
            }
        }

        private void PasswordField_Leave(object sender, EventArgs e)
        {
            if (CountryField.Text == "")
            {
                CountryField.Text = "Password";
                CountryField.ForeColor = Color.Gray;
            }
        }

        private void CityField_Enter(object sender, EventArgs e)
        {
            if (CityField.Text == "City")
            {
                CityField.Text = "";
                CityField.ForeColor = Color.Black;
            }
        }

        private void CityField_Leave(object sender, EventArgs e)
        {
            if (CityField.Text == "")
            {
                CityField.Text = "City";
                CityField.ForeColor = Color.Gray;
            }
        }
        private void CountryField_Enter(object sender, EventArgs e)
        {
            if (PasswordField.Text == "Country")
            {
                PasswordField.Text = "";
                PasswordField.ForeColor = Color.Black;
            }
        }

        private void CountryField_Leave(object sender, EventArgs e)
        {
            if (PasswordField.Text == "")
            {
                PasswordField.Text = "Country";
                PasswordField.ForeColor = Color.Gray;
            }
        }
        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void registerLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm(_clientAccount,_infoAccount,_addressInfoAccount);
            loginForm.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }
    }
}
