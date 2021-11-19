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
    public partial class ChangePasswordForm : Form
    {
        public ChangePasswordForm()
        {
            InitializeComponent();
            FirstNameField.Text = "First name";
            FirstNameField.ForeColor = Color.Gray;
            EmailField.Text = "Login";
            EmailField.ForeColor = Color.Gray;
            NewPasswordField.Text = "New password";
            NewPasswordField.ForeColor = Color.Gray;
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

        private void NewPasswordField_Enter(object sender, EventArgs e)
        {
            if (NewPasswordField.Text == "New password")
            {
                NewPasswordField.Text = "";
                NewPasswordField.ForeColor = Color.Black;
            }
        }

        private void NewPasswordField_Leave(object sender, EventArgs e)
        {
            if (NewPasswordField.Text == "")
            {
                NewPasswordField.Text = "New password";
                NewPasswordField.ForeColor = Color.Gray;
            }
        }


        //private void buttonLogin_Click(object sender, EventArgs e)
        //{
        //    bool isLogin1 = false;
        //    foreach (ClientDTO temp in client.GetAll())
        //    {
        //        if (temp.Login == EmailField.Text && temp.FirstName == FirstNameField.Text)
        //        {
        //            isLogin1 = true;
        //        }
        //    }
        //    if (isLogin1)
        //    {
        //        client.Change(NewPasswordField.Text, EmailField.Text, FirstNameField.Text);
        //        this.Hide();
        //        LoginForm loginForm = new LoginForm();
        //        loginForm.Show();
        //    }
        //}


    }
}
