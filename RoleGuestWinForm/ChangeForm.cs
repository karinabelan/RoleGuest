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
    public partial class ChangeForm : Form
    {
        IClientAccount _clientAccount;
        IInfoAccount _infoAccount;
        IAddressInfoAccount _addressInfoAccount;
        public ChangeForm(IClientAccount clientAccount, IInfoAccount infoAccount, IAddressInfoAccount addressInfoAccount)
        {
            _clientAccount = clientAccount;
            _infoAccount = infoAccount;
            _addressInfoAccount = addressInfoAccount;
            InitializeComponent();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            string login = LoginField.Text;
            string firstName = FirstNameField.Text;
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
                string newPass = NewPasswordField.Text;
                _clientAccount.Change(newPass, login, firstName);
                MessageBox.Show("Updated!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Wrong login or first name", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Hide();
            LoginForm loginForm = new LoginForm(_clientAccount,_infoAccount,_addressInfoAccount);
            loginForm.Show();
        }
        
    }
}
