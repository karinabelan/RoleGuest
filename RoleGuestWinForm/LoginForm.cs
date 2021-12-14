using BLL.Interface;
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
    public partial class LoginForm : Form
    {
        IClientAccount _clientAccount;
        IInfoAccount _infoAccount;
        IAddressInfoAccount _addressInfoAccount;
        public LoginForm(IClientAccount clientAccount, IInfoAccount infoAccount, IAddressInfoAccount addressInfoAccount)
        {
            _clientAccount = clientAccount;
            _infoAccount = infoAccount;
            _addressInfoAccount = addressInfoAccount;
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            String loginUser = EmailField.Text;
            String passUser = PasswordField.Text;
            if (EmailField.Text == "")
            {
                MessageBox.Show("input login", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (PasswordField.Text == "")
            {
                MessageBox.Show("input password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var tempObj = _clientAccount.GetObj(loginUser);
            if (tempObj == null)
            {
                MessageBox.Show("Incorrect login or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MainForm mainForm = new MainForm(_clientAccount,_infoAccount,_addressInfoAccount);
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Incorrect password or login", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RestorationLable_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangeForm changeForm = new ChangeForm(_clientAccount, _infoAccount,_addressInfoAccount);
            changeForm.Show();
        }

        private void registerLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationForm registrationForm = new RegistrationForm(_clientAccount, _infoAccount,_addressInfoAccount);
            registrationForm.Show();
        }
    }
}
