using DAL.Interface;
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

namespace WinFormRoleGuest
{
    public partial class LoginForm : Form
    {
         IClientDAL<ClientDTO> client;
         IClientDAL<InfoDTO> info;
         IClientDAL<AddressInfoDTO> addressInfo;
        public LoginForm()
        {
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
            String loginUser = EmailField.Text;
            String passUser = PasswordField.Text;
            //DataTable table = new DataTable();
            //SqlDataAdapter adapter = new SqlDataAdapter();
            bool isLogin = false;
            foreach (ClientDTO temp in client.GetAll())
            {
                if (temp.Password == passUser && temp.Login == loginUser)
                {
                    isLogin = true;
                    foreach (var inf in info.GetAll())
                    {
                        if (temp.InfoID == inf.InfoID)
                        {
                            info.Change(Convert.ToString(inf.RowInsertTime), Convert.ToString(inf.AddressID), "");
                        }
                    }
                }

            }
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


    }
}
