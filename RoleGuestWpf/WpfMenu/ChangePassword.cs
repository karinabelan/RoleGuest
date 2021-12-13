using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RoleGuestWpf.WpfMenu
{
    public class ChangePassword:ICommand
    {
        private ChangePassword _clientModel;

        public ChangePassword(ChangePassword clientModel)
        {

            this._clientModel = clientModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _clientModel.clients.ChangeValueObj(_clientModel.SelectedClient.Login, _clientModel.SelectedClient.FirstName, _clientModel.Password);

            MessageBox.Show("Successfully changed!", "Information");
        }
    }
}
