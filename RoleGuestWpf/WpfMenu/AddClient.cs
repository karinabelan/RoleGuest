using DTO;
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
    public class AddClient:ICommand
    {
        private ClientModel _clientModel;

        public AddClient(ClientModel clientModel)
        {
            _clientModel = clientModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ClientDTO temp = new ClientDTO();
            temp.FirstName = _clientModel.textBoxFirstName;
            temp.LastName = _clientModel.textBoxLastName;
            temp.Login = _clientModel.textBoxLogin;
            temp.Password = _clientModel.textBoxPassword;
            temp.RowInsertTime = DateTime.Now;
            temp.RowUpdateTime = DateTime.Now;
            _clientModel.accountClient.AddObj(temp);
            MessageBox.Show("Successfully added supplier!", "Information");

        }
    }
}
