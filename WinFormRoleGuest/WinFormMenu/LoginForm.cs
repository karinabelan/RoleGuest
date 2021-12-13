using System;
using System.Drawing;
using System.Windows.Forms;
using WinFormRoleGuest.Interface;

namespace WinFormRoleGuest
{
    public partial class LoginForm : Form
    {
        IAddressInfoAccount _addressInfoAccount;
        IInfoAccount _infoAccount;
        IClientAccount _clientAccount;
        public LoginForm(IClientAccount clientAccount, IInfoAccount infoAccount, IAddressInfoAccount addressInfoAccount)
        {

            _addressInfoAccount = addressInfoAccount;
            _infoAccount = infoAccount;
            _clientAccount = clientAccount;
            InitializeComponent();
        }
        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void close_MouseEnter(object sender, EventArgs e)
        {
            close.ForeColor = Color.Red;
        }
        private void close_MouseLeave(object sender, EventArgs e)
        {
            close.ForeColor = Color.White;
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

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (EmailField.Text == "")
            {
                MessageBox.Show("input e-mail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (PasswordField.Text == "")
            {
                MessageBox.Show("input password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            String loginUser = EmailField.Text;
            String passUser = PasswordField.Text;
            var temp = _clientAccount.GetAll();
            if (temp==null)
            {
                MessageBox.Show("Try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            bool isLogin = false;


            //if (loginUser == temp.Login)
            //{
            //    for (int i = 0; i < passUser.Length;)
            //    {
            //        if (passUser != temp.Password)
            //        {
            //            isLogin = false;
            //        }
            //    }
            //}
            if (isLogin)
            {
                this.Hide();
                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Incorect password or login.\n Try again!");
            }
        }

        private void registerLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }

        private void RestorationLable_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangePasswordForm changePasswordForm = new ChangePasswordForm();
            changePasswordForm.Show();
        }
    }
}
