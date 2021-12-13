using RoleGuestWpf.WpfMenu;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using WinFormRoleGuest.Interface;

namespace RoleGuestWpf.Model
{
    public class LoginModel : Model
    {
        private IClientAccount _accountClientLog;
        public MainModel mainModel { get; set; }
        private string _login;
        private string _password;

        public LoginModel(IClientAccount accountClient, MainModel mainModel)
        {
            _accountClientLog = accountClient;
            LogginManager = new Login(this);
            this.mainModel = mainModel;

        }
        public ICommand LogginManager { get; set; }

        public string textBoxLogin
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged("textBoxLogin");
            }
        }
        public string textBoxPassword
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("textBoxPassword");
            }
        }
        public IClientAccount ClientAccount
        {
            get => _accountClientLog;
        }
        public string this[string name]
        {
            get
            {
                string _result = null;
                switch (name)
                {
                    case "textBoxLogin":
                        {
                            MessageBox.Show("Input login!");
                        };

                        break;
                    case "textBoxPassword":

                        {
                            MessageBox.Show("Input password!");
                        }

                        break;
                }
               return _result;
            }
        }

    }
}
