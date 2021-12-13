using RoleGuestWpf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RoleGuestWpf.WpfMenu
{

    public class Login : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private LoginModel _loginModel;

        public bool CanExecute(object parameter)
        {
            return true;

        }

        public void Execute(object parameter)
        {
            if (_loginModel.ClientAccount.IsLogin(_loginModel.textBoxLogin, _loginModel.textBoxPassword))
            {

                _loginModel.mainModel.Model = new LoginModel(_loginModel.mainModel.AccountClient);
                _loginModel.mainModel.Loggined = true;
            }
            else
            {
                MessageBox.Show("No user exist!", "Error");
            }

        }

        public Login(LoginModel loginView)
        {
            _loginModel = loginView;
        }
    }
}
