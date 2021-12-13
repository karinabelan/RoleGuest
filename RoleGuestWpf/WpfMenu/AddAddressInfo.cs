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
    public class AddAddressInfo:ICommand
    {
        //private MainViewModel _mainViewModel;
        private AddressInfoModel _addressInfoModel;

        public AddAddressInfo(AddressInfoModel addressInfoModel)
        {

            _addressInfoModel = addressInfoModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            AddressInfoDTO temp = new AddressInfoDTO();
            temp.Country = _addressInfoModel.EnteredCountry;
            temp.City = _addressInfoModel.EnteredCity;
            temp.RowInsertTime = DateTime.Now;
            temp.RowUpdateTime = DateTime.Now;
            _addressInfoModel.accountAddressInfo.AddObj(temp);
            MessageBox.Show("Successfully added supplier!", "Information");

        }
    }
}

