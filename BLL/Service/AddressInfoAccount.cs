using DAL.Interface;
using DTO;
using System.Collections.Generic;
using WinFormRoleGuest.Interface;

namespace WinFormRoleGuest.BLL

{
    public class AddressInfoAccount : IAddressInfoAccount
    {
        readonly private IAddressInfoDAL _addressInfos;
        public AddressInfoAccount(IAddressInfoDAL addressInfos)
        {
            _addressInfos = addressInfos;
        }
        public void Add(AddressInfoDTO address)
        {
            _addressInfos.Add(address);
        }

        public List<AddressInfoDTO> GetAll()
        {
            return _addressInfos.GetAll();
        }

        public AddressInfoDTO GetByID(int ID)
        {
            return _addressInfos.GetByID(ID);
        }

        public void ReadDB()
        {
            _addressInfos.ReadDB();
        }
    }
}
