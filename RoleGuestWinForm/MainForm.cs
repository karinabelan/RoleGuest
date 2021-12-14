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
    public partial class MainForm : Form
    {
        IClientAccount _clientAccount;
        IInfoAccount _infoAccount;
        IAddressInfoAccount _addressInfoAccount;
        public MainForm(IClientAccount clientAccount, IInfoAccount infoAccount, IAddressInfoAccount addressInfoAccount)
        {
            _clientAccount = clientAccount;
            _infoAccount = infoAccount;
            _addressInfoAccount = addressInfoAccount;
            InitializeComponent();
        }

        private void logOutLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm(_clientAccount,_infoAccount,_addressInfoAccount);
            loginForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangeForm changeForm = new ChangeForm(_clientAccount,_infoAccount,_addressInfoAccount);
            changeForm.Show();
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
