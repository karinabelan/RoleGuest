using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WinFormRoleGuest.Interface;

namespace RoleGuestWpf.Model
{
    public class MainModel:Model
    {
        private bool _loggined = false;
        private IClientAccount _serviceClient;
        private IAddressInfoAccount _servicAddressInfo;
        private Model _selectedViewModel;
        private TabItem _tabControlSelectedItem;

        public Model SelectedViewModel
        {
            get => this._selectedViewModel;
            set
            {
                this._selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }
        public bool Loggined
        {

            get => _loggined;
            set
            {
                _loggined = value;
                OnPropertyChanged("Loggined");
            }
        }
        public IClientAccount ClientAccount
        {
            get => this._serviceClient;
            set => this._serviceClient = value;
        }
        public IAddressInfoAccount AddressInfoAccount
        {
            get => this._servicAddressInfo;
            set => this._servicAddressInfo = value;
        }
        public TabItem TabControlSelectedItem
        {
            get => this._tabControlSelectedItem;
            set
            {
                this._tabControlSelectedItem = value;
                OnPropertyChanged("TabControlSelectedItem");
            }
        }
    }
}
