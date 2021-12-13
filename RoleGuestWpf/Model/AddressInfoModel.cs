using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WinFormRoleGuest.BLL;
using WinFormRoleGuest.Interface;

namespace RoleGuestWpf.Model
{
    public class AddressInfoModel : Model
    {
        private AddressInfoDTO _selectedAddress;
        private string _country;
        private string _city;

        public IAddressInfoAccount _accountAddress;
        public IEnumerable<AddressInfoDTO> Addresses { get; set; }
        public AddressInfoDTO SelectedAddress
        {
            get { return _selectedAddress; }
            set
            {
                _selectedAddress = value;
            }
        }
        public string textBoxCountry
        {
            get { return _country; }
            set
            {
                _country = value;
            }
        }
        public string textBoxCity
        {
            get { return _city; }
            set
            {
                _city = value;
            }
        }
        
        public AddressInfoModel(IAddressInfoAccount accountAddress)
        {
            _accountAddress = accountAddress;
        }
        private void Fill()
        {
            textBoxCountry = " ";
            textBoxCity = " ";


        }
        public string this[string name]
        {
            get
            {
                string _result = null;
                switch (name)
                {
                    case "textBoxFirstName":
                        if (string.IsNullOrEmpty(textBoxCountry))
                        {
                            MessageBox.Show("Input country!", "Error");
                        }
                        break;
                    case "textBoxLastName":
                        if (string.IsNullOrEmpty(textBoxCity))
                        {
                            MessageBox.Show("Input city!", "Error");
                        }
                        break;                  
                }

                return _result;
            }
        }


    }
}
