using DTO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using WinFormRoleGuest.Interface;

namespace RoleGuestWpf.Model
{
    public class ClientModel:Model
    {
        private ClientDTO _selectedClient;
        private string _firstName;
        private string _lastName;
        private string _login;
        private string _password;

        public IClientAccount _accountClient;
        public IEnumerable<ClientDTO> Clients { get; set; }
        public ClientDTO SelectedClient
        {
            get { return _selectedClient; }
            set
            {
                _selectedClient = value;
                OnPropertyChanged("SelectedClient");
            }
        }
        public string textBoxFirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
            }
        }
        public string textBoxLastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
            }
        }
        public string textBoxLogin
        {
            get { return _login; }
            set
            {
                _login = value;
            }
        }
        public string textBoxPassword
        {
            get { return _password; }
            set
            {
                _password = value;
            }
        }
        public ClientModel(IClientAccount accountClient)
        { 
            _accountClient = accountClient;
        }
        private void Fill()
        {
            textBoxFirstName = " ";
            textBoxLastName = " ";
            textBoxLogin = " ";
            textBoxPassword = " ";
           // Clients = _accountClient.GetAll();

        }
        public string this[string name]
        {
            get
            {
                string _result = null;
                switch (name)
                {
                    case "textBoxFirstName":
                        if (string.IsNullOrEmpty(textBoxFirstName))
                        {
                            MessageBox.Show("Input FirstName!", "Error");
                        }
                        break;
                    case "textBoxLastName":
                        if (string.IsNullOrEmpty(textBoxLastName))
                        {
                            MessageBox.Show("Input LastName!", "Error");
                        }
                        break;              
                     case "textBoxLogin":
                        if (string.IsNullOrEmpty(textBoxFirstName))
                        {
                            MessageBox.Show("Input login!", "Error");
                        }
                        break;                 
                      case "textBoxPassword":
                        if (string.IsNullOrEmpty(textBoxFirstName))
                        {
                            MessageBox.Show("Input password!", "Error");
                        }
                        break;
                }

                return _result;
            }
        }


    }
}
