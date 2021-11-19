using DAL.Interface;
using DTO;
using System;
using System.Drawing;
using System.Windows.Forms;
using WinFormRoleGuest.Interface;

namespace WinFormRoleGuest
{
    public partial class RegisterForm : Form
    {
        IClientAccount clientAccount;
        IInfoAccount infoAccount;
        IAddressInfoAccount addressInfoAccount;

        public RegisterForm()
        {
            InitializeComponent();
            FirstNameField.Text = "First name";
            FirstNameField.ForeColor = Color.Gray;
            LastNameField.Text = "Last name";
            LastNameField.ForeColor = Color.Gray;
            EmailField.Text = "Login";
            EmailField.ForeColor = Color.Gray;
            PasswordField.Text = "Password";
            PasswordField.ForeColor = Color.Gray;
            CityField.Text = "City";
            CityField.ForeColor = Color.Gray;
            CountryField.Text = "Country";
            CountryField.ForeColor = Color.Gray;
            
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        Point LastPoint;
        private void MainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - LastPoint.X;
                this.Top += e.Y - LastPoint.Y;
            }
        }

        private void MainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            LastPoint = new Point(e.X, e.Y);
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
            if (EmailField.Text == "Login")
            {
                EmailField.Text = "";
                EmailField.ForeColor = Color.Black;
            }
        }

        private void EmailField_Leave(object sender, EventArgs e)
        {
            if (EmailField.Text == "")
            {
                EmailField.Text = "Login";
                EmailField.ForeColor = Color.Gray;
            }
        }

        private void PasswordField_Enter(object sender, EventArgs e)
        {
            if (PasswordField.Text == "Password")
            {
                PasswordField.Text = "";
                PasswordField.ForeColor = Color.Black;
            }
        }

        private void PasswordField_Leave(object sender, EventArgs e)
        {
            if (PasswordField.Text == "")
            {
                PasswordField.Text = "Password";
                PasswordField.ForeColor = Color.Gray;
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
            if (CountryField.Text == "Country")
            {
                CountryField.Text = "";
                CountryField.ForeColor = Color.Black;
            }
        }

        private void CountryField_Leave(object sender, EventArgs e)
        {
            if (CountryField.Text == "")
            {
                CountryField.Text = "Country";
                CountryField.ForeColor = Color.Gray;
            }
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
            if (EmailField.Text == "login")
            {
                MessageBox.Show("input login");
                return;
            }
            if (PasswordField.Text == "Password")
            {
                MessageBox.Show("input password");
                return;
            }
            if (CityField.Text == "City")
            {
                MessageBox.Show("input city");
                return;
            }
            if (CountryField.Text == "Country")
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
            addressInfoDTO.Country = CountryField.Text;
            addressInfoDTO.City = CityField.Text;
            DateTime qurentTime = DateTime.Now;
            addressInfoDTO.RowInsertTime = qurentTime;

            addressInfoDTO.RowUpdateTime = DateTime.Now;
            addressInfoAccount.Add(addressInfoDTO);
            addressInfoAccount.ReadDB();
            int qurentID = 0;
            foreach (var address in addressInfoAccount.GetAll())
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
            infoAccount.Add(infoDTO);
            infoAccount.ReadDB();
            int qurent1ID = 0;
            foreach (var inforn in infoAccount.GetAll())
            {
                if (Convert.ToString(qurent1Time) == Convert.ToString(inforn.RowInsertTime))
                {
                    qurent1ID = inforn.InfoID;
                }
            }
            ClientDTO clients = new ClientDTO();
            clients.FirstName = FirstNameField.Text;
            clients.LastName = LastNameField.Text;
            clients.Login = EmailField.Text;
            clients.Password = PasswordField.Text;
            clients.InfoID = qurent1ID;

            clients.RowInsertTime = DateTime.Now;
            clients.RowUpdateTime = DateTime.Now;

            clientAccount.Add(clients);

            MessageBox.Show("Account created");
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();

        }

        public bool IsLoginExists(ClientDTO client)
        {
            bool res = false;
            foreach (var curr in clientAccount.GetAll())
            {
                if (curr.Login == client.Login)
                {
                    res = true;
                }
            }
            return res;
        }
    }
}
